namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuSkewTransform =
    inherit IFabMvuTransform
    inherit IFabSkewTransform

[<AutoOpen>]
module MvuSkewTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        /// <param name="angleY">The AngleY to apply.</param>
        static member SkewTransform(angleX: float, angleY: float) =
            WidgetBuilder<'msg, IFabMvuSkewTransform>(SkewTransform.WidgetKey, SkewTransform.AngleX.WithValue(angleX), SkewTransform.AngleY.WithValue(angleY))

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        static member SkewTransform(angleX: float) =
            WidgetBuilder<'msg, IFabMvuSkewTransform>(SkewTransform.WidgetKey, SkewTransform.AngleX.WithValue(angleX))

        /// <summary>Creates a SkewTransform widget.</summary>
        static member SkewTransform() =
            WidgetBuilder<'msg, IFabMvuSkewTransform>(SkewTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
