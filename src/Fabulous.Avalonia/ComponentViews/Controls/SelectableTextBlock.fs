namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentSelectableTextBlock =
    inherit IFabComponentTextBlock
    inherit IFabSelectableTextBlock

module ComponentSelectableTextBlock =
    let CopyingToClipboard =
        Attributes.defineEventNoDispatch "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module SelectableTextBlockBuilders =
    type Fabulous.Avalonia.Components.View with

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

type SelectableTextBlockExtraModifiers =
    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<unit, IFabComponentSelectableTextBlock>, value: Color) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<unit, IFabComponentSelectableTextBlock>, value: string) =
        SelectableTextBlockModifiers.selectionBrush(this, View.SolidColorBrush(value))

type ComponentSelectableTextBlockCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentInline>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, 'itemType>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentInline>
        (_: AttributeCollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }
