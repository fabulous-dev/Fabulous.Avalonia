namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabSelectableTextBlock =
    inherit IFabTextBlock

module SelectableTextBlock =
    let WidgetKey = Widgets.register<SelectableTextBlock>()

    let SelectionStart =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionStartProperty

    let SelectionEnd =
        Attributes.defineAvaloniaPropertyWithEquality SelectableTextBlock.SelectionEndProperty

    let SelectedTextChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent'
            "SelectableTextBlock_SelectedTextChanged"
            SelectableTextBlock.SelectedTextProperty

    let SelectionBrush =
        Attributes.defineAvaloniaPropertyWidget SelectableTextBlock.SelectionBrushProperty

    let CopyingToClipboard =
        Attributes.defineEvent "SelectableTextBlock_CopyingToClipboard" (fun target ->
            (target :?> SelectableTextBlock).CopyingToClipboard)

[<AutoOpen>]
module SelectableTextBlockBuilders =
    type Fabulous.Avalonia.View with

        static member inline SelectableTextBlock<'msg>(?text: string) =
            match text with
            | Some text ->
                WidgetBuilder<'msg, IFabSelectableTextBlock>(
                    SelectableTextBlock.WidgetKey,
                    TextBlock.Text.WithValue(text)
                )
            | None ->
                WidgetBuilder<'msg, IFabSelectableTextBlock>(
                    SelectableTextBlock.WidgetKey,
                    AttributesBundle(StackList.empty(), ValueNone, ValueNone)
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
    static member inline selectionBrush
        (
            this: WidgetBuilder<'msg, #IFabSelectableTextBlock>,
            content: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(SelectableTextBlock.SelectionBrush.WithValue(content.Compile()))

    [<Extension>]
    static member inline onCopyingToClipboard
        (
            this: WidgetBuilder<'msg, #IFabSelectableTextBlock>,
            onCopyingToClipboard: string -> 'msg
        ) =
        this.AddScalar(
            SelectableTextBlock.CopyingToClipboard.WithValue(fun args ->
                let control = args.Source :?> SelectableTextBlock
                onCopyingToClipboard control.SelectedText |> box)
        )
