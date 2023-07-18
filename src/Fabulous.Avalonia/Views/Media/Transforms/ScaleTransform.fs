namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabScaleTransform =
    inherit IFabTransform

module ScaleTransform =

    let WidgetKey = Widgets.register<ScaleTransform>()

    let ScaleX =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleXProperty

    let ScaleY =
        Attributes.defineAvaloniaPropertyWithEquality ScaleTransform.ScaleYProperty

[<AutoOpen>]
module ScaleTransformBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        /// <param name="scaleY">The Y scale factor.</param>
        static member ScaleTransform(scaleX: float, scaleY: float) =
            WidgetBuilder<'msg, IFabScaleTransform>(ScaleTransform.WidgetKey, ScaleTransform.ScaleX.WithValue(scaleX), ScaleTransform.ScaleY.WithValue(scaleY))

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        static member ScaleTransform(scaleX: float) =
            WidgetBuilder<'msg, IFabScaleTransform>(ScaleTransform.WidgetKey, ScaleTransform.ScaleX.WithValue(scaleX))

        /// <summary>Creates a ScaleTransform widget.</summary>
        static member ScaleTransform() =
            WidgetBuilder<'msg, IFabScaleTransform>(ScaleTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
