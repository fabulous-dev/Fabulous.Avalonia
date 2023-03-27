namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabSolidColorBrush =
    inherit IFabBrush

module SolidColorBrush =
    let WidgetKey = Widgets.register<SolidColorBrush>()

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality SolidColorBrush.ColorProperty

[<AutoOpen>]
module SolidColorBrushBuilders =
    type Fabulous.Avalonia.View with

        static member SolidColorBrush<'msg>(color: Color) =
            WidgetBuilder<'msg, IFabSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(color))
