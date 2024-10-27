namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuQuadraticBezierSegment =
    inherit IFabMvuPathSegment
    inherit IFabQuadraticBezierSegment

[<AutoOpen>]
module MvuQuadraticBezierSegmentBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a QuadraticBezierSegment widget.</summary>
        /// <param name="point1">The first control point of the curve.</param>
        /// <param name="point2">The second control point of the curve.</param>
        static member QuadraticBezierSegment(point1: Point, point2: Point) =
            WidgetBuilder<'msg, IFabMvuQuadraticBezierSegment>(
                QuadraticBezierSegment.WidgetKey,
                QuadraticBezierSegment.Point1.WithValue(point1),
                QuadraticBezierSegment.Point2.WithValue(point2)
            )
