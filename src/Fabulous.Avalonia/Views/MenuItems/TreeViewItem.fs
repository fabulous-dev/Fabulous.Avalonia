namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTreeViewItem =
    inherit IFabHeaderedItemsControl

module TreeViewItem =
    let WidgetKey = Widgets.register<TreeViewItem>()

    let IsExpanded =
        Attributes.defineAvaloniaPropertyWithEquality TreeViewItem.IsExpandedProperty

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality TreeViewItem.IsSelectedProperty

type TreeViewItemModifiers =
    /// <summary>Link a ViewRef to access the direct TreeViewItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTreeViewItem>, value: ViewRef<TreeViewItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the IsExpanded property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the TreeViewItem is expanded.</param>
    [<Extension>]
    static member inline isExpanded(this: WidgetBuilder<'msg, IFabTreeViewItem>, value: bool) =
        this.AddScalar(TreeViewItem.IsExpanded.WithValue(value))
