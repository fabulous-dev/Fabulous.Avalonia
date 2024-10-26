namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuEllipseGeometry =
    inherit IFabMvuGeometry
    inherit IFabEllipseGeometry

[<AutoOpen>]
module EllipseGeometryBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a EllipseGeometry widget.</summary>
        /// <param name="radiusX">The X radius of the ellipse.</param>
        /// <param name="radiusY">The Y radius of the ellipse.</param>
        static member EllipseGeometry(radiusX: float, radiusY: float) =
            WidgetBuilder<'msg, IFabMvuEllipseGeometry>(
                EllipseGeometry.WidgetKey,
                EllipseGeometry.RadiusX.WithValue(radiusX),
                EllipseGeometry.RadiusY.WithValue(radiusY)
            )
