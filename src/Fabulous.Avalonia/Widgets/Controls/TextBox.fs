namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Avalonia.Layout
open Avalonia.Interactivity

type IFabTextBox =
    inherit IFabTemplatedControl

module TextBox =
    let WidgetKey = Widgets.register<TextBox> ()

    let Text = Attributes.defineAvaloniaPropertyWithEquality TextBox.TextProperty

    let TextAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.TextAlignmentProperty

    let TextWrapping =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.TextWrappingProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.VerticalContentAlignmentProperty

    let AcceptsReturn =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.AcceptsReturnProperty

    let AcceptsTab =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.AcceptsTabProperty

    let IsReadOnly =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.IsReadOnlyProperty

    let IsUndoEnabled =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.IsUndoEnabledProperty

    let UndoLimit =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.UndoLimitProperty

    let LetterSpacing =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.LetterSpacingProperty

    let LineHeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.LineHeightProperty

    let MaxLength =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.MaxLengthProperty

    let MaxLines =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.MaxLinesProperty

    let PasswordChar =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.PasswordCharProperty

    let RevealPassword =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.RevealPasswordProperty

    let SelectionStart =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionStartProperty

    let SelectionEnd =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionEndProperty

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.WatermarkProperty

    let UseFloatingWatermark =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.UseFloatingWatermarkProperty

    let CaretIndex =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.CaretIndexProperty

    let NewLine = Attributes.defineAvaloniaPropertyWithEquality TextBox.NewLineProperty

    let CaretBrush = Attributes.defineAvaloniaPropertyWidget TextBox.CaretBrushProperty

    let SelectionBrush =
        Attributes.defineAvaloniaPropertyWidget TextBox.SelectionBrushProperty

    let SelectionForegroundBrush =
        Attributes.defineAvaloniaPropertyWidget TextBox.SelectionForegroundBrushProperty

    let TextChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "TextBox_ValueChanged" TextBox.TextProperty

    let CopyingToClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_CopyingToClipboardEvent" (fun target ->
            (target :?> TextBox).CopyingToClipboard)

    let CuttingToClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_CuttingToClipboard" (fun target ->
            (target :?> TextBox).CuttingToClipboard)

    let PastingFromClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_PastingFromClipboardEvent" (fun target ->
            (target :?> TextBox).PastingFromClipboard)

[<AutoOpen>]
module TextBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline TextBox<'msg>(text: string, valueChanged: string -> 'msg) =
            WidgetBuilder<'msg, IFabTextBox>(
                TextBox.WidgetKey,
                TextBox.Text.WithValue(text),
                TextBox.TextChanged.WithValue(ValueEventData.create text (fun args -> valueChanged args |> box))
            )

[<Extension>]
type TextBoxModifiers =

    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabTextBox>, value: TextAlignment) =
        this.AddScalar(TextBox.TextAlignment.WithValue(value))

    [<Extension>]
    static member inline textWrapping(this: WidgetBuilder<'msg, #IFabTextBox>, value: TextWrapping) =
        this.AddScalar(TextBox.TextWrapping.WithValue(value))

    [<Extension>]
    static member inline horizontalContentAlignment
        (
            this: WidgetBuilder<'msg, #IFabTextBox>,
            value: HorizontalAlignment
        ) =
        this.AddScalar(TextBox.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabTextBox>, value: VerticalAlignment) =
        this.AddScalar(TextBox.VerticalContentAlignment.WithValue(value))

    [<Extension>]
    static member acceptsReturn(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.AcceptsReturn.WithValue(value))

    [<Extension>]
    static member acceptsTab(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.AcceptsTab.WithValue(value))

    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.IsReadOnly.WithValue(value))

    [<Extension>]
    static member inline isUndoEnabled(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.IsUndoEnabled.WithValue(value))

    [<Extension>]
    static member inline undoLimit(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.UndoLimit.WithValue(value))

    [<Extension>]
    static member inline letterSpacing(this: WidgetBuilder<'msg, #IFabTextBox>, value: float) =
        this.AddScalar(TextBox.LetterSpacing.WithValue(value))

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabTextBox>, value: float) =
        this.AddScalar(TextBox.LineHeight.WithValue(value))

    [<Extension>]
    static member inline maxLength(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.MaxLength.WithValue(value))

    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.MaxLines.WithValue(value))

    [<Extension>]
    static member inline passwordChar(this: WidgetBuilder<'msg, #IFabTextBox>, value: char) =
        this.AddScalar(TextBox.PasswordChar.WithValue(value))

    [<Extension>]
    static member inline revealPassword(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.RevealPassword.WithValue(value))

    [<Extension>]
    static member inline selectionStart(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.SelectionStart.WithValue(value))

    [<Extension>]
    static member inline selectionEnd(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.SelectionEnd.WithValue(value))

    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        this.AddScalar(TextBox.Watermark.WithValue(value))

    [<Extension>]
    static member inline useFloatingWatermark(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.UseFloatingWatermark.WithValue(value))

    [<Extension>]
    static member inline caretIndex(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.CaretIndex.WithValue(value))

    [<Extension>]
    static member inline newLine(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        this.AddScalar(TextBox.NewLine.WithValue(value))

    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBox.CaretBrush.WithValue(value.Compile()))

    [<Extension>]
    static member inline selectionBrush
        (
            this: WidgetBuilder<'msg, #IFabTextBox>,
            value: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TextBox.SelectionBrush.WithValue(value.Compile()))

    [<Extension>]
    static member inline selectionForegroundBrush
        (
            this: WidgetBuilder<'msg, #IFabTextBox>,
            value: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TextBox.SelectionForegroundBrush.WithValue(value.Compile()))

    [<Extension>]
    static member inline onCopyingToClipboard
        (
            this: WidgetBuilder<'msg, #IFabTextBox>,
            onCopyingToClipboard: string -> 'msg
        ) =
        this.AddScalar(
            TextBox.CopyingToClipboard.WithValue(fun args ->
                let control = args.Source :?> TextBox
                onCopyingToClipboard control.Text |> box)
        )

    [<Extension>]
    static member inline onCuttingToClipboard
        (
            this: WidgetBuilder<'msg, #IFabTextBox>,
            onCuttingToClipboard: string -> 'msg
        ) =
        this.AddScalar(
            TextBox.CuttingToClipboard.WithValue(fun args ->
                let control = args.Source :?> TextBox
                onCuttingToClipboard control.Text |> box)
        )

    [<Extension>]
    static member inline onPastingFromClipboard(this: WidgetBuilder<'msg, #IFabTextBox>, onPastingFromClipboard: 'msg) =
        this.AddScalar(TextBox.PastingFromClipboard.WithValue(fun _ -> onPastingFromClipboard |> box))

[<Extension>]
type TextBoxExtraModifiers =
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBox>) =
        this.AddScalar(TextBox.TextAlignment.WithValue(TextAlignment.Center))
