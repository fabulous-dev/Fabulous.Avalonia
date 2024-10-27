namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuArcSegment =
    inherit IFabMvuPathSegment
    inherit IFabArcSegment

[<AutoOpen>]
module MvuArcSegmentBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ArcSegment widget.</summary>
        /// <param name="point">The point at which the arc ends.</param>
        /// <param name="size">The size of the arc.</param>
        static member ArcSegment(point: Point, size: Size) =
            WidgetBuilder<'msg, IFabMvuArcSegment>(ArcSegment.WidgetKey, ArcSegment.Point.WithValue(point), ArcSegment.Size.WithValue(size))
