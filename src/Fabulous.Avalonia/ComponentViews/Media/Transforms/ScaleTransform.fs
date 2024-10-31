namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentScaleTransform =
    inherit IFabComponentTransform
    inherit IFabScaleTransform

[<AutoOpen>]
module ComponentScaleTransformBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        /// <param name="scaleY">The Y scale factor.</param>
        static member ScaleTransform(scaleX: float, scaleY: float) =
            WidgetBuilder<unit, IFabComponentScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleX.WithValue(scaleX),
                ScaleTransform.ScaleY.WithValue(scaleY)
            )

        /// <summary>Creates a ScaleTransform widget.</summary>
        /// <param name="scaleX">The X scale factor.</param>
        static member ScaleTransform(scaleX: float) =
            WidgetBuilder<unit, IFabComponentScaleTransform>(ScaleTransform.WidgetKey, ScaleTransform.ScaleX.WithValue(scaleX))

        /// <summary>Creates a ScaleTransform widget.</summary>
        static member ScaleTransform() =
            WidgetBuilder<unit, IFabComponentScaleTransform>(ScaleTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
