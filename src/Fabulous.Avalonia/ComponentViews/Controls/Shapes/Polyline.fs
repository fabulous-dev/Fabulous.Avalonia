namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolyline =
    inherit IFabComponentShape
    inherit IFabPolyline

[<AutoOpen>]
module ComponentPolylineBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Polyline widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member Polyline(points: Point list) =
            WidgetBuilder<unit, IFabComponentPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))
