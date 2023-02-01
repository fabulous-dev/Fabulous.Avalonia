namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsRepeater =
    inherit IFabPanel

module ItemsRepeater =
    let WidgetKey = Widgets.register<ItemsRepeater>()

    let HorizontalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.HorizontalCacheLengthProperty


    let Layout =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.LayoutProperty

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsRepeater_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsRepeater = node.Target :?> ItemsRepeater

                match newValueOpt with
                | ValueNone ->
                    itemsRepeater.ClearValue(ItemsRepeater.ItemTemplateProperty)
                    itemsRepeater.ClearValue(ItemsRepeater.ItemsProperty)
                | ValueSome value ->
                    itemsRepeater.SetValue(ItemsRepeater.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template, false))
                    |> ignore

                    itemsRepeater.SetValue(ItemsRepeater.ItemsProperty, value.OriginalItems))

    let VerticalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.VerticalCacheLengthProperty

    let ElementClearing =
        Attributes.defineEvent<ItemsRepeaterElementClearingEventArgs> "ItemsRepeater_ElementClearing" (fun target -> (target :?> ItemsRepeater).ElementClearing)

    let ElementIndexChanged =
        Attributes.defineEvent<ItemsRepeaterElementIndexChangedEventArgs> "ItemsRepeater_ElementIndexChanged" (fun target ->
            (target :?> ItemsRepeater).ElementIndexChanged)

    let ElementPrepared =
        Attributes.defineEvent<ItemsRepeaterElementPreparedEventArgs> "ItemsRepeater_ElementPrepared" (fun target -> (target :?> ItemsRepeater).ElementPrepared)

[<AutoOpen>]
module ItemsRepeaterBuilders =
    type Fabulous.Avalonia.View with

        static member inline ItemsRepeater<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabItemsRepeater, 'itemData, 'itemMarker> ItemsRepeater.WidgetKey ItemsRepeater.ItemsSource items template

[<Extension>]
type ItemsRepeaterModifiers =
    [<Extension>]
    static member inline horizontalCacheLength(this: WidgetBuilder<'msg, #IFabItemsRepeater>, value: float) =
        this.AddScalar(ItemsRepeater.HorizontalCacheLength.WithValue(value))

    [<Extension>]
    static member inline verticalCacheLength(this: WidgetBuilder<'msg, #IFabItemsRepeater>, value: float) =
        this.AddScalar(ItemsRepeater.VerticalCacheLength.WithValue(value))

    [<Extension>]
    static member inline onElementClearing(this: WidgetBuilder<'msg, #IFabItemsRepeater>, onElementClearing: ItemsRepeaterElementClearingEventArgs -> 'msg) =
        this.AddScalar(ItemsRepeater.ElementClearing.WithValue(fun args -> onElementClearing args |> box))

    [<Extension>]
    static member inline onElementIndexChanged
        (
            this: WidgetBuilder<'msg, #IFabItemsRepeater>,
            onElementIndexChanged: ItemsRepeaterElementIndexChangedEventArgs -> 'msg
        ) =
        this.AddScalar(ItemsRepeater.ElementIndexChanged.WithValue(fun args -> onElementIndexChanged args |> box))

    [<Extension>]
    static member inline onElementPrepared(this: WidgetBuilder<'msg, #IFabItemsRepeater>, onElementPrepared: ItemsRepeaterElementPreparedEventArgs -> 'msg) =
        this.AddScalar(ItemsRepeater.ElementPrepared.WithValue(fun args -> onElementPrepared args |> box))
