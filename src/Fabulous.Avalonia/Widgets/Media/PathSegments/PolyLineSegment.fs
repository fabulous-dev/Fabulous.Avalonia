namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFabPolyLineSegment =
    inherit IFabPathSegment

module PolyLineSegment =
    let WidgetKey = Widgets.register<PolyLineSegment>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "PolyLineSegment_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolyLineSegment.PointsProperty)
            | ValueSome points ->
                let coll = Points()
                points |> List.iter coll.Add
                target.SetValue(PolyLineSegment.PointsProperty, coll) |> ignore)

[<AutoOpen>]
module PolyLineSegmentBuilders =

    type Fabulous.Avalonia.View with

        static member inline PolyLineSegment<'msg>(points: Point list) =
            WidgetBuilder<'msg, IFabPolyLineSegment>(
                PolyLineSegment.WidgetKey,
                PolyLineSegment.Points.WithValue(points)
            )
