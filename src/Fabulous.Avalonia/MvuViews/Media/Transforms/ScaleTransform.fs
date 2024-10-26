namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuScaleTransform =
    inherit IFabMvuTransform
    inherit IFabScaleTransform

[<AutoOpen>]
module MvuScaleTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        /// <param name="scaleY">The Y scale factor.</param>
        static member ScaleTransform(scaleX: float, scaleY: float) =
            WidgetBuilder<unit, IFabMvuScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleX.WithValue(scaleX),
                ScaleTransform.ScaleY.WithValue(scaleY)
            )

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        static member ScaleTransform(scaleX: float) =
            WidgetBuilder<unit, IFabMvuScaleTransform>(ScaleTransform.WidgetKey, ScaleTransform.ScaleX.WithValue(scaleX))

        /// <summary>Creates a ScaleTransform widget.</summary>
        static member ScaleTransform() =
            WidgetBuilder<unit, IFabMvuScaleTransform>(ScaleTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuScaleTransformModifiers =
    /// <summary>Link a ViewRef to access the direct ScaleTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuScaleTransform>, value: ViewRef<ScaleTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
