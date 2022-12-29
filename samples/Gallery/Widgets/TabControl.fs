namespace Gallery

open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TabControl =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model


    let view _ =
        (TabControl(Dock.Top) {
            TabItem(
                "Circle",
                Ellipse()
                    .size(100.0, 100.0)
                    .fill(SolidColorBrush(Colors.Red))
                    .horizontalAlignment (HorizontalAlignment.Left)
            )

            TabItem(
                TextBlock("Triangle").verticalAlignment (VerticalAlignment.Center),
                VStack() {
                    TextBlock("I am in the triangle page")
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment (VerticalAlignment.Center)

                    Polygon([ Point(40.0, 10.0); Point(70.0, 80.0); Point(10.0, 50.0) ])
                        .fill(SolidColorBrush(Colors.AliceBlue))
                        .stroke(SolidColorBrush(Colors.Green))
                        .strokeThickness (5.0)
                }
            )

            TabItem(
                TextBlock("Square").verticalAlignment (VerticalAlignment.Center),
                HStack() {
                    TextBlock("Square : ")
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment (VerticalAlignment.Center)

                    Rectangle(0., 0.).size(63., 41.).fill (SolidColorBrush(Colors.Blue))
                }
            )
        })
            .horizontalContentAlignment(HorizontalAlignment.Center)
            .verticalContentAlignment (VerticalAlignment.Center)

    let sample =
        { Name = "TabControl"
          Description =
            "The TabControl allows us to switch between different pages by means of tabs like the tabs in web navigators or the ribbon menu (which uses tabs) in Word Office for instance."
          Program = Helper.createProgram init update view }
