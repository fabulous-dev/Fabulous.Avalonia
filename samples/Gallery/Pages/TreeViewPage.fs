namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TreeViewPage =
    type Node =
        { Name: string
          Children: Node list
          Clicked: int }

    type Model = { Nodes: Node list }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let branch name chidren =
        { Name = name
          Children = chidren
          Clicked = 0 }

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

        { Nodes = nodes }, []

    let rec updateNodeClicked name clicked nodes =
        nodes
        |> List.map(fun node ->
            if node.Name = name then
                { node with
                    Clicked = node.Clicked + clicked }
            else
                { node with
                    Children = updateNodeClicked name clicked node.Children })

    let update msg model =
        match msg with
        | SelectionItemChanged args ->
            if args.AddedItems.Count > 0 then
                let node = args.AddedItems[0] :?> Node
                let updatedNodes = updateNodeClicked node.Name 1 model.Nodes
                { model with Nodes = updatedNodes }, Cmd.none
            else
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
                        Border(TextBlock($"{x.Clicked} {x.Name}"))
                            .background(Brushes.Gray)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .borderThickness(1.0)
                            .cornerRadius(5.0)
                            .padding(15.0, 3.0))
                )
                    .onSelectionChanged(SelectionItemChanged)
            }
        }
