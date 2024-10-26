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

type EllipseGeometryModifiers =
    /// <summary>Sets the Center property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Center value.</param>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabEllipseGeometry>, value: Point) =
        this.AddScalar(EllipseGeometry.Center.WithValue(value))

    /// <summary>Sets the Rect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Rect value.</param>
    [<Extension>]
    static member inline rect(this: WidgetBuilder<'msg, #IFabEllipseGeometry>, value: Rect) =
        this.AddScalar(EllipseGeometry.Rect.WithValue(value))

    /// <summary>Link a ViewRef to access the direct EllipseGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEllipseGeometry>, value: ViewRef<EllipseGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
