namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let WidgetKey = Widgets.register<ItemsControl>()

    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target ->
            let target = target :?> ItemsControl

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

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

    let ContainerClearing =
        Attributes.defineEvent "ItemsControl_ContainerClearing" (fun target -> (target :?> ItemsControl).ContainerClearing)

    let ContainerIndexChanged =
        Attributes.defineEvent "ItemsControl_ContainerIndexChanged" (fun target -> (target :?> ItemsControl).ContainerIndexChanged)

    let ContainerPrepared =
        Attributes.defineEvent "ItemsControl_ContainerPrepared" (fun target -> (target :?> ItemsControl).ContainerPrepared)


[<AutoOpen>]
module ItemsControlBuilders =
    type Fabulous.Avalonia.View with

        static member ItemsControl<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabItemsControl, 'itemData, 'itemMarker> ItemsControl.WidgetKey ItemsControl.ItemsSourceTemplate items template

type ItemsControlModifiers =
    /// <summary>Listens to the ItemsControl ContainerClearing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onContainerClearing(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerClearingEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerClearing.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the index for the item it represents has changed.</param>
    [<Extension>]
    static member inline onContainerIndexChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerIndexChangedEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerIndexChanged.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerPrepared event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a container is prepared for use.</param>
    [<Extension>]
    static member inline onContainerPrepared(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerPreparedEventArgs -> 'msg) =
        this.AddScalar(ItemsControl.ContainerPrepared.WithValue(fn))

    [<Extension>]
    static member inline itemsPanel(this: WidgetBuilder<'msg, #IFabItemsControl>, value: WidgetBuilder<'msg, #IFabPanel>) =
        this.AddScalar(ItemsControl.ItemsPanel.WithValue(value.Compile()))
