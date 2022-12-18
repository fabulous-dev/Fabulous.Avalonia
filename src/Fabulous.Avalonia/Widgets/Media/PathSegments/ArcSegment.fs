namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabArcSegment =
    inherit IFabPathSegment

module ArcSegment =
    let WidgetKey = Widgets.register<ArcSegment>()

    let IsLargeArc =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.IsLargeArcProperty

    let Point = Attributes.defineAvaloniaPropertyWithEquality ArcSegment.PointProperty

    let RotationAngle =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.RotationAngleProperty

    let Size = Attributes.defineAvaloniaPropertyWithEquality ArcSegment.SizeProperty

    let SweepDirection =
        Attributes.defineAvaloniaPropertyWithEquality ArcSegment.SweepDirectionProperty

[<AutoOpen>]
module ArcSegmentBuilders =

    type Fabulous.Avalonia.View with

        static member inline ArcSegment<'msg>(point: Point, size: Size) =
            WidgetBuilder<'msg, IFabArcSegment>(
                ArcSegment.WidgetKey,
                ArcSegment.Point.WithValue(point),
                ArcSegment.Size.WithValue(size)
            )

[<Extension>]
type ArcSegmentModifiers =

    [<Extension>]
    static member inline rotationAngle(this: WidgetBuilder<'msg, #IFabArcSegment>, value: float) =
        this.AddScalar(ArcSegment.RotationAngle.WithValue(value))

    [<Extension>]
    static member inline sweepDirection(this: WidgetBuilder<'msg, #IFabArcSegment>, value: SweepDirection) =
        this.AddScalar(ArcSegment.SweepDirection.WithValue(value))

    [<Extension>]
    static member inline isLargeArc(this: WidgetBuilder<'msg, #IFabArcSegment>, value: bool) =
        this.AddScalar(ArcSegment.IsLargeArc.WithValue(value))
