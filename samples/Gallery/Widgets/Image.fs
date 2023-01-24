namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Image =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 15.) {
            Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.Uniform)
                .size(200., 200.)

            Image(Stretch.Uniform, CroppedBitmap(ImageSource.fromString "avares://Gallery/Assets/Icons/fsharp-icon.png", PixelRect(0, 0, 320, 320)))
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
                        Pen(SolidColorBrush(Colors.Red), 0.),
                        SolidColorBrush(Colors.Blue)
                    )
                )
            )
                .size(200., 200.)
        }

    let sample =
        { Name = "Image"
          Description =
            "Binding onto an Image control's Source property with a string must be done using a binding converter that will convert the string to an IBitmap."
          Program = Helper.createProgram init update view }
