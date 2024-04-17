namespace Gallery

open System.Diagnostics
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module FocusAttributes =
    /// Allows setting the Focus on an Avalonia.Input.InputElement
    let Focus =
        Attributes.defineBool "Focus" (fun oldValueOpt newValueOpt node ->
            let target = node.Target :?> InputElement

            let rec focusAndCleanUp x y =
                target.Focus() |> ignore
                target.AttachedToVisualTree.RemoveHandler(focusAndCleanUp) // to clean up

            if newValueOpt.IsSome && newValueOpt.Value then
                (* TODO setting the focus on an AutoCompleteBox is broken.
                    It works for some (probably threading-related) reason if you hit a magic break point here
                    or in the focusAndCleanUp handler above. *)
                Debugger.Break()
                target.AttachedToVisualTree.AddHandler(focusAndCleanUp))

type FocusModifiers =
    [<Extension>]
    /// Sets the Focus on an IFabInputElement if set is true; otherwise does nothing.
    static member inline focus(this: WidgetBuilder<'msg, #IFabInputElement>, set: bool) =
        this.AddScalar(FocusAttributes.Focus.WithValue(set))

type EditableNode(name, children) =
    let mutable _name: string = name
    let mutable _children: EditableNode list = children
    let mutable _expanded: bool = false

    //TODO Is a mutable model required or can an updated immutable model be passed to the parent component?
    member this.Name
        with get () = _name
        and set value = _name <- value

    member this.Children
        with get () = _children
        and set value = _children <- value

    member this.IsExpanded
        with get () = _expanded
        and set value = _expanded <- value

module EditableNodeView =
    type Model = { Node: EditableNode }

    type Msg = NameChanged of string

    let init node = { Node = node }

    let update msg (model: Model) =
        match msg with
        | NameChanged name ->
            model.Node.Name <- name
            model

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false // unhandled
#else
            true // handled
#endif
        )

    let view node =
        Component(program, node) {
            AutoCompleteBox([])
                .onTextChanged(node.Name, NameChanged)
                .focus(node.Name = "")
        }

