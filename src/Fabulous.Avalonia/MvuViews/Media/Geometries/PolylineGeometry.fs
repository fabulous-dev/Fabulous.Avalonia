namespace Fabulous.Avalonia.Components

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolylineGeometry =
    inherit IFabComponentGeometry
    inherit IFabPolylineGeometry

[<AutoOpen>]
module ComponentPolylineGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        /// <param name="isFilled">Whether the polyline is filled.</param>
        static member PolylineGeometry(points: Point list, isFilled: bool) =
            WidgetBuilder<unit, IFabComponentPolylineGeometry>(
                PolylineGeometry.WidgetKey,
                PolylineGeometry.Points.WithValue(points |> Array.ofList),
                PolylineGeometry.IsFilled.WithValue(isFilled)
            )
