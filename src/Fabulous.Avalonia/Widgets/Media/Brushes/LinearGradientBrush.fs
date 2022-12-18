namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabLinearGradientBrush =
    inherit IFabGradientBrush

module LinearGradientBrush =
    let WidgetKey = Widgets.register<LinearGradientBrush> ()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        static member inline LinearGradientBrush<'msg>(?startPoint: RelativePoint, ?endPoint: RelativePoint) =
            match startPoint, endPoint with
            | Some s, None ->
                CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    LinearGradientBrush.StartPoint.WithValue(s),
                    LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
                )
            | None, Some e ->
                CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                    LinearGradientBrush.EndPoint.WithValue(e)
                )
            | Some s, Some e ->
                CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    LinearGradientBrush.StartPoint.WithValue(s),
                    LinearGradientBrush.EndPoint.WithValue(e)
                )

            | None, None ->
                CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                    LinearGradientBrush.WidgetKey,
                    GradientBrush.GradientStops,
                    LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                    LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
                )
