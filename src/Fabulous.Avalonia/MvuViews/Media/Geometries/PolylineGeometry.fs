namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuPolylineGeometry =
    inherit IFabMvuGeometry
    inherit IFabPolylineGeometry

[<AutoOpen>]
module MvuPolylineGeometryBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RotateTransform widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        /// <param name="isFilled">Whether the polyline is filled.</param>
        static member PolylineGeometry(points: Point list, isFilled: bool) =
            WidgetBuilder<unit, IFabMvuPolylineGeometry>(
                PolylineGeometry.WidgetKey,
                PolylineGeometry.Points.WithValue(points |> Array.ofList),
                PolylineGeometry.IsFilled.WithValue(isFilled)
            )
