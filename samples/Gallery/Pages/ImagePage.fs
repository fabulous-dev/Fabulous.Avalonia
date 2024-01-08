namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ImagePage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view _ =
        VStack(spacing = 15.) {
            Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.Uniform)
                .size(200., 200.)

            Image(Stretch.Uniform, CroppedBitmap("avares://Gallery/Assets/Icons/fsharp-icon.png", PixelRect(0, 0, 320, 320)))
                .size(200., 200.)

            Image(
                Stretch.Uniform,
                DrawingImage(
                    GeometryDrawing(
                        PathGeometry(FillRule.NonZero) {
                            PathFigure(Point(0., 0)) {
                                QuadraticBezierSegment(Point(50., 0.), Point(50, -50.))
                                QuadraticBezierSegment(Point(100., -50.), Point(100, 0.))
                                LineSegment(Point(50., 0.))
                                LineSegment(Point(50., 50.))
                            }
                        },
                        SolidColorBrush(Colors.Blue)
                    )
                        .pen(Pen(SolidColorBrush(Colors.Red), 0.))
                )
            )
                .size(200., 200.)
        }
