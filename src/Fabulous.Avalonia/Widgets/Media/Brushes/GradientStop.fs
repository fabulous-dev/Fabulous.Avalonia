namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabGradientStop =
    inherit IFabElement

module GradientStop =

    let WidgetKey = Widgets.register<GradientStop> ()

    let Color = Attributes.defineAvaloniaPropertyWithEquality GradientStop.ColorProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality GradientStop.OffsetProperty

[<AutoOpen>]
module GradientStopBuilders =
    type Fabulous.Avalonia.View with

        static member inline GradientStop(offset: float, color: Color) =
            WidgetBuilder<'msg, IFabGradientStop>(
                GradientStop.WidgetKey,
                GradientStop.Color.WithValue(color),
                GradientStop.Offset.WithValue(offset)
            )
