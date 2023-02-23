namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabRotateTransform =
    inherit IFabTransform

module RotateTransform =

    let WidgetKey = Widgets.register<RotateTransform>()

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

        static member RotateTransform(angle: float) =
            WidgetBuilder<'msg, IFabRotateTransform>(RotateTransform.WidgetKey, RotateTransform.Angle.WithValue(angle))

        static member RotateTransform() =
            WidgetBuilder<'msg, IFabRotateTransform>(RotateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
