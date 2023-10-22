namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

type IFabItemsRepeater =
    inherit IFabPanel

module ItemsRepeater =
    let WidgetKey = Widgets.register<ItemsRepeater>()

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsRepeater_Items"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let dataGrid = node.Target :?> ItemsRepeater

                match newValueOpt with
                | ValueNone ->
                    dataGrid.ClearValue(ItemsRepeater.ItemTemplateProperty)
                    dataGrid.ClearValue(ItemsRepeater.ItemsSourceProperty)
                | ValueSome value ->
                    dataGrid.SetValue(ItemsRepeater.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    dataGrid.SetValue(ItemsRepeater.ItemsSourceProperty, value.OriginalItems))

    let HorizontalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.HorizontalCacheLengthProperty

    let VerticalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.VerticalCacheLengthProperty

    let Layout =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.LayoutProperty


[<AutoOpen>]
module ItemsRepeaterBuilders =
    type Fabulous.Avalonia.View with

        static member ItemsRepeater<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabItemsRepeater, 'itemData, 'itemMarker> ItemsRepeater.WidgetKey ItemsRepeater.ItemsSource items template

[<Extension>]
type ItemsRepeaterModifiers =
    /// <summary>Link a ViewRef to access the direct ItemsRepeater control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: ViewRef<ItemsRepeater>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the HorizontalCacheLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalCacheLength value.</param>
    [<Extension>]
    static member inline horizontalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
        this.AddScalar(ItemsRepeater.HorizontalCacheLength.WithValue(value))

    /// <summary>Set the VerticalCacheLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalCacheLength value.</param>
    [<Extension>]
    static member inline verticalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
        this.AddScalar(ItemsRepeater.VerticalCacheLength.WithValue(value))

    /// <summary>Set the Layout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Layout value.</param>
    [<Extension>]
    static member inline layout(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: AttachedLayout) =
        this.AddScalar(ItemsRepeater.Layout.WithValue(value))
