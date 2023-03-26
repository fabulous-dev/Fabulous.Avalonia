namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
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
                let listBox = node.Target :?> ListBox

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(ListBox.ItemTemplateProperty)
                    listBox.ClearValue(ListBox.ItemsSourceProperty)
                | ValueSome value ->
                    listBox.SetValue(ListBox.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template, true))
                    |> ignore

                    listBox.SetValue(ListBox.ItemsSourceProperty, value.OriginalItems) |> ignore)

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality ListBox.SelectionModeProperty


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

[<Extension>]
type ListBoxModifiers =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListBox>, value: SelectionMode) =
        this.AddScalar(ListBox.SelectionMode.WithValue(value))
