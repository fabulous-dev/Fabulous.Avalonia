namespace RenderDemo

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module Transform3DPage =
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

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none


    let init () =
        { CenterX = 0.
          CenterY = 0.
          CenterZ = 0.
          AngleX = 0.
          AngleY = 0.
          AngleZ = 0. },
        []

    let update msg model =
        match msg with
        | CenterXChanged value -> { model with CenterX = value }, []
        | CenterYChanged value -> { model with CenterY = value }, []
        | CenterZChanged value -> { model with CenterZ = value }, []
        | AngleXChanged value -> { model with AngleX = value }, []
        | AngleYChanged value -> { model with AngleY = value }, []
        | AngleZChanged value -> { model with AngleZ = value }, []

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(
                Image(ImageSource.fromString "avares://RenderDemo/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
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
                        GradientStop(Colors.Red, 0.)
                        GradientStop(Colors.Blue, 1.)
                    }
                )
                .gridRow(0)
                .gridColumn(2)
                .zIndex(-2)
                .verticalAlignment(VerticalAlignment.Center)
                .renderTransform(Rotate3DTransform(model.AngleX, model.AngleY, model.AngleZ, model.CenterX, model.CenterY, model.CenterZ, 200.))

            TextBlock("Center X: ").gridRow(1)

            Slider(-100., 100., model.CenterX, CenterXChanged)
                .gridRow(1)
                .gridColumn(2)

            TextBlock("Center Y: ").gridRow(2)

            Slider(-100., 100., model.CenterY, CenterYChanged)
                .gridRow(2)
                .gridColumn(2)

            TextBlock("Center Z: ").gridRow(3)

            Slider(-100., 100., model.CenterZ, CenterZChanged)
                .gridRow(3)
                .gridColumn(2)

            TextBlock("Angle X: ").gridRow(4)

            Slider(-180., 180., model.AngleX, AngleXChanged)
                .gridRow(4)
                .gridColumn(2)

            TextBlock("Angle Y: ").gridRow(5)

            Slider(-180., 180., model.AngleY, AngleYChanged)
                .gridRow(5)
                .gridColumn(2)

            TextBlock("Angle Z: ").gridRow(6)

            Slider(-180., 180., model.AngleZ, AngleZChanged)
                .gridRow(6)
                .gridColumn(2)
        }
