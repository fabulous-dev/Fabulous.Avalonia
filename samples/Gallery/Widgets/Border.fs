namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Border =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 4) {
            TextBlock("A control which decorates a child with a border and background")

            (VStack(16.) {
                Border(TextBlock("Border"))
                    .background(SolidColorBrush(Colors.ForestGreen))
                    .borderBrush(SolidColorBrush(Colors.BlueViolet))
                    .borderThickness(2.)
                    .padding(16.)

            })
                .margin(0., 16.)
                .horizontalAlignment(HorizontalAlignment.Center)


            Border(TextBlock("Border and Background"))
                .background(SolidColorBrush(Colors.ForestGreen))
                .borderBrush(SolidColorBrush(Colors.BlueViolet))
                .borderThickness(4.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(TextBlock("Rounded Corners"))
                .borderBrush(SolidColorBrush(Colors.BlueViolet))
                .borderThickness(4.)
                .cornerRadius(8.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(TextBlock("Rounded Corners"))
                .background(SolidColorBrush(Colors.Magenta))
                .cornerRadius(8.)
                .padding(16.)
                .horizontalAlignment(HorizontalAlignment.Center)

            Border(Image(ImageSource.fromString("avares://Gallery/Assets/Icons/fabulous-icon.png")))
                .width(100.)
                .height(100.)
                .borderThickness(0.)
                .background(SolidColorBrush(Colors.Green))
                .cornerRadius(100.)
                .clipToBounds(true)
        }

    let sample =
        { Name = "Border"
          Description = "Control that displays a border around another control"
          Program = Helper.createProgram init update view }
