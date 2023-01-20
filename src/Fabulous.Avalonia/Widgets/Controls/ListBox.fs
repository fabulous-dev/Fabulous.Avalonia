namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open System.Runtime.CompilerServices

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox> ()

    let ItemsSource =
        Attributes.defineSimpleScalar<StringTemplate>
            "ListBox_Items"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone -> itemsView.ClearValue(ListBox.ItemsProperty)
                | ValueSome value ->
                    itemsView.SetValue(
                        ListBox.ItemsProperty,
                        value.OriginalItems :?> seq<obj> |> Seq.map (fun x -> value.Template x)
                    ))

    (*
    let WidgetItemsSource =
        Attributes.defineSimpleScalar<WidgetTemplate>
            "ListBox_Items"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone -> itemsView.ClearValue(ListBox.ItemsProperty)
                | ValueSome value -> itemsView.SetValue(ListBox.ItemsProperty, value.OriginalItems :?> seq<obj> |> Seq.map (fun x -> value.Template x)))
    *)

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

        static member inline ListBox<'msg>(items: seq<string>) =
            WidgetHelpers.buildItems<'msg, IFabListBox, string, string>
                ListBox.WidgetKey
                ListBox.ItemsSource
                items
                (fun x -> x)

        static member inline ListBox<'msg, 'itemData>(items: seq<'itemData>, template: 'itemData -> string) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, string>
                ListBox.WidgetKey
                ListBox.ItemsSource
                items
                template

        static member ListBox() =
            CollectionBuilder<'msg, IFabListBox, IFabListBoxItem>(ListBox.WidgetKey, ItemsControl.Items)

(*
        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabListBoxItem>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildWidgetItems<'msg, IFabListBox, 'itemData, 'itemMarker>
                ListBox.WidgetKey
                ListBox.WidgetItemsSource
                items
                template
        *)

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

[<Extension>]
type ListBoxCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabListBoxItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabListBoxItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
