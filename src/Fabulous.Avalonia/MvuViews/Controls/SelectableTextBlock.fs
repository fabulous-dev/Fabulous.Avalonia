namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuSelectableTextBlock =
    inherit IFabMvuTextBlock
    inherit IFabSelectableTextBlock

module MvuSelectableTextBlock =
    let CopyingToClipboard =
        Attributes.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module SelectableTextBlockBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(text: string, fn: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMvuSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabMvuSelectableTextBlock, IFabMvuInline>(
                SelectableTextBlock.WidgetKey,
                MvuTextBlock.Inlines,
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

type SelectableTextBlockExtraModifiers =
    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabMvuSelectableTextBlock>, value: Color) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabMvuSelectableTextBlock>, value: string) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

type MvuSelectableTextBlockCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
    // [<Extension>]
    // static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuRun>
    //     (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuRun>, x: WidgetBuilder<'msg, 'itemType>)
    //     : Content<'msg> =
    //     { Widgets = MutStackArray1.One(x.Compile()) }
    //
    // [<Extension>]
    // static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuRun>
    //     (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuRun>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
    //     : Content<'msg> =
    //     { Widgets = MutStackArray1.One(x.Compile()) }
