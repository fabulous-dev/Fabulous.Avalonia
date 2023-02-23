namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabConicGradientBrush =
    inherit IFabGradientBrush

module ConicGradientBrush =
    let WidgetKey = Widgets.register<ConicGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.CenterProperty

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.AngleProperty

[<AutoOpen>]
module ConicGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        static member ConicGradientBrush<'msg>(center: RelativePoint, angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(angle)
            )
            
        static member ConicGradientBrush<'msg>(center: RelativePoint) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(0.)
            )
            
            
        static member ConicGradientBrush<'msg>(center: Point, unit: RelativeUnit, angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(angle)
            )
            
        static member ConicGradientBrush<'msg>(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(0.)
            )
            
        static member ConicGradientBrush<'msg>(angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(angle)
            )
            
        static member ConicGradientBrush<'msg>() =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(0.)
            )
