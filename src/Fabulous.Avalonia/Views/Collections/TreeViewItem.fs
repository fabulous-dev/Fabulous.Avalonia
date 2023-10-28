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
open Fabulous.StackAllocatedCollections.StackList

type IFabTreeViewItem =
    inherit IFabHeaderedItemsControl

module TreeViewItem =
    let WidgetKey = Widgets.register<TreeViewItem>()

// let IsReadOnly =
//     Attributes.defineAvaloniaPropertyWithEquality DataGrid.IsReadOnlyProperty

[<AutoOpen>]
module TreeViewItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ListBox widget.</summary>
        static member inline TreeViewItem(header: WidgetBuilder<'msg, IFabControl>) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |], ValueNone)
            )

        /// <summary>Creates a ListBox widget.</summary>
        static member inline TreeViewItem(header: string) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(StackList.one(HeaderedContentControl.HeaderString.WithValue(header)), ValueNone, ValueNone)
            )
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
// [<Extension>]
// type DataGridCollectionBuilderExtensions =
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDataGridColumn>
//         (
//             _: CollectionBuilder<'msg, 'marker, IFabDataGridColumn>,
//             x: WidgetBuilder<'msg, 'itemType>
//         ) : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }
//
//     [<Extension>]
//     static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDataGridColumn>
//         (
//             _: CollectionBuilder<'msg, 'marker, IFabDataGridColumn>,
//             x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
//         ) : Content<'msg> =
//         { Widgets = MutStackArray1.One(x.Compile()) }
