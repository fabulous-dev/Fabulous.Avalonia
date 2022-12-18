namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabRectangleGeometry =
    inherit IFabGeometry

module RectangleGeometry =
    let WidgetKey = Widgets.register<RectangleGeometry> ()

    let Rect =
        Attributes.defineAvaloniaPropertyWithEquality RectangleGeometry.RectProperty

[<AutoOpen>]
module RectangleGeometryBuilders =
    type Fabulous.Avalonia.View with

        static member RectangleGeometry(rect: Rect) =
            WidgetBuilder<'msg, IFabRectangleGeometry>(
                RectangleGeometry.WidgetKey,
                RectangleGeometry.Rect.WithValue(rect)
            )
