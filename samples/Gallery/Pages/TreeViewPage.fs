namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TreeViewPage =
    type Node = { Name: string; Children: Node list }

    type Model = { Nodes: Node list }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let init () =
        { Nodes =
            [ { Name = "Animals"
                Children =
                  [ { Name = "Mammals"
                      Children =
                        [ { Name = "Lion"; Children = [] }
                          { Name = "Cat"; Children = [] }
                          { Name = "Zebra"; Children = [] } ] } ] }

              { Name = "Birds"
                Children =
                  [ { Name = "Eagle"; Children = [] }
                    { Name = "Sparrow"; Children = [] }
                    { Name = "Dove"; Children = [] }
                    { Name = "Owl"; Children = [] }
                    { Name = "Parrot"; Children = [] }
                    { Name = "Pigeon"; Children = [] } ] } ] },
        []

    let update msg model =
        match msg with
        | SelectionItemChanged args -> model, Cmd.none

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
                        Border(TextBlock(x.Name))
                            .background(Brushes.Gray)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .borderThickness(1.0)
                            .cornerRadius(5.0)
                            .padding(15.0, 3.0))
                )
                    .onSelectionChanged(SelectionItemChanged)
            }
        }
