namespace Fabulous.Avalonia

open System
open System.ComponentModel
open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous

type IFabAutoCompleteBox =
    inherit IFabTemplatedControl

module AutoCompleteBox =
    let WidgetKey = Widgets.register<AutoCompleteBox> ()

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.WatermarkProperty

    let MinimumPrefixLength =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MinimumPrefixLengthProperty

    let MinimumPopulateDelay =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MinimumPopulateDelayProperty

    let MaxDropDownHeight =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MaxDropDownHeightProperty

    let IsTextCompletionEnabled =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.IsTextCompletionEnabledProperty

    let IsDropDownOpen =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.IsDropDownOpenProperty

    //let SelectedItem = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.SelectedItemProperty
    let SelectedItem<'T when 'T: equality> =
        Attributes.defineSimpleScalar<'T>
            "AutoCompleteBox_SelectedItem"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let control = node.Target :?> AutoCompleteBox

                match newValueOpt with
                | ValueNone -> control.ClearValue(AutoCompleteBox.SelectedItemProperty)
                | ValueSome value -> control.SetValue(AutoCompleteBox.SelectedItemProperty, value))

    let Text =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextProperty

    let FilterMode =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.FilterModeProperty

    let ItemFilter =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemFilterProperty

    let TextFilter =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextFilterProperty

    let ItemSelector =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemSelectorProperty

    let TextSelector =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextSelectorProperty

    let Items<'T when 'T: equality> =
        Attributes.defineSimpleScalar<'T>
            "AutoCompleteBox_Items"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let autoCompleteBox = node.Target :?> AutoCompleteBox

                match newValueOpt with
                | ValueNone -> autoCompleteBox.ClearValue(AutoCompleteBox.ItemsProperty)
                | ValueSome value -> autoCompleteBox.SetValue(AutoCompleteBox.ItemsProperty, value) |> ignore)

    let AsyncPopulator =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.AsyncPopulatorProperty

    let TextChanged =
        Attributes.defineEvent<TextChangedEventArgs> "AutoCompleteBox_TextChanged" (fun target ->
            (target :?> AutoCompleteBox).TextChanged)

    let Populating =
        Attributes.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target ->
            (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target ->
            (target :?> AutoCompleteBox).Populated)

    let DropDownOpening =
        Attributes.defineEvent<CancelEventArgs> "AutoCompleteBox_DropDownOpening" (fun target ->
            (target :?> AutoCompleteBox).DropDownOpening)

    let DropDownOpened =
        Attributes.defineEventNoArg "AutoCompleteBox_DropDownOpened" (fun target ->
            (target :?> AutoCompleteBox).DropDownOpened)

    let DropDownClosing =
        Attributes.defineEvent<CancelEventArgs> "AutoCompleteBox_DropDownClosing" (fun target ->
            (target :?> AutoCompleteBox).DropDownClosing)

    let DropDownClosed =
        Attributes.defineEventNoArg "AutoCompleteBox_DropDownClosed" (fun target ->
            (target :?> AutoCompleteBox).DropDownClosed)

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target ->
            (target :?> AutoCompleteBox).SelectionChanged)

[<AutoOpen>]
module AutoCompleteBoxBuilders =
    type Fabulous.Avalonia.View with

        static member AutoCompleteBox(watermark: string, items: string list) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(
                AutoCompleteBox.WidgetKey,
                AutoCompleteBox.Watermark.WithValue(watermark),
                AutoCompleteBox.Items.WithValue(items)
            )

[<Extension>]
type AutoCompleteBoxModifiers =
    [<Extension>]
    static member inline minimumPrefixLength(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: int) =
        this.AddScalar(AutoCompleteBox.MinimumPrefixLength.WithValue(value))

    [<Extension>]
    static member inline minimumPopulateDelay(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: TimeSpan) =
        this.AddScalar(AutoCompleteBox.MinimumPopulateDelay.WithValue(value))

    [<Extension>]
    static member inline maxDropDownHeight(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: float) =
        this.AddScalar(AutoCompleteBox.MaxDropDownHeight.WithValue(value))

    [<Extension>]
    static member inline isTextCompletionEnabled(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: bool) =
        this.AddScalar(AutoCompleteBox.IsTextCompletionEnabled.WithValue(value))

    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: bool) =
        this.AddScalar(AutoCompleteBox.IsDropDownOpen.WithValue(value))

    [<Extension>]
    static member inline selectedItem(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: 'T) =
        this.AddScalar(AutoCompleteBox.SelectedItem.WithValue(value))

    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string) =
        this.AddScalar(AutoCompleteBox.Text.WithValue(value))

    [<Extension>]
    static member inline filterMode(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: AutoCompleteFilterMode) =
        this.AddScalar(AutoCompleteBox.FilterMode.WithValue(value))

    [<Extension>]
    static member inline itemFilter(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, filter: string -> obj -> bool) =
        this.AddScalar(AutoCompleteBox.ItemFilter.WithValue(filter))

    [<Extension>]
    static member inline textFilter(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, filter: string -> string -> bool) =
        this.AddScalar(AutoCompleteBox.TextFilter.WithValue(filter))

    [<Extension>]
    static member inline itemSelector
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            selector: string -> obj -> string
        ) =
        this.AddScalar(AutoCompleteBox.ItemSelector.WithValue(selector))

    [<Extension>]
    static member inline textSelector
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            selector: string -> string -> string
        ) =
        this.AddScalar(AutoCompleteBox.TextSelector.WithValue(selector))

    [<Extension>]
    static member inline asyncPopulator
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            populator: string -> CancellationToken -> Task<obj seq>
        ) =
        this.AddScalar(AutoCompleteBox.AsyncPopulator.WithValue(populator))

    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, onTextChanged: string -> 'msg) =
        this.AddScalar(
            AutoCompleteBox.TextChanged.WithValue(fun args ->
                let control = args.Source :?> AutoCompleteBox
                onTextChanged control.Text |> box)
        )

    [<Extension>]
    static member inline onPopulating
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onPopulating: PopulatingEventArgs -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.Populating.WithValue(fun args -> onPopulating args |> box))

    [<Extension>]
    static member inline onPopulated
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onPopulated: PopulatedEventArgs -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.Populated.WithValue(fun args -> onPopulated args |> box))

    [<Extension>]
    static member inline onDropDownOpening
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onDropDownOpening: bool -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.DropDownOpening.WithValue(fun args -> onDropDownOpening args.Cancel |> box))

    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, onDropDownOpened: 'msg) =
        this.AddScalar(AutoCompleteBox.DropDownOpened.WithValue(fun _ -> onDropDownOpened |> box))

    [<Extension>]
    static member inline onDropDownClosing
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onDropDownClosing: bool -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.DropDownClosing.WithValue(fun args -> onDropDownClosing args.Cancel |> box))

    [<Extension>]
    static member inline onDropDownClosed(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, onDropDownClosed: 'msg) =
        this.AddScalar(AutoCompleteBox.DropDownClosed.WithValue(fun _ -> onDropDownClosed |> box))

    [<Extension>]
    static member inline onSelectionChanged
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onSelectionChanged: SelectionChangedEventArgs -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.SelectionChanged.WithValue(fun args -> onSelectionChanged args |> box))
