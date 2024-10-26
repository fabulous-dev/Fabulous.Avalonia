namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open System.Threading
open System.Threading.Tasks
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuAutoCompleteBox =
    inherit IFabMvuTemplatedControl
    inherit IFabAutoCompleteBox

module MvuAutoCompleteBox =
    let Text =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_TextChanged" AutoCompleteBox.TextProperty

    let Populating =
        Attributes.defineEvent<PopulatingEventArgs> "AutoCompleteBox_Populating" (fun target -> (target :?> AutoCompleteBox).Populating)

    let Populated =
        Attributes.defineEvent<PopulatedEventArgs> "AutoCompleteBox_Populated" (fun target -> (target :?> AutoCompleteBox).Populated)

    let DropDownOpened =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "AutoCompleteBox_onDropDownOpened" AutoCompleteBox.IsDropDownOpenProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "AutoCompleteBox_SelectionChanged" (fun target -> (target :?> AutoCompleteBox).SelectionChanged)

[<AutoOpen>]
module MvuAutoCompleteBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="items">The items to display.</param>
        static member AutoCompleteBox(items: seq<_>) =
            WidgetBuilder<unit, IFabMvuAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.ItemsSource.WithValue(items))

        /// <summary>Creates an AutoCompleteBox widget.</summary>
        /// <param name="populator">The function to populate the items.</param>
        static member AutoCompleteBox(populator: string -> CancellationToken -> Task<seq<_>>) =
            WidgetBuilder<unit, IFabMvuAutoCompleteBox>(AutoCompleteBox.WidgetKey, AutoCompleteBox.AsyncPopulator.WithValue(populator))

type MvuAutoCompleteBoxModifiers =
    /// <summary>Binds the AutoCompleteBox.TextProperty.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to bind.</param>
    /// <param name="fn">A function mapping the updated text to a 'msg to raise on user change.</param>
    [<Extension>]
    static member inline onTextChanged(this: WidgetBuilder<unit, #IFabMvuAutoCompleteBox>, value: string, fn: string -> unit) =
        this.AddScalar(MvuAutoCompleteBox.Text.WithValue(MvuValueEventData.create value fn))

    [<Extension>]
    static member inline onPopulating(this: WidgetBuilder<unit, #IFabMvuAutoCompleteBox>, fn: PopulatingEventArgs -> unit) =
        this.AddScalar(MvuAutoCompleteBox.Populating.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox Populated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox Populated event is fired.</param>
    [<Extension>]
    static member inline onPopulated(this: WidgetBuilder<unit, #IFabMvuAutoCompleteBox>, fn: PopulatedEventArgs -> unit) =
        this.AddScalar(MvuAutoCompleteBox.Populated.WithValue(fn))

    /// <summary>Listens to the AutoCompleteBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">The IsOpen value.</param>
    /// <param name="fn">Raised when the AutoCompleteBox DropDownOpened event is fired.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<unit, #IFabMvuAutoCompleteBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(MvuAutoCompleteBox.DropDownOpened.WithValue(MvuValueEventData.create isOpen fn))

    /// <summary>Listens to the AutoCompleteBox SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the AutoCompleteBox SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<unit, #IFabMvuAutoCompleteBox>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(MvuAutoCompleteBox.SelectionChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct AutoCompleteBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuAutoCompleteBox>, value: ViewRef<AutoCompleteBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
