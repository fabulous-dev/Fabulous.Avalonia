namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolygon =
    inherit IFabComponentShape
    inherit IFabPolygon


[<AutoOpen>]
module ComponentPolygonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Polygon widget.</summary>
        /// <param name="points">The points of the polygon.</param>
        static member Polygon(points: Point list) =
            WidgetBuilder<unit, IFabComponentPolygon>(Polygon.WidgetKey, Polygon.Points.WithValue(points))

type ComponentPolygonModifiers =
    /// <summary>Link a ViewRef to access the direct Polygon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentPolygon>, value: ViewRef<Polygon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
