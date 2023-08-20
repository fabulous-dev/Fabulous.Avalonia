namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Templates
open Fabulous

type FabItemsControl() =
    inherit ItemsControl()
    let mutable _itemsPanel: Panel = null

    let funcTemplate = FuncTemplate<Panel>(fun _ -> _itemsPanel)

    do base.ItemsPanel <- funcTemplate

    member this.ItemsPanel
        with get () = _itemsPanel
        and set value = _itemsPanel <- value

    override this.StyleKeyOverride = typeof<ItemsControl>

module ItemsControlUpdaters =
    let itemsPanelApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabItemsControl
        let childViewNode = node.TreeContext.GetViewNode(target.ItemsPanel)
        childViewNode.ApplyDiff(&diff)

    let itemsPanelUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabItemsControl

        match currOpt with
        | ValueNone -> target.ItemsPanel <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.ItemsPanel <- view :?> Panel

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =

    let WidgetKey = Widgets.register<FabItemsControl>()

    let ItemsPanel =
        Attributes.defineWidget "ItemsControl_ItemTemplate" ItemsControlUpdaters.itemsPanelApplyDiff ItemsControlUpdaters.itemsPanelUpdateNode

    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target ->
            let target = target :?> ItemsControl

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsControl_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let listBox = node.Target :?> ItemsControl

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(ItemsControl.ItemTemplateProperty)
                    listBox.ClearValue(ItemsControl.ItemsSourceProperty)
                | ValueSome value ->
                    listBox.SetValue(ItemsControl.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    listBox.SetValue(ItemsControl.ItemsSourceProperty, value.OriginalItems)
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

        static member inline ItemsControl<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabItemsControl, 'itemData, 'itemMarker> ItemsControl.WidgetKey ItemsControl.ItemsSource items template

[<Extension>]
type ItemsControlModifiers =

    [<Extension>]
    static member inline itemsPanel(this: WidgetBuilder<'msg, #IFabItemsControl>, value: WidgetBuilder<'msg, #IFabPanel>) =
        this.AddWidget(ItemsControl.ItemsPanel.WithValue(value.Compile()))

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
