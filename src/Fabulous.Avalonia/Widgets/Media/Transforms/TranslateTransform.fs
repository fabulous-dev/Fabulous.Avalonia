namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous

type IFabTranslateTransform =
    inherit IFabTransform

module TranslateTransform =

    let WidgetKey = Widgets.register<TranslateTransform> ()

    let X = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.XProperty

    let Y = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =
    type Fabulous.Avalonia.View with

        static member TranslateTransform(x: float, y: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(
                TranslateTransform.WidgetKey,
                TranslateTransform.X.WithValue(x),
                TranslateTransform.Y.WithValue(y)
            )
