namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuRotateTransform =
    inherit IFabMvuTransform
    inherit IFabRotateTransform

[<AutoOpen>]
module MvuRotateTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="angle">The Angle to apply.</param>
        /// <param name="centerX">The X coordinate of the center of rotation.</param>
        /// <param name="centerY">The Y coordinate of the center of rotation.</param>
        static member RotateTransform(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabMvuRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="angle">The Angle to apply.</param>
        static member RotateTransform(angle: float) =
            WidgetBuilder<'msg, IFabMvuRotateTransform>(RotateTransform.WidgetKey, RotateTransform.Angle.WithValue(angle))

        /// <summary>Creates a RotateTransform widget.</summary>
        static member RotateTransform() =
            WidgetBuilder<'msg, IFabMvuRotateTransform>(RotateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
