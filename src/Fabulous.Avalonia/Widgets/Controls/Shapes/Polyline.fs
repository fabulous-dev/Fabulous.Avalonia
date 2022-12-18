namespace Fabulous.Avalonia

open System.Collections.Generic
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous

type IFabPolyline =
    inherit IFabShape

module Polyline =
    let WidgetKey = Widgets.register<Polyline>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "Polyline_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Polyline.PointsProperty)
            | ValueSome points ->
                let coll = List<Point>()
                points |> List.iter coll.Add
                target.SetValue(Polyline.PointsProperty, coll) |> ignore)

[<AutoOpen>]
module PolylineBuilders =
    type Fabulous.Avalonia.View with

        static member Polyline(points: Point list) =
            WidgetBuilder<'msg, IFabPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))
