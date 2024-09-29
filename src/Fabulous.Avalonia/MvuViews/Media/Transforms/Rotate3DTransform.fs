namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuRotate3DTransform =
    inherit IFabMvuTransform
    inherit IFabRotate3DTransform

[<AutoOpen>]
module Rotate3DTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Rotate3DTransform widget.</summary>
        /// <param name="angleX">The angle of rotation about the x-axis, in degrees.</param>
        /// <param name="angleY">The angle of rotation about the y-axis, in degrees.</param>
        /// <param name="angleZ">The angle of rotation about the z-axis, in degrees.</param>
        /// <param name="centerX">The x-coordinate of the rotation center point.</param>
        /// <param name="centerY">The y-coordinate of the rotation center point.</param>
        /// <param name="centerZ">The z-coordinate of the rotation center point.</param>
        /// <param name="depth">The distance between the plane of the screen and the rotated object.</param>
        static member Rotate3DTransform(angleX: float, angleY: float, angleZ: float, centerX: float, centerY: float, centerZ: float, depth: float) =
            WidgetBuilder<unit, IFabMvuRotate3DTransform>(
                Rotate3DTransform.WidgetKey,
                Rotate3DTransform.Angle.WithValue(struct (angleX, angleY, angleZ)),
                Rotate3DTransform.Center.WithValue(struct (centerX, centerY, centerZ)),
                Rotate3DTransform.Depth.WithValue(depth)
            )

type Rotate3DTransformModifiers =
    /// <summary>Link a ViewRef to access the direct Rotate3DTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuRotate3DTransform>, value: ViewRef<Rotate3DTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
