namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let WidgetKey = Widgets.register<ItemsControl>()


    let ItemsSourceTemplate =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsControl_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itmsCtrl = node.Target :?> ItemsControl

                match newValueOpt with
                | ValueNone ->
                    itmsCtrl.ClearValue(ItemsControl.ItemTemplateProperty)
                    itmsCtrl.ClearValue(ItemsControl.ItemsSourceProperty)
                | ValueSome value ->
                    itmsCtrl.SetValue(ItemsControl.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    itmsCtrl.SetValue(ItemsControl.ItemsSourceProperty, value.OriginalItems)
                    |> ignore)

    let ItemsSource =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.ItemsSourceProperty

    let ItemsPanel =
        Attributes.defineSimpleScalar<Widget> "ItemsControl_ItemsPanel" ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let itemsControl = node.Target :?> ItemsControl

            match newValueOpt with
            | ValueNone -> itemsControl.ClearValue(ItemsControl.ItemsPanelProperty)
            | ValueSome value ->
                itemsControl.SetValue(ItemsControl.ItemsPanelProperty, WidgetItemsPanel(node, value))
                |> ignore)
        
[<AutoOpen>]
module ItemsControlBuilders =
    type Fabulous.Avalonia.View with

        static member ItemsControl<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabItemsControl, 'itemData, 'itemMarker> ItemsControl.WidgetKey ItemsControl.ItemsSourceTemplate items template

type ItemsControlModifiers =

    [<Extension>]
    static member inline itemsPanel(this: WidgetBuilder<'msg, #IFabItemsControl>, value: WidgetBuilder<'msg, #IFabPanel>) =
        this.AddScalar(ItemsControl.ItemsPanel.WithValue(value.Compile()))
