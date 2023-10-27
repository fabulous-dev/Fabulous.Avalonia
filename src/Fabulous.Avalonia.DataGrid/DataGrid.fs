namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Templates
open Fabulous
open Fabulous.Avalonia

type WidgetControlTemplate(node: IViewNode, templateFn: obj -> Widget) as this =
    inherit FuncControlTemplate(System.Func<TemplatedControl, INameScope, Control>(fun data n -> this.Build(data, n)))

    member this.Recycle(newData: obj, prevWidget: Widget, rowNode: IViewNode) : Widget =
        let currWidget = templateFn newData
        Reconciler.update node.TreeContext.CanReuseView (ValueSome prevWidget) currWidget rowNode
        currWidget

    member this.Build(data: obj, _: INameScope) =
        let widget = templateFn data
        let definition = WidgetDefinitionStore.get widget.Key

        let struct (rowNode, view) =
            definition.CreateView(widget, node.TreeContext, ValueSome node)

        let item = ContentControl()
        item.Content <- (view :?> Control)

        item

type IFabDataGrid =
    inherit IFabTemplatedControl

module DataGrid =
    let WidgetKey = Widgets.register<DataGrid>()

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "DataGrid_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let dataGrid = node.Target :?> DataGrid

                match newValueOpt with
                | ValueNone ->
                    dataGrid.ClearValue(DataGrid.TemplateProperty)
                    dataGrid.ClearValue(DataGrid.ItemsSourceProperty)
                | ValueSome value ->
                    dataGrid.SetValue(DataGrid.TemplateProperty, WidgetControlTemplate(node, unbox >> value.Template))
                    |> ignore

                    dataGrid.SetValue(DataGrid.ItemsSourceProperty, value.OriginalItems) |> ignore)


[<AutoOpen>]
module DataGridBuilders =
    type Fabulous.Avalonia.View with

        static member DataGrid<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabDataGrid, 'itemData, 'itemMarker> DataGrid.WidgetKey DataGrid.ItemsSource items template

// [<Extension>]
// type DataGridModifiers =
//     /// <summary>Link a ViewRef to access the direct TabControl control instance</summary>
//     /// <param name="this">Current widget</param>
//     /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
//     [<Extension>]
//     static member inline reference(this: WidgetBuilder<'msg, IFabDataGrid>, value: ViewRef<DataGrid>) =
//         this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
//
// [<Extension>]
// type DataGridExtraModifiers =
//
//     [<Extension>]
//     static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabTabControl>) =
//         TabControlModifiers.horizontalContentAlignment(this, HorizontalAlignment.Center)
//
//     [<Extension>]
//     static member inline centerVertical(this: WidgetBuilder<'msg, #IFabTabControl>) =
//         TabControlModifiers.verticalContentAlignment(this, VerticalAlignment.Center)
//
//     [<Extension>]
//     static member inline center(this: WidgetBuilder<'msg, #IFabTabControl>) =
//         this.centerHorizontal().centerVertical()
//
// [<Extension>]
// type DataGridCollectionBuilderExtensions =
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabItem>
//         (
//             _: CollectionBuilder<'msg, 'marker, IFabTabItem>,
//             x: WidgetBuilder<'msg, 'itemType>
//         ) : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }
//
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTabItem>
//         (
//             _: CollectionBuilder<'msg, 'marker, IFabTabItem>,
//             x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
//         ) : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }
