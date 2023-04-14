namespace Fabulous.Avalonia.DataGid

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabDataGrid =
    inherit IFabTemplatedControl

module DataGrid =
    let WidgetKey = Widgets.register<DataGrid>()

    let Items =
        Attributes.defineSimpleScalar<WidgetItems>
            "DataGrid_Items"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let dataGrid = node.Target :?> DataGrid

                match newValueOpt with
                | ValueNone ->
                    dataGrid.ClearValue(DataGrid.TemplateProperty)
                    dataGrid.ClearValue(DataGrid.ItemsProperty)
                | ValueSome value ->
                    dataGrid.SetValue(DataGrid.TemplateProperty, WidgetControlTemplate(node, unbox >> value.Template, true))
                    |> ignore

                    dataGrid.SetValue(DataGrid.ItemsProperty, value.OriginalItems))


[<AutoOpen>]
module DataGridBuilders =
    type Fabulous.Avalonia.View with

        static member DataGrid<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabListBox, 'itemData, 'itemMarker> DataGrid.WidgetKey DataGrid.Items items template

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
