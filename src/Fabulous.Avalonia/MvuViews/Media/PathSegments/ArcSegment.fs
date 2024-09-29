namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
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
            WidgetBuilder<unit, IFabMvuArcSegment>(ArcSegment.WidgetKey, ArcSegment.Point.WithValue(point), ArcSegment.Size.WithValue(size))

type MvuArcSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct ArcSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuArcSegment>, value: ViewRef<ArcSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
