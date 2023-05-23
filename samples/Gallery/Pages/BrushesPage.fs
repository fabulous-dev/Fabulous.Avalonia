namespace Gallery.Pages

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module BrushesPage =
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model

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
                .canvasTop(410.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    VisualBrush(
                        (Canvas() {
                            Rectangle()
                                .canvasLeft(0.0)
                                .canvasTop(0.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Maroon))

                            Rectangle()
                                .canvasLeft(10.0)
                                .canvasTop(0.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Green))

                            Rectangle()
                                .canvasLeft(0.0)
                                .canvasTop(10.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Blue))

                            Rectangle()
                                .canvasLeft(10.0)
                                .canvasTop(10.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Yellow))
                        })
                            .width(20.0)
                            .height(20.0)

                    )
                        .stretch(Stretch.None)
                        .tileMode(TileMode.Tile)
                        .sourceRect(RelativeRect(0., 0., 20., 20., RelativeUnit.Absolute))
                        .destinationRect(RelativeRect(0., 0., 20., 20., RelativeUnit.Absolute))
                        .transform(
                            TransformGroup() {
                                ScaleTransform(2., 2.)
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(5., 5.)
                            }
                        )
                )

            TextBlock("scale(2), skewX(45) on pattern")
                .canvasLeft(20.0)
                .canvasTop(460.0)
                .fontSize(30.0)

        })
            .width(480.0)
            .height(360.0)