module EditableTreeView =

    type Model =
        { Nodes: EditableNode list
          Filter: string
          Selected: EditableNode option }

    type Msg =
        | AddNodeTo of string
        | RemoveNode of EditableNode
        | FilterChanged of string
        | SelectionItemChanged of SelectionChangedEventArgs

    let branch name (children: EditableNode list) = EditableNode(name, children)
    let leaf name = branch name []

    let init () =
        let nodes =
            [ branch
                  "Animals"
                  [ branch "Mammals" [ leaf "Lion"; leaf "Cat"; leaf "Zebra" ]
                    branch
                        "Birds"
                        [ leaf "Eagle"
                          leaf "Sparrow"
                          leaf "Dove"
                          leaf "Owl"
                          leaf "Parrot"
                          leaf "Pigeon" ]
                    leaf "Platypus" ]
              branch
                  "Aliens"
                  [ branch "pyramid-building terrestrial" [ leaf "Alpaca"; leaf "Camel"; leaf "Lama" ]
                    branch "extra-terrestrial" [ leaf "Alf"; leaf "E.T."; leaf "Klaatu" ] ] ]

        { Nodes = nodes
          Filter = ""
          Selected = None },
        []

    let rec findNodes (predicate: EditableNode -> bool) (nodes: EditableNode seq) =
        let rec matches (node: EditableNode) =
            if predicate node then
                seq { node }
            else
                node.Children |> Seq.collect matches

        nodes |> Seq.collect matches

    let rec removeNode (removable: EditableNode) (node: EditableNode) : EditableNode option =
        if node = removable then
            None // Indicates that the node was found and removed
        else
            let remaining = node.Children |> List.choose(removeNode removable)

            if remaining.Length < node.Children.Length then
                node.Children <- remaining

            Some node

    let update msg model =
        match msg with
        | AddNodeTo parentNodeName ->
            let newNode = leaf ""

            let updated =
                match findNodes (fun n -> n.Name = parentNodeName) model.Nodes |> Seq.tryExactlyOne with
                | Some node ->
                    node.Children <- node.Children @ [ newNode ]
                    model
                | None ->
                    { model with
                        Nodes = model.Nodes @ [ newNode ] }

            updated, Cmd.none

        | RemoveNode node ->
            { model with
                Nodes = model.Nodes |> List.choose(removeNode node) },
            Cmd.none

        | FilterChanged filter -> { model with Filter = filter }, Cmd.none

        | SelectionItemChanged args ->
            let updated =
                if args.AddedItems.Count > 0 then
                    let node = args.AddedItems[0] :?> EditableNode
                    let modelNode = findNodes (fun n -> n = node) model.Nodes |> Seq.tryExactlyOne
                    { model with Selected = modelNode }
                (*  TODO I feel the proper way to handle this event would include the following, but that breaks selection of nodes on the top level.
                    For some reason a second event removing the selection is triggered for them immediately after selection.
                    Why is that happening? *)
                (*else if args.RemovedItems.Count > 0 then
                    let node = args.RemovedItems[0] :?> EditableNode

                    if model.Selected.IsSome && node = model.Selected.Value then
                        { model with Selected = None }
                    else
                        model*)
                else
                    model

            updated, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    /// Functions for leaf nodes for adding a node to a list.
    module AddLeaf =
        let private prefix = "addTo!"

        /// Appends an Add leaf Node (referencing the parentNode or the model if None) to the Node list.
        let appendTo list (parentNode: EditableNode option) =
            let parentName = parentNode |> Option.map(_.Name) |> Option.defaultValue ""
            list @ [ leaf(prefix + parentName) ]

        /// Identifies an Add leaf Node.
        let is (node: EditableNode) = node.Name.StartsWith(prefix)

        /// Retrieves the parent Node Name from the Node Name of an Add leaf Node.
        let getParentNodeName (node: EditableNode) = node.Name.Substring(prefix.Length)

    let view () =
        Component(program) {
            let! model = Mvu.State

            let rec filter (nodes: EditableNode list) =
                nodes
                |> List.filter(fun node ->
                    node.Name.Contains(model.Filter, System.StringComparison.InvariantCultureIgnoreCase)
                    || filter(node.Children) |> List.isEmpty |> not)

            Dock() {
                (*  TODO feeding this builder with a transient source
                    (like you'd want to do for filtering or sorting the input nodes here)
                    will re-render the TreeView on every interaction. Can this be avoided?
                    Is there a more elegant (maybe even declarative) way to preserve tree node expansion?
                    Or is there a better way to filter or sort? *)
                TreeView(
                    AddLeaf.appendTo (model.Nodes |> filter) None,
                    (fun node ->
                        if AddLeaf.is node then
                            null
                        else
                            AddLeaf.appendTo (node.Children |> filter) (Some node)),
                    (fun node ->
                        HStack(5) {
                            if AddLeaf.is node then
                                Button("+", AddNodeTo(AddLeaf.getParentNodeName node))
                                    .tip(ToolTip("Add a node"))
                            else
                                EditableNodeView
                                    .view(node)
                                    .horizontalAlignment(HorizontalAlignment.Left)

                                Button("x", RemoveNode node).tip(ToolTip("Remove"))
                        })
                )
                    .onSelectionChanged(SelectionItemChanged)
                    .dock(Dock.Left)
                    (*  TODO This solution feels awkward because it requires XAML styles,
                        uses a TwoWay Binding against a mutable node model
                        and the name of the EditableNode.IsExpanded property is leaking out of this module.
                        Can either problem be avoided? *)
                    (*  Include styles binding Avalonia.Controls.TreeViewItem.IsExpanded to EditableNode.IsExpanded
                        to preserve tree node expansion on re-render, which is triggered by building the TreeView
                        from a new transient collection returned by the filter method above.

                        See https://github.com/AvaloniaUI/Avalonia/discussions/13903
                        and https://github.com/AvaloniaUI/Avalonia/discussions/12397 *)
                    .styles([ "avares://Gallery/Styles/EditableTreeView.xaml" ])

                (VStack() {
                    HStack() {
                        Label "Filter"
                        TextBox(model.Filter, FilterChanged)
                    }

                    if model.Selected.IsSome then
                        (*  TODO How to update this while or after editing the Selected node in the tree?
                            Updating this currently requires triggering SelectionItemChanged by clicking the node. *)
                        TextBlock(model.Selected.Value.Name + " selected").margin(5)
                })
                    .dock(Dock.Right)
            }
        }
