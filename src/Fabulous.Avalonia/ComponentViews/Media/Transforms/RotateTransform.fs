namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentRotateTransform =
    inherit IFabComponentTransform
    inherit IFabRotateTransform

[<AutoOpen>]
module ComponentRotateTransformBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="angle">The Angle to apply.</param>
        /// <param name="centerX">The X coordinate of the center of rotation.</param>
        /// <param name="centerY">The Y coordinate of the center of rotation.</param>
        static member RotateTransform(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<unit, IFabComponentRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="angle">The Angle to apply.</param>
        static member RotateTransform(angle: float) =
            WidgetBuilder<unit, IFabComponentRotateTransform>(RotateTransform.WidgetKey, RotateTransform.Angle.WithValue(angle))

        /// <summary>Creates a RotateTransform widget.</summary>
        static member RotateTransform() =
            WidgetBuilder<unit, IFabComponentRotateTransform>(RotateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentRotateTransformTransformModifiers =
    /// <summary>Link a ViewRef to access the direct RotateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentRotateTransform>, value: ViewRef<RotateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))