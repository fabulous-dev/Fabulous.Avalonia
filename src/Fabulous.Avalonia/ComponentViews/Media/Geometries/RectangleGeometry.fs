namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentRectangleGeometry =
    inherit IFabComponentGeometry
    inherit IFabRectangleGeometry

[<AutoOpen>]
module ComponentRectangleGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RectangleGeometry widget.</summary>
        /// <param name="rect">The rectangle to use for the geometry.</param>
        static member RectangleGeometry(rect: Rect) =
            WidgetBuilder<unit, IFabRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))