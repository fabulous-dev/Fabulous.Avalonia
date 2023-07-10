namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabPolylineGeometry =
    inherit IFabGeometry

module PolylineGeometry =
    let WidgetKey = Widgets.register<PolylineGeometry>()

    let Points =
        Attributes.defineAvaloniaPropertyWithEquality PolylineGeometry.PointsProperty

    let IsFilled =
        Attributes.defineAvaloniaPropertyWithEquality PolylineGeometry.IsFilledProperty

[<AutoOpen>]
module PolylineGeometryBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RotateTransform widget</summary>
        /// <param name="points">The points of the polyline</param>
        /// <param name="isFilled">Whether the polyline is filled</param>
        static member PolylineGeometry(points: Point list, isFilled: bool) =
            WidgetBuilder<'msg, IFabPolylineGeometry>(
                PolylineGeometry.WidgetKey,
                PolylineGeometry.Points.WithValue(points |> Array.ofList),
                PolylineGeometry.IsFilled.WithValue(isFilled)
            )
