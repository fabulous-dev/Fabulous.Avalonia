namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
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

        static member inline SelectableTextBlock<'msg>(text: string, onCopyingToClipboard: string -> 'msg) =
            WidgetBuilder<'msg, IFabSelectableTextBlock>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Text.WithValue(text),
                SelectableTextBlock.CopyingToClipboard.WithValue(fun args ->
                    let control = args.Source :?> SelectableTextBlock
                    onCopyingToClipboard control.SelectedText |> box)
            )

        static member inline SelectableTextBlock(onCopyingToClipboard: string -> 'msg) =
            CollectionBuilder<'msg, IFabSelectableTextBlock, IFabInline>(
                SelectableTextBlock.WidgetKey,
                TextBlock.Inlines,
                SelectableTextBlock.CopyingToClipboard.WithValue(fun args ->
                    let control = args.Source :?> SelectableTextBlock
                    onCopyingToClipboard control.SelectedText |> box)
            )

[<Extension>]
type SelectableTextBlockModifiers =

    [<Extension>]
    static member inline selectionStart(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionStart.WithValue(value))

    [<Extension>]
    static member inline selectionEnd(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, value: int) =
        this.AddScalar(SelectableTextBlock.SelectionEnd.WithValue(value))

    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(SelectableTextBlock.SelectionBrushWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, brush: IBrush) =
        this.AddScalar(SelectableTextBlock.SelectionBrush.WithValue(brush))

    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabSelectableTextBlock>, brush: string) =
        this.AddScalar(SelectableTextBlock.SelectionBrush.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

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
