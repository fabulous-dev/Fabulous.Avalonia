namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabQuadraticBezierSegment =
    inherit IFabPathSegment

module QuadraticBezierSegment =
    let WidgetKey = Widgets.register<QuadraticBezierSegment> ()

    let Point1 =
        Attributes.defineAvaloniaPropertyWithEquality QuadraticBezierSegment.Point1Property

    let Point2 =
        Attributes.defineAvaloniaPropertyWithEquality QuadraticBezierSegment.Point2Property

[<AutoOpen>]
module QuadraticBezierSegmentBuilders =

    type Fabulous.Avalonia.View with

        static member inline QuadraticBezierSegment<'msg>(point1: Point, point2: Point) =
            WidgetBuilder<'msg, IFabQuadraticBezierSegment>(
                QuadraticBezierSegment.WidgetKey,
                QuadraticBezierSegment.Point1.WithValue(point1),
                QuadraticBezierSegment.Point2.WithValue(point2)
            )
