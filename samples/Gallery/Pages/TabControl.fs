namespace Gallery

open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TabControlPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    let init () = { Nothing = true }

    let update msg model =
        match msg with
        | DoNothing -> model

    let view _ =
        (TabControl(Dock.Top) {
            TabItem(
                "Circle",
                Ellipse()
                    .size(100.0, 100.0)
                    .fill(SolidColorBrush(Colors.Red))
                    .horizontalAlignment(HorizontalAlignment.Left)
            )

            TabItem(
                TextBlock("Triangle").verticalAlignment(VerticalAlignment.Center),
                VStack() {
                    TextBlock("I am in the triangle page")
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment(VerticalAlignment.Center)

                    Polygon([ Point(40.0, 10.0); Point(70.0, 80.0); Point(10.0, 50.0) ])
                        .fill(SolidColorBrush(Colors.AliceBlue))
                        .stroke(SolidColorBrush(Colors.Green))
                        .strokeThickness(5.0)
                }
            )

            TabItem(
                TextBlock("Square").verticalAlignment(VerticalAlignment.Center),
                HStack() {
                    TextBlock("Square : ")
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment(VerticalAlignment.Center)

                    Rectangle().size(63., 41.).fill(SolidColorBrush(Colors.Blue))
                }
            )
        })
            .horizontalContentAlignment(HorizontalAlignment.Center)
            .verticalContentAlignment(VerticalAlignment.Center)
