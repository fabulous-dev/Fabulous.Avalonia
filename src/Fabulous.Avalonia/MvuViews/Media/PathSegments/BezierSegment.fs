namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuBezierSegment =
    inherit IFabMvuPathSegment
    inherit IFabBezierSegment

[<AutoOpen>]
module MvuBezierSegmentBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a BezierSegment widget.</summary>
        /// <param name="point1">The first control point of the curve.</param>
        /// <param name="point2">The second control point of the curve.</param>
        /// <param name="point3">The third control point of the curve.</param>
        static member BezierSegment(point1: Point, point2: Point, point3: Point) =
            WidgetBuilder<'msg, IFabMvuBezierSegment>(
                BezierSegment.WidgetKey,
                BezierSegment.Point1.WithValue(point1),
                BezierSegment.Point2.WithValue(point2),
                BezierSegment.Point3.WithValue(point3)
            )
