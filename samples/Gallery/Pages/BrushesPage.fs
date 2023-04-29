namespace Gallery.Pages

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module BrushesPage =
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    let init () = { Nothing = true }

    let update msg model =
        match msg with
        | DoNothing -> model

    let createDrawing () =
        DrawingBrush(
            GeometryDrawing(
                GeometryGroup(FillRule.NonZero) {
                    RectangleGeometry(Rect(50., 25., 25., 25.))
                    RectangleGeometry(Rect(50., 25., 25., 25.))
                },
                SolidColorBrush(Colors.Yellow)
            )
                .pen(
                    Pen(
                        LinearGradientBrush() {
                            GradientStop(0., Colors.Blue)
                            GradientStop(1., Colors.Black)
                        },
                        5.
                    )
                )
        )

    let view _ =
        (Canvas() {
            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(20.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    (LinearGradientBrush(Point(0., 0.), Point(410., 0.0), RelativeUnit.Absolute) {
                        GradientStop(0., Colors.Blue)
                        GradientStop(0.5, Colors.Green)
                        GradientStop(1., Colors.Lime)
                    })
                        .transform(
                            TransformGroup() {
                                ScaleTransform(0.5)
                                SkewTransform()
                                RotateTransform()
                                TranslateTransform(5., 15.)
                            }
                        )
                )

            TextBlock("scale(0.5) on gradient")
                .canvasLeft(20.0)
                .canvasTop(70.0)
                .fontSize(30.0)

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(110.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    (RadialGradientBrush(Point(0., 0.), Point(0., 0.), RelativeUnit.Absolute) {
                        GradientStop(0., Colors.Black)
                        GradientStop(1., Colors.Orange)
                    })
                        .radius(0.13636364)
                        .transform(
                            TransformGroup() {
                                ScaleTransform()
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(240., 45.)
                            }
                        )
                )

            TextBlock("skewX(45) on gradient")
                .canvasLeft(20.0)
                .canvasTop(160.0)
                .fontSize(30.0)

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(210.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    ImageBrush(ImageSource.fromString("avares://Gallery/Assets/Icons/fabulous-icon.png"))
                        .tileMode(TileMode.Tile)
                        .sourceRect(Point(0., 0.), Size(20., 20.), RelativeUnit.Absolute)
                        .destinationRect(Point(0., 0.), Size(20., 20.), RelativeUnit.Absolute)
                        .stretch(Stretch.None)
                        .transform(
                            TransformGroup() {
                                ScaleTransform(2., 2.)
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(5., 5.)
                            }
                        )
                )

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(260.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    ConicGradientBrush(Point(30., 30.), RelativeUnit.Absolute, 90.) {
                        GradientStop(0., Colors.Red)
                        GradientStop(0.25, Colors.Blue)
                        GradientStop(0.5, Colors.Brown)
                        GradientStop(0.75, Colors.Green)
                        GradientStop(0.1, Colors.Purple)
                    }
                )

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(310.0)
                .width(440.0)
                .height(50.0)
                .fill(createDrawing())
        })
            .width(480.0)
            .height(360.0)