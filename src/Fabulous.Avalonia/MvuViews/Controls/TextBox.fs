namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Avalonia.Layout
open Avalonia.Interactivity
open Fabulous.Avalonia

type IFabMvuTextBox =
    inherit IFabMvuTemplatedControl
    inherit IFabTextBox

module MvuTextBox =
    let TextChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "TextBox_TextChanged" TextBox.TextProperty

    let CopyingToClipboard =
        MvuAttributes.defineEvent<RoutedEventArgs> "TextBox_CopyingToClipboardEvent" (fun target -> (target :?> TextBox).CopyingToClipboard)

    let CuttingToClipboard =
        MvuAttributes.defineEvent<RoutedEventArgs> "TextBox_CuttingToClipboard" (fun target -> (target :?> TextBox).CuttingToClipboard)

    let PastingFromClipboard =
        MvuAttributes.defineEvent<RoutedEventArgs> "TextBox_PastingFromClipboardEvent" (fun target -> (target :?> TextBox).PastingFromClipboard)

[<AutoOpen>]
module MvuTextBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline TextBox(text: string, fn: string -> unit) =
            WidgetBuilder<unit, IFabMvuTextBox>(TextBox.WidgetKey, MvuTextBox.TextChanged.WithValue(MvuValueEventData.create text fn))

type MvuTextBoxModifiers =
    /// /// <summary>Listens to the TexBox CopyingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CopyingToClipboard changes.</param>
    [<Extension>]
    static member inline onCopyingToClipboard(this: WidgetBuilder<unit, #IFabMvuTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuTextBox.CopyingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox CuttingToClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the CuttingToClipboard changes.</param>
    [<Extension>]
    static member inline onCuttingToClipboard(this: WidgetBuilder<unit, #IFabMvuTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuTextBox.CuttingToClipboard.WithValue(fn))

    /// <summary>Listens to the TexBox PastingFromClipboard event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PastingFromClipboard changes.</param>
    [<Extension>]
    static member inline onPastingFromClipboard(this: WidgetBuilder<unit, #IFabTextBox>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuTextBox.PastingFromClipboard.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct TextBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuTextBox>, value: ViewRef<TextBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
