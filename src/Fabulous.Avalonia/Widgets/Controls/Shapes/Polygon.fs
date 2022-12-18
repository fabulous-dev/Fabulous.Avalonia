namespace Fabulous.Avalonia

open System.Collections.Generic
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous

type IFabPolygon =
    inherit IFabShape

module Polygon =
    let WidgetKey = Widgets.register<Polygon> ()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "Polygon_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polygon.PointsProperty)
            | ValueSome points ->
                let coll = List<Point>()
                points |> List.iter coll.Add
                target.SetValue(Polygon.PointsProperty, coll) |> ignore)

[<AutoOpen>]
module PolygonBuilders =
    type Fabulous.Avalonia.View with

        static member Polygon(points: Point list) =
            WidgetBuilder<'msg, IFabPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))
