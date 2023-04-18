namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module Panel =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view model =
        (Panel() {
            Rectangle()
                .fill(SolidColorBrush(Colors.Red))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Top)

            Rectangle()
                .fill(SolidColorBrush(Colors.Blue))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Right)

            Rectangle()
                .fill(SolidColorBrush(Colors.Green))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Bottom)

            Rectangle()
                .fill(SolidColorBrush(Colors.Orange))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Left)
        })
            .width(300.)
            .height(300.)

    let sample =
        { Name = "Panel"
          Description = "Panel is the base class for controls that can contain multiple children like DockPanel or StackPanel."
          Program = Helper.createProgram init update view }
