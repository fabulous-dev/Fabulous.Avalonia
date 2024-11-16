namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module MvuSelectingItemsControl =
    let SelectionChanged =
        Attributes.Mvu.defineEvent<SelectionChangedEventArgs> "SelectingItemsControl_SelectionChanged" (fun target ->
            (target :?> SelectingItemsControl).SelectionChanged)

    let SelectedIndexChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedIndexChanged" SelectingItemsControl.SelectedIndexProperty

type MvuSelectingItemsControlModifiers =
    /// <summary>Listens to the SelectingItemsControl SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(MvuSelectingItemsControl.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the SelectingItemsControl SelectedIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="index">Selected index</param>
    /// <param name="fn">Raised when the control's selected index changes.</param>
    [<Extension>]
    static member inline onSelectedIndexChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, index: int, fn: int -> 'msg) =
        this.AddScalar(MvuSelectingItemsControl.SelectedIndexChanged.WithValue(ValueEventData.create index fn))
