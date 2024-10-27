namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuPolyLineSegment =
    inherit IFabMvuPathSegment
    inherit IFabPolyLineSegment

[<AutoOpen>]
module MvuPolyLineSegmentBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member PolyLineSegment(points: Point list) =
            WidgetBuilder<'msg, IFabMvuPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(points |> Array.ofList))
