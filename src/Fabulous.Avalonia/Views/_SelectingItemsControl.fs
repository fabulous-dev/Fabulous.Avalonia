namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Selection
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
    [<Extension>]
    static member inline autoScrollToSelectedItem(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.AutoScrollToSelectedItem.WithValue(value))

    [<Extension>]
    static member inline selectedIndex(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: int) =
        this.AddScalar(SelectingItemsControl.SelectedIndex.WithValue(value))

    [<Extension>]
    static member inline isTextSearchEnabled(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsTextSearchEnabled.WithValue(value))

    [<Extension>]
    static member inline wrapSelection(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.WrapSelection.WithValue(value))

    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsSelected.WithValue(value))

    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, onSelectionChanged: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(SelectingItemsControl.SelectionChanged.WithValue(fun args -> onSelectionChanged args |> box))

    [<Extension>]
    static member inline selectedIndexChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, index: int, selectedIndexChanged: int -> 'msg) =
        this.AddScalar(SelectingItemsControl.SelectedIndexChanged.WithValue(ValueEventData.create index (fun args -> selectedIndexChanged args |> box)))
