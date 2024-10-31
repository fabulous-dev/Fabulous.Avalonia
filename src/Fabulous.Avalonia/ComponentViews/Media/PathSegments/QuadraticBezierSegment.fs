namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentQuadraticBezierSegment =
    inherit IFabComponentPathSegment
    inherit IFabQuadraticBezierSegment

[<AutoOpen>]
module ComponentQuadraticBezierSegmentBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a QuadraticBezierSegment widget.</summary>
        /// <param name="point1">The first control point of the curve.</param>
        /// <param name="point2">The second control point of the curve.</param>
        static member QuadraticBezierSegment(point1: Point, point2: Point) =
            WidgetBuilder<unit, IFabComponentQuadraticBezierSegment>(
                QuadraticBezierSegment.WidgetKey,
                QuadraticBezierSegment.Point1.WithValue(point1),
                QuadraticBezierSegment.Point2.WithValue(point2)
            )
