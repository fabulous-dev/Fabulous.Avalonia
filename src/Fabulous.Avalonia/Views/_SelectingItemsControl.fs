namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous

type IFabSelectingItemsControl =
    inherit IFabItemsControl

module SelectingItemsControl =
    let AutoScrollToSelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.AutoScrollToSelectedItemProperty

    let SelectedIndex =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.SelectedIndexProperty

    let IsTextSearchEnabled =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.IsTextSearchEnabledProperty

    let WrapSelection =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.WrapSelectionProperty

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.IsSelectedProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "SelectingItemsControl_SelectionChanged" (fun target ->
            (target :?> SelectingItemsControl).SelectionChanged)

    let SelectedIndexChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedIndexChanged" SelectingItemsControl.SelectedIndexProperty

[<Extension>]
type SelectingItemsControlModifiers =
    /// <summary>Sets the AutoScrollToSelectedItem property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoScrollToSelectedItem value.</param>
    [<Extension>]
    static member inline autoScrollToSelectedItem(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.AutoScrollToSelectedItem.WithValue(value))

    /// <summary>Sets the SelectedIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedIndex value.</param>
    [<Extension>]
    static member inline selectedIndex(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: int) =
        this.AddScalar(SelectingItemsControl.SelectedIndex.WithValue(value))

    /// <summary>Sets the IsTextSearchEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTextSearchEnabled value.</param>
    [<Extension>]
    static member inline isTextSearchEnabled(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsTextSearchEnabled.WithValue(value))

    /// <summary>Sets the WrapSelection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WrapSelection value.</param>
    [<Extension>]
    static member inline wrapSelection(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.WrapSelection.WithValue(value))

    /// <summary>Sets the IsSelected property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSelected value.</param>
    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsSelected.WithValue(value))

    /// <summary>Listens to the SelectingItemsControl SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(SelectingItemsControl.SelectionChanged.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the SelectingItemsControl SelectedIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selected index changes.</param>
    [<Extension>]
    static member inline onSelectedIndexChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, index: int, fn: int -> 'msg) =
        this.AddScalar(SelectingItemsControl.SelectedIndexChanged.WithValue(ValueEventData.create index (fun args -> fn args |> box)))
