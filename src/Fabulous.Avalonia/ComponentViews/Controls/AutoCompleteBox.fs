namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentAutoCompleteBox =
    inherit IFabComponentTemplatedControl
    inherit IFabAutoCompleteBox

module ComponentAutoCompleteBox =
    let Text =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.defineEventNoDispatch<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.defineEventNoDispatch<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.defineEventNoDispatch<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target ->
            (target :?> AutoCompleteBox).SelectionChanged)

[<AutoOpen>]
module ComponentAutoCompleteBoxBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="items">The items to display.</param>
        static member AutoCompleteBox(items: seq<_>) =
            WidgetBuilder<unit, IFabComponentAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.ItemsSource.WithValue(items))

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="populator">The function to populate the items.</param>
        static member AutoCompleteBox(populator: string -> CancellationToken -> Task<seq<_>>) =
            WidgetBuilder<unit, IFabComponentAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.AsyncPopulator.WithValue(populator))

type ComponentAutoCompleteBoxModifiers =
    /// <summary>Binds the AutoCompleteBox.TextProperty.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to bind.</param>
    /// <param name="fn">A function mapping the updated text to a 'msg to raise on user change.</param>
    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<unit, #IFabComponentAutoCompleteBox>, value: string, fn: string -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Text.WithValue(ComponentValueEventData.create value fn))

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<unit, #IFabComponentAutoCompleteBox>, fn: PopulatingEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Populating.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox Populated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox Populated event is fired.</param>
    [<Extension>]
    static member inline onPopulated(this: WidgetBuilder<unit, #IFabComponentAutoCompleteBox>, fn: PopulatedEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.Populated.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">The IsOpen value.</param>
    /// <param name="fn">Raised when the AutoCompleteBox DropDownOpened event is fired.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<unit, #IFabComponentAutoCompleteBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.DropDownOpened.WithValue(ComponentValueEventData.create isOpen fn))

    /// <summary>Listens to the AutoCompleteBox SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<unit, #IFabComponentAutoCompleteBox>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentAutoCompleteBox.SelectionChanged.WithValue(fn))
