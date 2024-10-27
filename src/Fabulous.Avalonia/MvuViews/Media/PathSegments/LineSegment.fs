namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuLineSegment =
    inherit IFabMvuPathSegment
    inherit IFabLineSegment
    
[<AutoOpen>]
module MvuLineSegmentBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a LineSegment widget.</summary>
        /// <param name="point">The point to draw the line to.</param>
        static member LineSegment(point: Point) =
            WidgetBuilder<'msg, IFabMvuLineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))