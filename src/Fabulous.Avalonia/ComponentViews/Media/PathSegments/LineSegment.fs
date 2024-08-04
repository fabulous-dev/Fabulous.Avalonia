namespace Fabulous.Avalonia.Components

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentLineSegment =
    inherit IFabComponentPathSegment
    inherit IFabLineSegment

[<AutoOpen>]
module ComponentLineSegmentBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a LineSegment widget.</summary>
        /// <param name="point">The point to draw the line to.</param>
        static member LineSegment(point: Point) =
            WidgetBuilder<unit, IFabComponentLineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))