namespace Fabulous.Avalonia

open System
open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabTreeView =
    inherit IFabItemsControl

module TreeView =
    let WidgetKey = Widgets.register<TreeView>()

    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "TreeView_Items" (fun target ->
            let target = target :?> TreeView

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "TreeView_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let listBox = node.Target :?> TreeView

                match newValueOpt with
                | ValueNone ->
                    listBox.ClearValue(TreeView.ItemTemplateProperty)
                    listBox.ClearValue(TreeView.ItemsSourceProperty)
                | ValueSome value ->
                    listBox.SetValue(TreeView.ItemTemplateProperty, WidgetTreeDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    listBox.SetValue(TreeView.ItemsSourceProperty, value.OriginalItems) |> ignore)


[<AutoOpen>]
module TreeViewBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TreeView widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member inline TreeView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabTreeView, 'itemData, 'itemMarker> TreeView.WidgetKey TreeView.ItemsSource items template

        static member TreeView() =
            CollectionBuilder<'msg, IFabTreeView, IFabTreeViewItem>(TreeView.WidgetKey, TreeView.Items)

// [<Extension>]
// type DataGridModifiers =
//     /// <summary>Link a ViewRef to access the direct DataGrid control instance.</summary>
//     /// <param name="this">Current widget.</param>
//     /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
//     [<Extension>]
//     static member inline reference(this: WidgetBuilder<'msg, IFabDataGrid>, value: ViewRef<DataGrid>) =
//         this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

//     /// <summary>Sets the IsReadOnly property.</summary>
//     /// <param name="this">Current widget.</param>
//     /// <param name="value">The IsReadOnly value.</param>
//     [<Extension>]
//     static member inline isReadOnly(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
//         this.AddScalar(DataGrid.IsReadOnly.WithValue(value))
//
//
[<Extension>]
type DataGridCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTreeViewItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTreeViewItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTreeViewItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTreeViewItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
