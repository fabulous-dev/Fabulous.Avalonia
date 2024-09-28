namespace Fabulous.Avalonia.Mvu

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuPolygon =
    inherit IFabMvuShape
    inherit IFabPolygon


[<AutoOpen>]
module MvuPolygonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Polygon widget.</summary>
        /// <param name="points">The points of the polygon.</param>
        static member Polygon(points: Point list) =
            WidgetBuilder<unit, IFabMvuPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))

type MvuPolygonModifiers =
    /// <summary>Link a ViewRef to access the direct Polygon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
