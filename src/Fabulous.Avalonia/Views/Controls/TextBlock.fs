namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTextBlock =
    inherit IFabControl

module TextBlock =
    let WidgetKey = Widgets.register<TextBlock>()

    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextBlock.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.BackgroundProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.PaddingProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontStretchProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextBlock.ForegroundProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.ForegroundProperty

    let BaseLineOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.BaselineOffsetProperty

    let LineHeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.LineHeightProperty

    let LetterSpacing =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.LetterSpacingProperty

    let MaxLines =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.MaxLinesProperty

    let Text = Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextProperty

    let TextAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextAlignmentProperty

    let TextWrapping =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextWrappingProperty

    let TextTrimming =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextTrimmingProperty

    let TextDecorations =
        Attributes.defineAvaloniaListWidgetCollection "TextBlock_TextDecorations" (fun target ->
            let target = target :?> TextBlock

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)

    let Inlines =
        Attributes.defineAvaloniaListWidgetCollection "TextBlock_Inlines" (fun target ->
            let target = target :?> TextBlock

            if target.Inlines = null then
                let newColl = InlineCollection()
                target.Inlines <- newColl
                newColl
            else
                target.Inlines)

[<AutoOpen>]
module TextBlockBuilders =
    type Fabulous.Avalonia.View with

        static member inline TextBlock<'msg>(text: string) =
            WidgetBuilder<'msg, IFabTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        static member inline TextBlock<'msg, 'childMarker when 'childMarker :> IFabInline>() =
            CollectionBuilder<'msg, IFabTextBlock, 'childMarker>(TextBlock.WidgetKey, TextBlock.Inlines)

[<Extension>]
type TextBlockModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBlock.BackgroundWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, brush: string) =
        this.AddScalar(TextBlock.Background.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Thickness) =
        this.AddScalar(TextBlock.Padding.WithValue(value))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontFamily) =
        this.AddScalar(TextBlock.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.FontSize.WithValue(value))

    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontStyle) =
        this.AddScalar(TextBlock.FontStyle.WithValue(value))

    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontWeight) =
        this.AddScalar(TextBlock.FontWeight.WithValue(value))

    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontStretch) =
        this.AddScalar(TextBlock.FontStretch.WithValue(value))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBlock.ForegroundWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, brush: string) =
        this.AddScalar(TextBlock.Foreground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline baselineOffset(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.BaseLineOffset.WithValue(value))

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.LineHeight.WithValue(value))

    [<Extension>]
    static member inline letterSpacing(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.LetterSpacing.WithValue(value))

    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabTextBlock>, value: int) =
        this.AddScalar(TextBlock.MaxLines.WithValue(value))

    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextAlignment) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(value))

    [<Extension>]
    static member inline textWrapping(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextWrapping) =
        this.AddScalar(TextBlock.TextWrapping.WithValue(value))

    [<Extension>]
    static member inline textTrimming(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextTrimming) =
        this.AddScalar(TextBlock.TextTrimming.WithValue(value))

    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'marker :> IFabTextBlock>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabTextDecoration> TextBlock.TextDecorations this

    /// <summary>Link a ViewRef to access the direct TextBlock control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextBlock>, value: ViewRef<TextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))


[<Extension>]
type TextBlockExtraModifiers =
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBlock>) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        TextBlockModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, left: float, top: float, right: float, bottom: float) =
        TextBlockModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, horizontal: float, vertical) =
        TextBlockModifiers.padding(this, Thickness(horizontal, vertical))

[<Extension>]
type TextBlockCollectionBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTextDecoration>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTextDecoration>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabInline>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabInline>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabInline>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabInline>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
