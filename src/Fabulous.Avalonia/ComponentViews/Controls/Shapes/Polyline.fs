namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabComponentPolyline =
    inherit IFabComponentShape
    inherit IFabPolyline

[<AutoOpen>]
module ComponentPolylineBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Polyline widget.</summary>
        /// <param name="points">The points of the polyline.</param>
        static member Polyline(points: Point list) =
            WidgetBuilder<unit, IFabComponentPolyline>(Polyline.WidgetKey, Polyline.Points.WithValue(points))

type ComponentPolylineModifiers =
    /// <summary>Link a ViewRef to access the direct Polyline control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentPolyline>, value: ViewRef<Polyline>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
