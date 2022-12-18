namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabEllipseGeometry =
    inherit IFabGeometry

module EllipseGeometry =
    let WidgetKey = Widgets.register<EllipseGeometry>()

    let Rect =
        Attributes.defineAvaloniaPropertyWithEquality EllipseGeometry.RectProperty

    let RadiusX =
        Attributes.defineAvaloniaPropertyWithEquality EllipseGeometry.RadiusXProperty

    let RadiusY =
        Attributes.defineAvaloniaPropertyWithEquality EllipseGeometry.RadiusYProperty

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality EllipseGeometry.CenterProperty

[<AutoOpen>]
module EllipseGeometryBuilders =
    type Fabulous.Avalonia.View with

        static member EllipseGeometry(rect: Rect, radiusX: float, radiusY: float) =
            WidgetBuilder<'msg, IFabEllipseGeometry>(
                EllipseGeometry.WidgetKey,
                EllipseGeometry.Rect.WithValue(rect),
                EllipseGeometry.RadiusX.WithValue(radiusX),
                EllipseGeometry.RadiusY.WithValue(radiusY)
            )

[<Extension>]
type EllipseGeometryModifiers =
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabEllipseGeometry>, value: Point) =
        this.AddScalar(EllipseGeometry.Center.WithValue(value))
