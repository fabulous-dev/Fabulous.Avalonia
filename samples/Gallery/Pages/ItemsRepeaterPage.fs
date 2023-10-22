namespace Gallery

open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open System.Collections.ObjectModel
open Gallery

open type Fabulous.Avalonia.View

module ItemsRepeaterPage =
    type Crockery = { Title: string; Number: int }

    type Model =
        { Items: ObservableCollection<Crockery> }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Items =
            ObservableCollection<Crockery>(
                [ { Title = "dinner plate"; Number = 12 }
                  { Title = "side plate"; Number = 12 }
                  { Title = "breakfast bowl"; Number = 6 }
                  { Title = "cup"; Number = 10 }
                  { Title = "saucer"; Number = 10 }
                  { Title = "mug"; Number = 6 }
                  { Title = "milk jug"; Number = 1 }
                  { Title = "sugar bowl"; Number = 1 }
                  { Title = "teapot"; Number = 1 }
                  { Title = "coffee pot"; Number = 1 }
                  { Title = "serving bowl"; Number = 2 }
                  { Title = "serving plate"; Number = 2 }
                  { Title = "serving spoon"; Number = 2 } ]
            ) },
        []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view model =
        VStack() {
            TextBlock("List of crockery:")

            let stackLayout () =
                let x = StackLayout()
                x.Spacing <- 40.0
                x.Orientation <- Orientation.Horizontal
                x

            ScrollViewer(
                ItemsRepeater(
                    model.Items,
                    fun x ->
                        Border(
                            HStack() {
                                TextBlock(x.Title)

                                TextBlock($"{x.Number}")
                                    .margin(Thickness(5, 0, 0, 0))
                                    .fontWeight(FontWeight.Bold)
                            }
                        )
                            .margin(Thickness(0, 10, 0, 0))
                            .cornerRadius(5)
                            .borderBrush(Brushes.Blue)
                            .borderThickness(Thickness(1))
                            .padding(Thickness(5))

                )
                    .layout(stackLayout())
                    .margin(Thickness(0, 20, 0, 20))
            )
                .horizontalScrollBarVisibility(ScrollBarVisibility.Auto)
        }
