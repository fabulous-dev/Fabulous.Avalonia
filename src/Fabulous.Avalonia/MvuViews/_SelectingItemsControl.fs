namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuSelectingItemsControl =
    inherit IFabMvuItemsControl
    inherit IFabSelectingItemsControl

module MvuSelectingItemsControl =
    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "SelectingItemsControl_SelectionChanged" (fun target ->
            (target :?> SelectingItemsControl).SelectionChanged)

    let SelectedIndexChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedIndexChanged" SelectingItemsControl.SelectedIndexProperty

type MvuSelectingItemsControlModifiers =
    /// <summary>Listens to the SelectingItemsControl SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<unit, #IFabMvuSelectingItemsControl>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(MvuSelectingItemsControl.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the SelectingItemsControl SelectedIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="index">Selected index</param>
    /// <param name="fn">Raised when the control's selected index changes.</param>
    [<Extension>]
    static member inline onSelectedIndexChanged(this: WidgetBuilder<unit, #IFabMvuSelectingItemsControl>, index: int, fn: int -> unit) =
        this.AddScalar(MvuSelectingItemsControl.SelectedIndexChanged.WithValue(MvuValueEventData.create index fn))
