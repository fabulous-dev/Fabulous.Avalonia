namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module UniformGrid =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack() {
            (UniformGrid(rows = 1) {
                Button("No", Id)
                    .gridColumn(0)
                    .fontSize(18)
                    .margin(5)
                    .padding(6, 3)

                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)

                Button("Yes, Absolutely", Id)
                    .gridColumn(1)
                    .margin(5)
                    .padding(6, 3)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)

                Button("Maybe", Id)
                    .gridColumn(2)
                    .margin(5)
                    .padding(6, 3)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)
            })
                .margin(10.)
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)

            UniformGrid() {
                Border(TextBlock("1"))
                    .background(SolidColorBrush(Colors.AliceBlue))
                    .gridColumnSpan(2)

                Border(TextBlock("2")).background(SolidColorBrush(Colors.Cornsilk))

                Border(TextBlock("3")).background(SolidColorBrush(Colors.DarkSalmon))

                Border(TextBlock("4"))
                    .background(SolidColorBrush(Colors.Gainsboro))
                    .gridRowSpan(2)

                Border(TextBlock("5")).background(SolidColorBrush(Colors.LightBlue))

                Border(TextBlock("6")).background(SolidColorBrush(Colors.MediumAquamarine))

                Border(TextBlock("7")).background(SolidColorBrush(Colors.MistyRose))
            }
        }

    let sample =
        { Name = "UniformGrid"
          Description =
            "The UniformGrid control is a responsive layout control which arranges items in a evenly-spaced set of rows or columns to fill the total available display space. Each cell in the grid, by default, will be the same size."
          Program = Helper.createProgram init update view }
