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
        MvuAttributes.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module SelectableTextBlockBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

        /// <summary>Creates a SelectableTextBlock widget.</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard.</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> unit) =
            CollectionBuilder<unit, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                MvuTextBlock.Inlines,
                MvuSelectableTextBlock.CopyingToClipboard.WithValue(fn)
            )

type MvuSelectableTextBlockModifiers =
    /// <summary>Link a ViewRef to access the direct SelectableTextBlock control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuSelectableTextBlock>, value: ViewRef<SelectableTextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
        
type SelectableTextBlockExtraModifiers =
    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: Color) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: string) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

type MvuSelectableTextBlockCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
