namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabScaleTransform =
    inherit IFabTransform

module ScaleTransform =

    let WidgetKey = Widgets.register<ScaleTransform> ()

    let ScaleX =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleXProperty

    let ScaleY =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleYProperty


[<AutoOpen>]
module ScaleTransformBuilders =
    type Fabulous.Avalonia.View with

        static member ScaleTransform(scaleX: float, scaleY: float) =
            WidgetBuilder<'msg, IFabScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleX.WithValue(scaleX),
                ScaleTransform.ScaleY.WithValue(scaleY)
            )
