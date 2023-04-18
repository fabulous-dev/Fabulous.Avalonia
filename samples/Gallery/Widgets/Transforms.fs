namespace Gallery

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module Transforms =
    type Model =
        { CenterX: float
          CenterY: float
          CenterZ: float
          AngleX: float
          AngleY: float
          AngleZ: float }

    type Msg =
        | CenterXChanged of float
        | CenterYChanged of float
        | CenterZChanged of float
        | AngleXChanged of float
        | AngleYChanged of float
        | AngleZChanged of float


    let init () =
        { CenterX = 0.
          CenterY = 0.
          CenterZ = 0.
          AngleX = 0.
          AngleY = 0.
          AngleZ = 0. }

    let update msg model =
        match msg with
        | CenterXChanged value -> { model with CenterX = value }
        | CenterYChanged value -> { model with CenterY = value }
        | CenterZChanged value -> { model with CenterZ = value }
        | AngleXChanged value -> { model with AngleX = value }
        | AngleYChanged value -> { model with AngleY = value }
        | AngleZChanged value -> { model with AngleZ = value }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(
                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .margin(5)
            )
            .size(200., 200.)
            .borderThickness(2.)
            .borderBrush(SolidColorBrush(Colors.Black))

    let view model =
        Grid(coldefs = [ Auto; Star ], rowdefs = [ Star; Auto; Auto; Auto; Auto; Auto; Auto ]) {
            Border()
                .style(borderTestStyle)
                .background(
                    LinearGradientBrush(Point(0., 0.), Point(0., 1.)) {
                        GradientStop(0., Colors.Red)
                        GradientStop(1., Colors.Blue)
                    }
                )
                .gridRow(0)
                .gridColumn(2)
                .zIndex(-2)
                .verticalAlignment(VerticalAlignment.Center)
                .renderTransform(Rotate3DTransform(model.AngleX, model.AngleY, model.AngleZ, model.CenterX, model.CenterY, model.CenterZ, 200.))

            TextBlock("Center X: ").gridRow(1)

            Slider(model.CenterX, CenterXChanged)
                .gridRow(1)
                .gridColumn(2)
                .minimum(-100.)
                .maximum(100.)

            TextBlock("Center Y: ").gridRow(2)

            Slider(model.CenterY, CenterYChanged)
                .gridRow(2)
                .gridColumn(2)
                .minimum(-100.)
                .maximum(100.)

            TextBlock("Center Z: ").gridRow(3)

            Slider(model.CenterZ, CenterZChanged)
                .gridRow(3)
                .gridColumn(2)
                .minimum(-100.)
                .maximum(100.)

            TextBlock("Angle X: ").gridRow(4)

            Slider(model.AngleX, AngleXChanged)
                .gridRow(4)
                .gridColumn(2)
                .minimum(-180.)
                .maximum(180.)

            TextBlock("Angle Y: ").gridRow(5)

            Slider(model.AngleY, AngleYChanged)
                .gridRow(5)
                .gridColumn(2)
                .minimum(-180.)
                .maximum(180.)

            TextBlock("Angle Z: ").gridRow(6)

            Slider(model.AngleZ, AngleZChanged)
                .gridRow(6)
                .gridColumn(2)
                .minimum(-180.)
                .maximum(180.)
        }

    let sample =
        { Name = "Transforms"
          Description = "How to use transforms"
          Program = Helper.createProgram init update view }
