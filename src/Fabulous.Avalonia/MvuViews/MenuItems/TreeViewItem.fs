namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuTreeViewItem =
    inherit IFabMvuHeaderedItemsControl
    inherit IFabTreeViewItem

[<AutoOpen>]
module MvuTreeViewItemBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        /// <param name="isSelected">Whether the TreeViewItem is selected.</param>
        static member TreeViewItem(content: string, isSelected: bool) =
            WidgetBuilder<'msg, IFabMvuTreeViewItem>(
                TreeViewItem.WidgetKey,
                HeaderedItemsControl.HeaderString.WithValue(content),
                TreeViewItem.IsSelected.WithValue(isSelected)
            )

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: string) =
            WidgetBuilder<'msg, IFabMvuTreeViewItem>(TreeViewItem.WidgetKey, HeaderedItemsControl.HeaderString.WithValue(content))

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="isSelected">Whether the TreeViewItem is selected.</param>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(isSelected: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(
                    StackList.one(TreeViewItem.IsSelected.WithValue(isSelected)),
                    ValueSome [| HeaderedItemsControl.HeaderWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuTreeViewItem>(
                TreeViewItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedItemsControl.HeaderWidget.WithValue(content.Compile()) |], ValueNone)
            )
