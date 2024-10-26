namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuLineGeometry =
    inherit IFabMvuGeometry
    inherit IFabLineGeometry

[<AutoOpen>]
module MvuLineGeometryBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a LineGeometry widget.</summary>
        /// <param name="startPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member LineGeometry(startPoint: Point, endPoint: Point) =
            WidgetBuilder<unit, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )
