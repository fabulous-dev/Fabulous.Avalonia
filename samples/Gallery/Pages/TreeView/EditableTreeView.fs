namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module EditableNodeView =
    type Node(name, children) =

        let mutable _name: string = name

        member this.Name
            with get () = _name
            and set value = _name <- value

        member this.Children = children

    type Model = { Node: Node }

    type Msg = NameChanged of string

    let init (node: Node) = { Node = node }

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
        Component(program, node) { TextBox(node.Name, NameChanged) }

module EditableTreeView =

    type Model =
        { Nodes: EditableNodeView.Node list
          Selected: EditableNodeView.Node option }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let branch name (children: EditableNodeView.Node list) = EditableNodeView.Node(name, children)
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

        { Nodes = nodes; Selected = None }, []

    let rec findNodes (predicate: EditableNodeView.Node -> bool) (nodes: EditableNodeView.Node list) =
        let rec matches (node: EditableNodeView.Node) =
            if predicate node then
                seq { node }
            else
                node.Children |> Seq.collect matches

        nodes |> Seq.collect matches

    let update msg model =
        match msg with
        | SelectionItemChanged args ->
            let node = args.AddedItems[0] :?> EditableNodeView.Node
            let modelNode = findNodes (fun n -> n = node) model.Nodes |> Seq.tryExactlyOne
            { model with Selected = modelNode }, Cmd.none

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

    let view () =
        Component(program) {
            let! model = Mvu.State

            HStack() {
                TreeView(
                    model.Nodes,
                    (_.Children),
                    (fun node ->
                        EditableNodeView
                            .view(node)
                            .horizontalAlignment(HorizontalAlignment.Left))
                )
                    .onSelectionChanged(SelectionItemChanged)

                if model.Selected.IsSome then
                    TextBlock(model.Selected.Value.Name + " selected")
            }
        }
