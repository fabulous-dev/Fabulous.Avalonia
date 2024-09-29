namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabQuadraticBezierSegment =
    inherit IFabPathSegment

module QuadraticBezierSegment =
    let WidgetKey = Widgets.register<QuadraticBezierSegment>()

    let Point1 =
        Attributes.defineAvaloniaPropertyWithEquality QuadraticBezierSegment.Point1Property

    let Point2 =
        Attributes.defineAvaloniaPropertyWithEquality QuadraticBezierSegment.Point2Property

type QuadraticBezierSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct QuadraticBezierSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabQuadraticBezierSegment>, value: ViewRef<QuadraticBezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
