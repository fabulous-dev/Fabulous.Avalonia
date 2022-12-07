namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabConicGradientBrush =
    inherit IFabGradientBrush

module ConicGradientBrush =
    let WidgetKey = Widgets.register<ConicGradientBrush> ()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.CenterProperty

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.AngleProperty

[<AutoOpen>]
module ConicGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        static member ConicGradientBrush<'msg>(?center: RelativePoint, ?angle: float) =
            match center, angle with
            | Some center, None ->
                CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                    ConicGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    ConicGradientBrush.Center.WithValue(center),
                    ConicGradientBrush.Angle.WithValue(0.)
                )
            | None, Some angle ->
                CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                    ConicGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                    ConicGradientBrush.Angle.WithValue(angle)
                )

            | Some center, Some angle ->
                CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                    ConicGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    ConicGradientBrush.Center.WithValue(center),
                    ConicGradientBrush.Angle.WithValue(angle)
                )

            | None, None ->
                CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                    ConicGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                    ConicGradientBrush.Angle.WithValue(0.)
                )
