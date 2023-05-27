namespace Gallery.Pages

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ShapesPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model

    let view _ =
        VStack(spacing = 15.) {
            Rectangle()
                .size(100., 80.)
                .opacityMask(
                    LinearGradientBrush() {
                        GradientStop(0., Colors.Black)
                        GradientStop(1., Colors.Transparent)
                    }
                )
                .fill(SolidColorBrush(Colors.Blue))

            Ellipse()
                .fill(SolidColorBrush(Colors.Red))
                .size(100., 100.)
                .opacityMask(
                    LinearGradientBrush() {
                        GradientStop(0., Colors.Black)
                        GradientStop(1., Colors.Transparent)
                    }
                )

            Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                .fill(SolidColorBrush(Colors.Orange))

            Path(
                PathGeometry(FillRule.NonZero) {
                    (PathFigure(Point(0., 0.)) {
                        QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
                        QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
                        LineSegment(Point(50., 0.))
                        LineSegment(Point(50., 50.))
                    })
                        .isClosed(true)
                }
            )
                .fill(SolidColorBrush(Colors.OrangeRed))

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
        }
