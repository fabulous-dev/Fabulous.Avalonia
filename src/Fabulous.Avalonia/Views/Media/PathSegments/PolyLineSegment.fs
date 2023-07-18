namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabPolyLineSegment =
    inherit IFabPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment>()

    let Points =
        Attributes.defineAvaloniaPropertyWithEquality PolyLineSegment.PointsProperty

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member inline PolyLineSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IFabPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(points |> Array.ofList))
