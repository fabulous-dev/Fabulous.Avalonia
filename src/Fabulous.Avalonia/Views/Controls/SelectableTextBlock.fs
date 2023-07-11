namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabSelectableTextBlock =
    inherit IFabTextBlock

module SelectableTextBlock =
    let WidgetKey = Widgets.register<SelectableTextBlock>()

    let SelectionStart =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionStartProperty

    let SelectionEnd =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionEndProperty

    let SelectionBrushWidget =
        Attributes.defineAvaloniaPropertyWidget SelectableTextBlock.SelectionBrushProperty

    let SelectionBrush =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionBrushProperty

    let CopyingToClipboard =
        Attributes.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target -> (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module SelectableTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SelectableTextBlock widget</summary>
        /// <param name="text">The text to display</param>
        /// <param name="fn">Raised when the user copies the text to the clipboard</param>
        static member inline SelectableTextBlock<'msg>(text: string, fn: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                SelectableTextBlock.CopyingToClipboard.WithValue(fun args -> fn args |> box)
            )

        /// <summary>Creates a SelectableTextBlock widget</summary>
        /// <param name="fn">Raised when the user copies the text to the clipboard</param>
        static member inline SelectableTextBlock(fn: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Inlines,
                SelectableTextBlock.CopyingToClipboard.WithValue(fun args -> fn args |> box)
            )

[<Extension>]
type SelectableTextBlockModifiers =

    /// <summary>Sets the SelectionStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionStart value</param>
    [<Extension>]
    static member inline selectionStart(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionStart.WithValue(value))

    /// <summary>Sets the SelectionEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionEnd value</param>
    [<Extension>]
    static member inline selectionEnd(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionEnd.WithValue(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(SelectableTextBlock.SelectionBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: IBrush) =
        this.AddScalar(SelectableTextBlock.SelectionBrush.WithValue(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: string) =
        this.AddScalar(SelectableTextBlock.SelectionBrush.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Link a ViewRef to access the direct SelectableTextBlock control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSelectableTextBlock>, value: ViewRef<SelectableTextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type SelectableTextBlockCollectionBuilderExtensions =
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
