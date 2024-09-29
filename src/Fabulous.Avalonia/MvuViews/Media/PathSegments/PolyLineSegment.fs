namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuPolyLineSegment =
    inherit IFabMvuPathSegment
    inherit IFabPolyLineSegment

[<AutoOpen>]
module MvuPolyLineSegmentBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PolyLineSegment widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member PolyLineSegment(points: Point list) =
            WidgetBuilder<unit, IFabMvuPolyLineSegment>(PolyLineSegment.WidgetKey, PolyLineSegment.Points.WithValue(points |> Array.ofList))

type MvuPolyLineSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct PolyLineSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuPolyLineSegment>, value: ViewRef<PolyLineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
