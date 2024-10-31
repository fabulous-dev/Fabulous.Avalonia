namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentSkewTransform =
    inherit IFabComponentTransform
    inherit IFabSkewTransform

[<AutoOpen>]
module ComponentSkewTransformBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        /// <param name="angleY">The AngleY to apply.</param>
        static member SkewTransform(angleX: float, angleY: float) =
            WidgetBuilder<unit, IFabComponentSkewTransform>(
                SkewTransform.WidgetKey,
                SkewTransform.AngleX.WithValue(angleX),
                SkewTransform.AngleY.WithValue(angleY)
            )

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        static member SkewTransform(angleX: float) =
            WidgetBuilder<unit, IFabComponentSkewTransform>(SkewTransform.WidgetKey, SkewTransform.AngleX.WithValue(angleX))

        /// <summary>Creates a SkewTransform widget.</summary>
        static member SkewTransform() =
            WidgetBuilder<unit, IFabComponentSkewTransform>(SkewTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
