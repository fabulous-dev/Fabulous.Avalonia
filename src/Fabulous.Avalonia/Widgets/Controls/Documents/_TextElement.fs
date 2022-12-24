namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous

type IFabTextElement =
    inherit IFabStyledElement

module TextElement =
    let Background =
        Attributes.defineAvaloniaPropertyWidget TextElement.BackgroundProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWidget TextElement.ForegroundProperty

[<Extension>]
type TextElementModifiers =
    [<Extension>]
    static member inline background
        (
            this: WidgetBuilder<'msg, #IFabTextElement>,
            content: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TextElement.Background.WithValue(content.Compile()))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontFamily) =
        this.AddScalar(TextElement.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTextElement>, value: double) =
        this.AddScalar(TextElement.FontSize.WithValue(value))

    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontStyle) =
        this.AddScalar(TextElement.FontStyle.WithValue(value))

    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontWeight) =
        this.AddScalar(TextElement.FontWeight.WithValue(value))

    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontStretch) =
        this.AddScalar(TextElement.FontStretch.WithValue(value))

    [<Extension>]
    static member inline foreground
        (
            this: WidgetBuilder<'msg, #IFabTextElement>,
            content: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TextElement.Foreground.WithValue(content.Compile()))
