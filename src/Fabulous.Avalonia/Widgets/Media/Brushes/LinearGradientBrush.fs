namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabLinearGradientBrush =
    inherit IFabGradientBrush

module LinearGradientBrush =
    let WidgetKey = Widgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.EndPointProperty

[<AutoOpen>]
module LinearGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        static member inline LinearGradientBrush<'msg>(startPoint: RelativePoint, endPoint: RelativePoint) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )

        static member inline LinearGradientBrush<'msg>(startPoint: Point, endPoint: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint(startPoint, unit)),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint(endPoint, unit))
            )

        static member inline LinearGradientBrush<'msg>(startPoint: Point, endPoint: Point, startUnit: RelativeUnit, endUnit: RelativeUnit) =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint(startPoint, startUnit)),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint(endPoint, endUnit))
            )

        static member inline LinearGradientBrush<'msg>() =
            CollectionBuilder<'msg, IFabLinearGradientBrush, IFabGradientStop>(
                LinearGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
            )

        static member LinearGradientBrush'<'msg>(startPoint: RelativePoint, endPoint: RelativePoint) =
            WidgetBuilder<'msg, IFabLinearGradientBrush>(
                LinearGradientBrush.WidgetKey,
                LinearGradientBrush.StartPoint.WithValue(startPoint),
                LinearGradientBrush.EndPoint.WithValue(endPoint)
            )

        static member LinearGradientBrush'<'msg>() =
            WidgetBuilder<'msg, IFabLinearGradientBrush>(
                LinearGradientBrush.WidgetKey,
                LinearGradientBrush.StartPoint.WithValue(RelativePoint.TopLeft),
                LinearGradientBrush.EndPoint.WithValue(RelativePoint.BottomRight)
            )
