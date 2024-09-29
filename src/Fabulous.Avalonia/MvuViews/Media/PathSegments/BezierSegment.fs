namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
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
            WidgetBuilder<unit, IFabMvuBezierSegment>(
                BezierSegment.WidgetKey,
                BezierSegment.Point1.WithValue(point1),
                BezierSegment.Point2.WithValue(point2),
                BezierSegment.Point3.WithValue(point3)
            )

type MvuBezierSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct BezierSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuBezierSegment>, value: ViewRef<BezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
