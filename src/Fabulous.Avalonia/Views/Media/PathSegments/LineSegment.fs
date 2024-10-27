namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabLineSegment =
    inherit IFabPathSegment

module LineSegment =
    let WidgetKey = Widgets.register<LineSegment>()

    let Point = Attributes.defineAvaloniaPropertyWithEquality LineSegment.PointProperty

type LineSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct LineSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabLineSegment>, value: ViewRef<LineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
