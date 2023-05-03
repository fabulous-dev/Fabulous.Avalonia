namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabPolylineGeometry =
    inherit IFabGeometry

module PolylineGeometry =
    let WidgetKey = Widgets.register<PolylineGeometry>()

    let Points =
        Attributes.defineSimpleScalarWithEquality<Point list> "PolylineGeometry_Points" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PolylineGeometry.PointsProperty)
            | ValueSome points ->
                let coll = Points()
                points |> List.iter coll.Add
                target.SetValue(PolylineGeometry.PointsProperty, coll))

    let IsFilled =
        Attributes.defineAvaloniaPropertyWithEquality PolylineGeometry.IsFilledProperty

[<AutoOpen>]
module PolylineGeometryBuilders =
    type Fabulous.Avalonia.View with

        static member PolylineGeometry(points: Point list, isFilled: bool) =
            WidgetBuilder<'msg, IFabPolylineGeometry>(
                PolylineGeometry.WidgetKey,
                PolylineGeometry.Points.WithValue(points),
                PolylineGeometry.IsFilled.WithValue(isFilled)
            )
