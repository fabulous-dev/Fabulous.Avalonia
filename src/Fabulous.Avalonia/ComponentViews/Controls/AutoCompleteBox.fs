namespace Fabulous.Avalonia.Components

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

    let Text =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target -> (target :?> AutoCompleteBox).SelectionChanged)

    /// Allows multi-binding the ValueMemberBinding on an AutoCompleteBox
    let MultiValueBinding =
        Attributes.defineSimpleScalar<string * string array>
            "AutoCompleteBox_MultiValueBinding"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                if newValueOpt.IsSome then
                    let format, propertyNames = newValueOpt.Value
                    let target = node.Target :?> AutoCompleteBox

                    let rec bindAndCleanUp _ _ =
                        target.multiBind<AutoCompleteBox>((fun (box: AutoCompleteBox) -> box.ValueMemberBinding), format, propertyNames)
                        target.Loaded.RemoveHandler(bindAndCleanUp) // to clean up

                    target.Loaded.AddHandler(bindAndCleanUp))

    /// Allows setting the ItemTemplate on an AutoCompleteBox
    let ItemTemplate =
        Attributes.defineSimpleScalar<obj -> Widget> "AutoCompleteBox_ItemTemplate" ScalarAttributeComparers.physicalEqualityCompare (fun _ newValueOpt node ->
            let autoComplete = node.Target :?> AutoCompleteBox

            match newValueOpt with
            | ValueNone -> autoComplete.ClearValue(AutoCompleteBox.ItemTemplateProperty)
            | ValueSome template ->
                autoComplete.SetValue(AutoCompleteBox.ItemTemplateProperty, WidgetDataTemplate(node, template))
                |> ignore)

[<AutoOpen>]
module AutoCompleteBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="items">The items to display.</param>
        static member AutoCompleteBox(items: seq<_>) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.ItemsSource.WithValue(items))

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="populator">The function to populate the items.</param>
        static member AutoCompleteBox(populator: string -> CancellationToken -> Task<seq<_>>) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.AsyncPopulator.WithValue(populator))

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

    /// <summary>Sets the ItemTemplate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="template">The template to render the items with.</param>
    [<Extension>]
    static member inline itemTemplate(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, template: 'item -> WidgetBuilder<'msg, #IFabControl>) =
        this.AddScalar(AutoCompleteBox.ItemTemplate.WithValue(WidgetHelpers.compileTemplate template))

    /// <summary>Sets the TextFilter property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextFilter value.</param>
    [<Extension>]
    static member inline textFilter(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string -> string -> bool) =
        this.AddScalar(AutoCompleteBox.TextFilter.WithValue(value))

    /// <summary>Binds the AutoCompleteBox.TextProperty.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to bind.</param>
    /// <param name="fn">A function mapping the updated text to a 'msg to raise on user change.</param>
    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string, fn: string -> 'msg) =
        this.AddScalar(AutoCompleteBox.Text.WithValue(ValueEventData.create value fn))

    /// <summary>Sets the AutoCompleteBox.ItemSelector property to a custom method that combines the user-entered text
    /// and the selected item to return the new text input value.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">A custom method receiving the entered text as the first
    /// and the selected item as the second argument and returns the updated text of the input after selection.</param>
    [<Extension>]
    static member inline itemSelector(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, value: string -> obj -> string) =
        this.AddScalar(AutoCompleteBox.ItemSelector.WithValue(value))

    /// <summary>Sets the AutoCompleteBox.TextSelector property to a custom method that combines the user-entered text
    /// and the selected item's text to return the new text input value.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">A custom method receiving the entered text as the first
    /// and the text of the selected item as the second argument and returns the updated text of the input after selection.</param>
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

    /// <Summary>Allows multi-binding the ValueMemberBinding on an AutoCompleteBox.</Summary>
    /// <param name="this">Current widget.</param>
    /// <param name="format">The format string to use.</param>
    /// <param name="propertyNames">The property names to bind.</param>
    [<Extension>]
    static member inline multiBindValue(this: WidgetBuilder<'msg, #IFabAutoCompleteBox>, format: string, [<ParamArray>] propertyNames: string array) =
        this.AddScalar(AutoCompleteBox.MultiValueBinding.WithValue((format, propertyNames)))
