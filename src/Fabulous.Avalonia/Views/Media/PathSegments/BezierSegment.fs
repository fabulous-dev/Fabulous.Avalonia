namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabBezierSegment =
    inherit IFabPathSegment

module BezierSegment =
    let WidgetKey = Widgets.register<BezierSegment>()

    let Point1 =
        Attributes.defineAvaloniaPropertyWithEquality BezierSegment.Point1Property

    let Point2 =
        Attributes.defineAvaloniaPropertyWithEquality BezierSegment.Point2Property

    let Point3 =
        Attributes.defineAvaloniaPropertyWithEquality BezierSegment.Point3Property


type BezierSegmentModifiers =

    /// <summary>Link a ViewRef to access the direct BezierSegment control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabBezierSegment>, value: ViewRef<BezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
