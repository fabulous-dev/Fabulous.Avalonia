namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolyLineSegment =
    inherit IFabComponentPathSegment
    inherit IFabPolyLineSegment

[<AutoOpen>]
module ComponentPolyLineSegmentBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member PolyLineSegment(points: Point list) =
            WidgetBuilder<unit, IFabComponentPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(points |> Array.ofList))
