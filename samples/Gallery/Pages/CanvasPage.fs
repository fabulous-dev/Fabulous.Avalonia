namespace Gallery.Pages

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CanvasPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    let init () = { Nothing = true }

    let update msg model =
        match msg with
        | DoNothing -> model

    let view _ =
        VStack(spacing = 15.) {
            TextBlock("A panel which lays out its children by explicit coordinates")

            (Canvas() {
                Rectangle(10., 10.)
                    .size(63., 41.)
                    .fill(SolidColorBrush(Colors.Blue))
                    .canvasLeft(40.)
                    .canvasTop(31.)
                    .opacityMask(
                        LinearGradientBrush(RelativePoint.Center, RelativePoint.BottomRight) {
                            GradientStop(0., Colors.Black)
                            GradientStop(1., Colors.Transparent)
                        }
                    )

                Rectangle(10., 5.)
                    .size(40., 20.)
                    .fill(SolidColorBrush(Color.ToHsv(byte 240., byte 83., byte 73., byte 90.).ToRgb()))
                    .stroke(SolidColorBrush(Color.ToHsl(byte 5., byte 85., byte 85.).ToRgb()))
                    .strokeThickness(2.)
                    .canvasLeft(150.)
                    .canvasTop(10.)

                Ellipse()
                    .size(58., 58.)
                    .fill(SolidColorBrush(Colors.Green))
                    .canvasLeft(88.)
                    .canvasTop(100.)

                Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                    .fill(SolidColorBrush(Colors.Orange))
                    .canvasLeft(30.)
                    .canvasTop(250.)


                Path(
                    PathGeometry(FillRule.NonZero) {
                        PathFigure(Point(0., 0.)) {
                            QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
                            QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
                            LineSegment(Point(50., 0.))
                            LineSegment(Point(50., 50.))

                        }
                    }
                )
                    .fill(SolidColorBrush(Colors.OrangeRed))
                    .canvasLeft(180.)
                    .canvasTop(250.)


                Line(Point(120., 185.), Point(30., 115.))
                    .stroke(SolidColorBrush(Colors.Red))
                    .strokeThickness(2.)

                Polygon(
                    [ Point(75., 0.)
                      Point(120., 120.)
                      Point(0., 45.)
                      Point(150., 45.)
                      Point(30., 120.) ]
                )
                    .stroke(SolidColorBrush(Colors.DarkBlue))
                    .strokeThickness(1.)
                    .fill(SolidColorBrush(Colors.Violet))
                    .canvasLeft(150.)
                    .canvasTop(31.)

                Polyline(
                    [ Point(0., 0.)
                      Point(65., 0.)
                      Point(78., -26.)
                      Point(91., 39.)
                      Point(104., -39.)
                      Point(117., 13.)
                      Point(130., 0.)
                      Point(195., 0.) ]
                )
                    .stroke(SolidColorBrush(Colors.Brown))
                    .canvasLeft(30.)
                    .canvasTop(350.)
            })
                .background(SolidColorBrush(Colors.Yellow))
                .size(300., 400.)

        }
