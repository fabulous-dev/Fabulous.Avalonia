namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ViewBox =
    type Model = { Width: float; Height: float }

    type Msg =
        | HeightChanged of float
        | WidthChanged of float

    let init () = { Width = 300.; Height = 300. }

    let update msg model =
        match msg with
        | HeightChanged height -> { model with Height = height }
        | WidthChanged width -> { model with Width = width }

    let view model =
        Grid(coldefs = [ Pixel(300.); Star ], rowdefs = [ Pixel(300.) ]) {
            Border(
                ViewBox(Ellipse().size(50., 50.).fill(SolidColorBrush(Colors.CornflowerBlue)))
                    .size(model.Width, model.Height)
                    .stretch(Stretch.Uniform)
            )
                .borderBrush(SolidColorBrush(Colors.Black))
                .borderThickness(1.)
                .gridRow(0)
                .gridColumn(0)

            (VStack() {
                TextBlock($"Height: {model.Height}")
                Slider(model.Height, HeightChanged).minimum(0.).maximum(300.)
                TextBlock($"Width: {model.Width}")
                Slider(model.Width, WidthChanged).minimum(0.).maximum(300.)
            })
                .gridRow(0)
                .gridColumn(1)
        }


    let sample =
        { Name = "ViewBox"
          Description =
            "The ViewBox is a decorator control which scales its child. It can be used to scale its child to fit the available space. The ViewBox gives its child infinite space in the measure phase. It will constrain either or both sides when arranging it. This depends on the value of the Stretch. To restrict scaling direction one can use StretchDirection which can prevent up or down scaling."
          Program = Helper.createProgram init update view }
