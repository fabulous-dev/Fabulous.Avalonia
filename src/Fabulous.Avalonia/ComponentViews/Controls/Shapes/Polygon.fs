namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolygon =
    inherit IFabComponentShape
    inherit IFabPolygon


[<AutoOpen>]
module ComponentPolygonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Polygon widget.</summary>
        /// <param name="points">The points of the polygon.</param>
        static member Polygon(points: Point list) =
            WidgetBuilder<unit, IFabComponentPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))
