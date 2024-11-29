namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous

type IFabTreeViewItem =
    inherit IFabHeaderedItemsControl

module TreeViewItem =
    let WidgetKey = Widgets.register<TreeViewItem>()
    
    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality TreeViewItem.IsSelectedProperty
            
    let Expanded =
        Attributes.Mvu.defineRoutedEvent "TreeViewItem_Expanded" TreeViewItem.ExpandedEvent
        
    let Collapsed =
        Attributes.Mvu.defineRoutedEvent "TreeViewItem_Collapsed" TreeViewItem.CollapsedEvent

[<AutoOpen>]
module TreeViewItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: string) =
            WidgetBuilder<'msg, IFabTreeViewItem>(TreeViewItem.WidgetKey, HeaderedItemsControl.HeaderString.WithValue(content))

        /// <summary>Creates a TreeViewItem widget.</summary>
        /// <param name="content">The content of the TreeViewItem.</param>
        static member TreeViewItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTreeViewItem>(
                TreeViewItem.WidgetKey,
                HeaderedItemsControl.HeaderWidget.WithValue(content.Compile()))

type TreeViewItemModifiers =
    /// <summary>Link a ViewRef to access the direct TreeViewItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTreeViewItem>, value: ViewRef<TreeViewItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the IsSelected property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the TreeViewItem is selected.</param>
    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabTreeViewItem>, value: bool) =
        this.AddScalar(TreeViewItem.IsSelected.WithValue(value))

    /// <summary>Link a message to the TreeViewItem Expanded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TreeViewItem Expanded event is fired.</param>
    [<Extension>]
    static member inline onExpanded(this: WidgetBuilder<'msg, #IFabTreeViewItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(TreeViewItem.Expanded.WithValue(fn))

    /// <summary>Link a message to the TreeViewItem Collapsed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TreeViewItem Collapsed event is fired.</param>
    [<Extension>]
    static member inline onCollapsed(this: WidgetBuilder<'msg, #IFabTreeViewItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(TreeViewItem.Collapsed.WithValue(fn))