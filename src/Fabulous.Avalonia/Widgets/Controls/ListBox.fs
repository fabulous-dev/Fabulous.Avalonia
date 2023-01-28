namespace Fabulous.Avalonia

open System.Collections.Generic
open Avalonia.Controls
open Fabulous

type IFabListBox =
    inherit IFabSelectingItemsControl

module ListBox =
    let WidgetKey = Widgets.register<ListBox>()

    let Items =
        Attributes.defineListWidgetCollection "ListBox_Items" (fun target -> (target :?> ListBox).Items :?> IList<_>)

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ListBox_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone ->
                    itemsView.ClearValue(ListBox.ItemTemplateProperty)
                    itemsView.ClearValue(ListBox.ItemsProperty)
                | ValueSome value ->
                    itemsView.SetValue(ListBox.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    itemsView.SetValue(ListBox.ItemsProperty, value.OriginalItems))

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty

    let VirtualizationMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.VirtualizationModeProperty

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBox<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ListBox.ItemsSource items template

        static member inline ListBox<'msg>() =
            CollectionBuilder<'msg, IFabListBox, IFabControl>(ListBox.WidgetKey, ListBox.Items)
