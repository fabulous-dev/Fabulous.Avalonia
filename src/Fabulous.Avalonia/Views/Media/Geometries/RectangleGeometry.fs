namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabRectangleGeometry =
    inherit IFabGeometry

module RectangleGeometry =
    let WidgetKey = Widgets.register<RectangleGeometry>()

    let Rect =
        Attributes.defineAvaloniaPropertyWithEquality RectangleGeometry.RectProperty

type RectangleGeometryModifiers =

    /// <summary>Link a ViewRef to access the direct RectangleGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRectangleGeometry>, value: ViewRef<RectangleGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
