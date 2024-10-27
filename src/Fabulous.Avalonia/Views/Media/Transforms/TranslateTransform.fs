namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabTranslateTransform =
    inherit IFabTransform

module TranslateTransform =

    let WidgetKey = Widgets.register<TranslateTransform>()

    let X = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.XProperty

    let Y = Attributes.defineAvaloniaPropertyWithEquality TranslateTransform.YProperty

type TranslateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct TranslateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabTranslateTransform>, value: ViewRef<TranslateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
