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

[<AutoOpen>]
module TreeViewItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        /// <param name="isSelected">Whether the TreeViewItem is selected.</param>
        static member TreeViewItem(content: string, isSelected: bool) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                HeaderedItemsControl.HeaderString.WithValue(content),
                TreeViewItem.IsSelected.WithValue(isSelected)
            )

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: string) =
            WidgetBuilder<'msg, IFabTreeViewItem>(TreeViewItem.WidgetKey, HeaderedItemsControl.HeaderString.WithValue(content))

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="isSelected">Whether the TreeViewItem is selected.</param>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(isSelected: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(
                    StackList.one(TreeViewItem.IsSelected.WithValue(isSelected)),
                    ValueSome [| HeaderedItemsControl.HeaderWidget.WithValue(content.Compile()) |],
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedItemsControl.HeaderWidget.WithValue(content.Compile()) |], ValueNone, ValueNone)
            )

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
    static member inline isExpanded(this: WidgetBuilder<'msg, #IFabTreeViewItem>, value: bool) =
        this.AddScalar(TreeViewItem.IsExpanded.WithValue(value))
