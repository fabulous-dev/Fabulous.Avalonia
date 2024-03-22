namespace Gallery

open System.Collections.ObjectModel
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TreeViewPage =
    type Node(name, children) =
        let mutable _clicked = 0

        member this.Name = name
        member this.Children = children

        member this.Clicked
            with get () = _clicked
            and set value = _clicked <- value

    type Model = { Nodes: ObservableCollection<Node> }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let branch name (children: Node list) =
        Node(name, ObservableCollection<Node>(children))

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
                  [ branch "pyramid-building terrestrial" [ leaf "Camel"; leaf "Lama"; leaf "Alpaca" ]
                    branch "extra-terrestrial" [ leaf "Alf"; leaf "E.T."; leaf "Klaatu" ] ] ]

        { Nodes = ObservableCollection<Node>(nodes) }, []

    let update msg model =
        match msg with
        | SelectionItemChanged args ->
            let node = args.AddedItems[0] :?> Node
            node.Clicked <- node.Clicked + 1
            model, Cmd.none

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

            VStack() {
                TreeView(
                    model.Nodes,
                    (_.Children),
                    (fun x ->
                        Border(
                            HStack(5) {
                                TextBlock(x.Clicked.ToString())
                                TextBlock(x.Name)
                            }
                        )
                            .background(Brushes.Gray)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .borderThickness(1.0)
                            .cornerRadius(5.0)
                            .padding(15.0, 3.0))
                )
                    .onSelectionChanged(SelectionItemChanged)
            }
        }
