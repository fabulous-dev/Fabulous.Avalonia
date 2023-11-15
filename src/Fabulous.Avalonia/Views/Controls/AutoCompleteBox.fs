namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous

type IFabAutoCompleteBox =
    inherit IFabTemplatedControl

module AutoCompleteBox =
    let WidgetKey = Widgets.register<AutoCompleteBox>()

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

    let ItemsSource =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemsSourceProperty

    let AsyncPopulator =
        Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.AsyncPopulatorProperty

    let TextChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target -> (target :?> AutoCompleteBox).SelectionChanged)

[<AutoOpen>]
module AutoCompleteBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CalendarDatePicker widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        /// <param name="items">The items to display.</param>
        static member inline AutoCompleteBox(text: string, fn: string -> 'msg, items: seq<_>) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(
                AutoCompleteBox.WidgetKey,
                AutoCompleteBox.ItemsSource.WithValue(items),
                AutoCompleteBox.TextChanged.WithValue(ValueEventData.create text fn)
            )

        /// <summary>Creates a CalendarDatePicker widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the text changes.</param>
        /// <param name="populator">The function to populate the items.</param>
        static member inline AutoCompleteBox(text: string, fn: string -> 'msg, populator: string -> CancellationToken -> Task<seq<_>>) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(
                AutoCompleteBox.WidgetKey,
                AutoCompleteBox.AsyncPopulator.WithValue(populator),
                AutoCompleteBox.TextChanged.WithValue(ValueEventData.create text fn)
            )

type AutoCompleteBoxModifiers =
    /// <summary>Sets the MinimumPrefixLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinimumPrefixLength value.</param>
    [<Extension>]
    static member inline minimumPrefixLength(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: int) =
        this.AddScalar(AutoCompleteBox.MinimumPrefixLength.WithValue(value))

    /// <summary>Sets the MinimumPopulateDelay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinimumPopulateDelay value.</param>
    [<Extension>]
    static member inline minimumPopulateDelay(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: TimeSpan) =
        this.AddScalar(AutoCompleteBox.MinimumPopulateDelay.WithValue(value))

    /// <summary>Sets the MaxDropDownHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxDropDownHeight value.</param>
    [<Extension>]
    static member inline maxDropDownHeight(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: float) =
        this.AddScalar(AutoCompleteBox.MaxDropDownHeight.WithValue(value))

    /// <summary>Sets the IsTextCompletionEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTextCompletionEnabled value.</param>
    [<Extension>]
    static member inline isTextCompletionEnabled(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: bool) =
        this.AddScalar(AutoCompleteBox.IsTextCompletionEnabled.WithValue(value))

    /// <summary>Sets the Watermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Watermark value.</param>
    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string) =
        this.AddScalar(AutoCompleteBox.Watermark.WithValue(value))

    /// <summary>Sets the FilterMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FilterMode value.</param>
    [<Extension>]
    static member inline filterMode(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: AutoCompleteFilterMode) =
        this.AddScalar(AutoCompleteBox.FilterMode.WithValue(value))

    /// <summary>Sets the ItemFilter property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The ItemFilter value.</param>
    [<Extension>]
    static member inline itemFilter(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: string -> obj -> bool) =
        this.AddScalar(AutoCompleteBox.ItemFilter.WithValue(fn))

    /// <summary>Sets the TextFilter property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextFilter value.</param>
    [<Extension>]
    static member inline textFilter(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string -> string -> bool) =
        this.AddScalar(AutoCompleteBox.TextFilter.WithValue(value))

    /// <summary>Sets the ItemSelector property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ItemSelector value.</param>
    [<Extension>]
    static member inline itemSelector(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string -> obj -> string) =
        this.AddScalar(AutoCompleteBox.ItemSelector.WithValue(value))

    /// <summary>Sets the TextSelector property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextSelector value.</param>
    [<Extension>]
    static member inline textSelector(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string -> string -> string) =
        this.AddScalar(AutoCompleteBox.TextSelector.WithValue(value))

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatingEventArgs -> 'msg) =
        this.AddScalar(AutoCompleteBox.Populating.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox Populated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox Populated event is fired.</param>
    [<Extension>]
    static member inline onPopulated(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: PopulatedEventArgs -> 'msg) =
        this.AddScalar(AutoCompleteBox.Populated.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">The IsOpen value.</param>
    /// <param name="fn">Raised when the AutoCompleteBox DropDownOpened event is fired.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, isOpen: bool, fn: bool -> 'msg) =
        this.AddScalar(AutoCompleteBox.DropDownOpened.WithValue(ValueEventData.create isOpen fn))

    /// <summary>Listens to the AutoCompleteBox SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(AutoCompleteBox.SelectionChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct AutoCompleteBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAutoCompleteBox>, value: ViewRef<AutoCompleteBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
