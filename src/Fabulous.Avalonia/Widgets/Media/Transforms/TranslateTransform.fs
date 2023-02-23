namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTranslateTransform =
    inherit IFabTransform

module TranslateTransform =

    let WidgetKey = Widgets.register<TranslateTransform>()

    let X = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.XProperty

    let Y = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =
    type Fabulous.Avalonia.View with

        static member TranslateTransform(x: float, y: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x), TranslateTransform.Y.WithValue(y))

        static member TranslateTransform(x: float) =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x))

        static member TranslateTransform() =
            WidgetBuilder<'msg, IFabTranslateTransform>(TranslateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
