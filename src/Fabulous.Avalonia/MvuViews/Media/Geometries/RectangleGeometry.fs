namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuRectangleGeometry =
    inherit IFabMvuGeometry
    inherit IFabRectangleGeometry

[<AutoOpen>]
module MvuRectangleGeometryBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RectangleGeometry widget.</summary>
        /// <param name="rect">The rectangle to use for the geometry.</param>
        static member RectangleGeometry(rect: Rect) =
            WidgetBuilder<'msg, IFabMvuRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))
