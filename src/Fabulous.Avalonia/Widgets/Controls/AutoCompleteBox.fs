namespace Fabulous.Avalonia

open System
open System.Collections.Generic
open System.Collections
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

    let SelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.SelectedItemProperty

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

    let Items =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemsProperty

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

    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent'
            "AutoCompleteBox_onDropDownOpened"
            AutoCompleteBox.IsDropDownOpenProperty

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

        static member AutoCompleteBox(watermark: string, populator: string -> CancellationToken -> Task<seq<obj>>) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(
                AutoCompleteBox.WidgetKey,
                AutoCompleteBox.Watermark.WithValue(watermark),
                AutoCompleteBox.AsyncPopulator.WithValue(populator)
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
    static member inline selectedItem(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: obj) =
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
    static member inline onTextChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, onTextChanged: string -> 'msg) =
        this.AddScalar(
            AutoCompleteBox.TextChanged.WithValue(fun args ->
                let control = args.Source :?> AutoCompleteBox
                onTextChanged control.Text |> box)
        )

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, onPopulating: string -> 'msg) =
        this.AddScalar(AutoCompleteBox.Populating.WithValue(fun args -> onPopulating args.Parameter |> box))

    [<Extension>]
    static member inline onPopulated
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onPopulated: IEnumerable -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.Populated.WithValue(fun args -> onPopulated args.Data |> box))

    [<Extension>]
    static member inline onDropDownOpened
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            isOpen: bool,
            onDropDownOpened: bool -> 'msg
        ) =
        this.AddScalar(
            AutoCompleteBox.DropDownOpened.WithValue(
                ValueEventData.create isOpen (fun args -> onDropDownOpened args |> box)
            )
        )

    [<Extension>]
    static member inline onSelectionChanged
        (
            this: WidgetBuilder<'msg, #IFabAutoCompleteBox>,
            onSelectionChanged: SelectionChangedEventArgs -> 'msg
        ) =
        this.AddScalar(AutoCompleteBox.SelectionChanged.WithValue(fun args -> onSelectionChanged args |> box))
