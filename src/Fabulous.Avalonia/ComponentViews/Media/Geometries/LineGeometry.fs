namespace Fabulous.Avalonia.Components

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentLineGeometry =
    inherit IFabComponentGeometry
    inherit IFabLineGeometry

[<AutoOpen>]
module ComponentLineGeometryBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a LineGeometry widget.</summary>
        /// <param name="startPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member LineGeometry(startPoint: Point, endPoint: Point) =
            WidgetBuilder<unit, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )
