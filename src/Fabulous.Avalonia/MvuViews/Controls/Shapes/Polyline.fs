namespace Fabulous.Avalonia.Mvu

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuPolyline =
    inherit IFabMvuShape
    inherit IFabPolyline

[<AutoOpen>]
module MvuPolylineBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Polyline widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member Polyline(points: Point list) =
            WidgetBuilder<unit, IFabMvuPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))
