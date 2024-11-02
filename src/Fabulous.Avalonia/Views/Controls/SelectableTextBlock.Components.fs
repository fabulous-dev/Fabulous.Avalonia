namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

module ComponentSelectableTextBlock =
    let CopyingToClipboard =
        Attributes.defineEventNoDispatch "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module ComponentSelectableTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                ComponentSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> unit) =
            CollectionBuilder<unit, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                ComponentTextBlock.Inlines,
                ComponentSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )
