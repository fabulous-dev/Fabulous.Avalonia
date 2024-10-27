namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Avalonia.Interactivity
open Fabulous.Avalonia

type IFabComponentTextBox =
    inherit IFabComponentTemplatedControl
    inherit IFabTextBox

module ComponentTextBox =
    let TextChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "TextBox_TextChanged" TextBox.TextProperty

    let CopyingToClipboard =
        Attributes.defineEventNoDispatch<RoutedEventArgs> "TextBox_CopyingToClipboardEvent" (fun target -> (target :?> TextBox).CopyingToClipboard)

    let CuttingToClipboard =
        Attributes.defineEventNoDispatch<RoutedEventArgs> "TextBox_CuttingToClipboard" (fun target -> (target :?> TextBox).CuttingToClipboard)

    let PastingFromClipboard =
        Attributes.defineEventNoDispatch<RoutedEventArgs> "TextBox_PastingFromClipboardEvent" (fun target -> (target :?> TextBox).PastingFromClipboard)

[<AutoOpen>]
module ComponentTextBoxBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline TextBox(text: string, fn: string -> unit) =
            WidgetBuilder<unit, IFabComponentTextBox>(TextBox.WidgetKey, ComponentTextBox.TextChanged.WithValue(ComponentValueEventData.create text fn))

type ComponentTextBoxModifiers =
    /// /// <summary>Listens to the TexBox CopyingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CopyingToClipboard changes.</param>
    [<Extension>]
    static member inline onCopyingToClipboard(this: WidgetBuilder<unit, #IFabComponentTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentTextBox.CopyingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox CuttingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CuttingToClipboard changes.</param>
    [<Extension>]
    static member inline onCuttingToClipboard(this: WidgetBuilder<unit, #IFabComponentTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentTextBox.CuttingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox PastingFromClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PastingFromClipboard changes.</param>
    [<Extension>]
    static member inline onPastingFromClipboard(this: WidgetBuilder<unit, #IFabTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentTextBox.PastingFromClipboard.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct TextBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentTextBox>, value: ViewRef<TextBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentTextBoxExtraModifiers =
    /// <summary>Sets the TextAlignment to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBox>) =
        this.AddScalar(TextBox.TextAlignment.WithValue(TextAlignment.Center))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: Color) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: string) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<unit, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))
