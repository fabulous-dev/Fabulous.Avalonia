namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentItemsControl =
    let Items =
        ComponentAttributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target ->
            let target = target :?> ItemsControl

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

    let ContainerClearing =
        Attributes.defineEventNoDispatch "ItemsControl_ContainerClearing" (fun target -> (target :?> ItemsControl).ContainerClearing)

    let ContainerIndexChanged =
        Attributes.defineEventNoDispatch "ItemsControl_ContainerIndexChanged" (fun target -> (target :?> ItemsControl).ContainerIndexChanged)

    let ContainerPrepared =
        Attributes.defineEventNoDispatch "ItemsControl_ContainerPrepared" (fun target -> (target :?> ItemsControl).ContainerPrepared)


[<AutoOpen>]
module ComponentItemsControlBuilders =
    type Fabulous.Avalonia.View with

        static member ItemsControl<'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<unit, 'itemMarker>)
            =
            WidgetHelpers.buildItems<unit, IFabItemsControl, 'itemData, 'itemMarker>
                ItemsControl.WidgetKey
                ItemsControl.ItemsSourceTemplate
                items
                template

type ComponentItemsControlModifiers =
    /// <summary>Listens to the ItemsControl ContainerClearing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onContainerClearing(this: WidgetBuilder<unit, #IFabItemsControl>, fn: ContainerClearingEventArgs -> unit) =
        this.AddScalar(ComponentItemsControl.ContainerClearing.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the index for the item it represents has changed.</param>
    [<Extension>]
    static member inline onContainerIndexChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, fn: ContainerIndexChangedEventArgs -> unit) =
        this.AddScalar(ComponentItemsControl.ContainerIndexChanged.WithValue(fn))

    /// <summary>Listens to the ItemsControl ContainerPrepared event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a container is prepared for use.</param>
    [<Extension>]
    static member inline onContainerPrepared(this: WidgetBuilder<unit, #IFabItemsControl>, fn: ContainerPreparedEventArgs -> unit) =
        this.AddScalar(ComponentItemsControl.ContainerPrepared.WithValue(fn))
