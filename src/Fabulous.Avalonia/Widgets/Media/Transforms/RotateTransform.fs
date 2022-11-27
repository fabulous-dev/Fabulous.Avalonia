namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabRotateTransform =
    inherit IFabTransform

module RotateTransform =

    let WidgetKey = Widgets.register<RotateTransform> ()

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.AngleProperty

    let CenterX =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.CenterXProperty

    let CenterY =
        Attributes.defineAvaloniaPropertyWithEquality RotateTransform.CenterYProperty


[<AutoOpen>]
module RotateTransformBuilders =
    type Fabulous.Avalonia.View with

        static member RotateTransform(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )
