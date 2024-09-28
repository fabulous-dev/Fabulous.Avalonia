namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia

type IFabComponentEllipseGeometry =
    inherit IFabComponentGeometry
    inherit IFabEllipseGeometry

[<AutoOpen>]
module EllipseGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a EllipseGeometry widget.</summary>
        /// <param name="radiusX">The X radius of the ellipse.</param>
        /// <param name="radiusY">The Y radius of the ellipse.</param>
        static member EllipseGeometry(radiusX: float, radiusY: float) =
            WidgetBuilder<unit, IFabComponentEllipseGeometry>(
                EllipseGeometry.WidgetKey,
                EllipseGeometry.RadiusX.WithValue(radiusX),
                EllipseGeometry.RadiusY.WithValue(radiusY)
            )
