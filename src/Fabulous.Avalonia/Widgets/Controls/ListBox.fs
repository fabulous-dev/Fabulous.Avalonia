namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox>()

    let ItemsSource<'T> =
        Attributes.defineSimpleScalar<WidgetItems<'T>>
            "ListBox_Items"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone -> itemsView.ClearValue(ListBox.ItemsProperty)
                | ValueSome value -> itemsView.SetValue(ListBox.ItemsProperty, value.OriginalItems))

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty

    let VirtualizationMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.VirtualizationModeProperty

    let SelectedItems<'T when 'T: equality> =
        Attributes.defineSimpleScalar
            "SelectingItemsControl_SelectedItems"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let control = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone -> control.ClearValue(ListBox.SelectedItemsProperty)
                | ValueSome value -> control.SetValue(ListBox.SelectedItemsProperty, value))

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabListBoxItem>
            (items: seq<'itemData>)
            =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker>
                ListBox.WidgetKey
                ListBox.ItemsSource
                items

[<Extension>]
type ListBoxModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListBox>, value: SelectionMode) =
        this.AddScalar(ListBox.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline virtualizationMode(this: WidgetBuilder<'msg, #IFabListBox>, value: ItemVirtualizationMode) =
        this.AddScalar(ListBox.VirtualizationMode.WithValue(value))

    [<Extension>]
    static member inline selectedItems(this: WidgetBuilder<'msg, #IFabListBox>, value: obj list) =
        this.AddScalar(ListBox.SelectedItems.WithValue(ResizeArray(value)))
