namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Avalonia.Interactivity
open Fabulous.Avalonia

type IFabMvuTextBox =
    inherit IFabMvuTemplatedControl
    inherit IFabTextBox

module MvuTextBox =
    let TextChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "TextBox_TextChanged" TextBox.TextProperty

    let CopyingToClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_CopyingToClipboardEvent" (fun target -> (target :?> TextBox).CopyingToClipboard)

    let CuttingToClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_CuttingToClipboard" (fun target -> (target :?> TextBox).CuttingToClipboard)

    let PastingFromClipboard =
        Attributes.defineEvent<RoutedEventArgs> "TextBox_PastingFromClipboardEvent" (fun target -> (target :?> TextBox).PastingFromClipboard)

[<AutoOpen>]
module MvuTextBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline TextBox(text: string, fn: string -> 'msg) =
            WidgetBuilder<'msg, IFabMvuTextBox>(TextBox.WidgetKey, MvuTextBox.TextChanged.WithValue(MvuValueEventData.create text fn))

type MvuTextBoxModifiers =
    /// /// <summary>Listens to the TexBox CopyingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CopyingToClipboard changes.</param>
    [<Extension>]
    static member inline onCopyingToClipboard(this: WidgetBuilder<'msg, #IFabMvuTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.CopyingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox CuttingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CuttingToClipboard changes.</param>
    [<Extension>]
    static member inline onCuttingToClipboard(this: WidgetBuilder<'msg, #IFabMvuTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.CuttingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox PastingFromClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PastingFromClipboard changes.</param>
    [<Extension>]
    static member inline onPastingFromClipboard(this: WidgetBuilder<'msg, #IFabTextBox>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuTextBox.PastingFromClipboard.WithValue(fn))

type MvuTextBoxExtraModifiers =
    /// <summary>Sets the TextAlignment to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBox>) =
        this.AddScalar(TextBox.TextAlignment.WithValue(TextAlignment.Center))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))
