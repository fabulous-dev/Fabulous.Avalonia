namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabRadialGradientBrush =
    inherit IFabBrush

module RadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let Radius =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module RadialGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        static member inline RadialGradientBrush<'msg>(center: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        static member inline RadialGradientBrush<'msg>(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue((RelativePoint(center, unit))),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        static member inline RadialGradientBrush<'msg>(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        static member inline RadialGradientBrush<'msg>(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        static member inline RadialGradientBrush<'msg>() =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

[<Extension>]
type RadialGradientBrushModifiers =

    [<Extension>]
    static member inline radius(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: float) =
        this.AddScalar(RadialGradientBrush.Radius.WithValue(value))
