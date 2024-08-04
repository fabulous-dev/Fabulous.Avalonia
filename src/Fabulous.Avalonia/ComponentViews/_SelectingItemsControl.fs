namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentSelectingItemsControl =
    inherit IFabComponentItemsControl
    inherit IFabSelectingItemsControl

module ComponentSelectingItemsControl =
    let SelectionChanged =
        ComponentAttributes.defineEvent<SelectionChangedEventArgs> "SelectingItemsControl_SelectionChanged" (fun target ->
            (target :?> SelectingItemsControl).SelectionChanged)

    let SelectedIndexChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedIndexChanged" SelectingItemsControl.SelectedIndexProperty

type ComponentSelectingItemsControlModifiers =
    /// <summary>Listens to the SelectingItemsControl SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<unit, #IFabComponentSelectingItemsControl>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentSelectingItemsControl.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the SelectingItemsControl SelectedIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="index">Selected index</param>
    /// <param name="fn">Raised when the control's selected index changes.</param>
    [<Extension>]
    static member inline onSelectedIndexChanged(this: WidgetBuilder<unit, #IFabComponentSelectingItemsControl>, index: int, fn: int -> unit) =
        this.AddScalar(ComponentSelectingItemsControl.SelectedIndexChanged.WithValue(ComponentValueEventData.create index fn))
