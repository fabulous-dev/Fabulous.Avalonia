namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module LayoutTransformControlPage =
    type Model =
        { Min: float; Max: float; Angle: float }

    type Msg = SliderValueChanged of float

    let init () = { Min = 0.; Max = 360.; Angle = 0. }

    let update msg model =
        match msg with
        | SliderValueChanged value -> { model with Angle = value }

    let view model =
        VStack(16.) {
            (VStack(16.) {
                HStack() {
                    TextBlock("Rotation: ")
                    TextBlock($"{model.Angle}")
                }

                Slider(model.Min, model.Max, model.Angle, SliderValueChanged).width(200.)
            })
                .margin(16.)
                .centerHorizontal()

            (Grid(coldefs = [ Pixel(24.); Auto; Pixel(24.) ], rowdefs = [ Pixel(24.); Auto; Pixel(24.) ]) {
                Border().background(SolidColorBrush(Colors.Red)).gridColumn(1).gridRow(0)
                Border().background(SolidColorBrush(Colors.Green)).gridColumn(0).gridRow(1)
                Border().background(SolidColorBrush(Colors.Yellow)).gridColumn(2).gridRow(1)
                Border().background(SolidColorBrush(Colors.Blue)).gridColumn(1).gridRow(2)

                LayoutTransformControl(Image(ImageSource.fromString("avares://Gallery/Assets/Icons/fabulous-icon.png")))
                    .layoutTransform(RotateTransform(model.Angle, 0., 0))
                    .gridColumn(1)
                    .gridRow(1)
            })
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)
        }
