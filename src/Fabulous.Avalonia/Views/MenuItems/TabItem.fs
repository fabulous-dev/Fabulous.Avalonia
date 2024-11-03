namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTabItem =
    inherit IFabHeaderedContentControl

module TabItem =
    let WidgetKey = Widgets.register<TabItem>()

    let TabStripPlacement =
        Attributes.defineAvaloniaPropertyWithEquality TabItem.TabStripPlacementProperty

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality TabItem.IsSelectedProperty

[<AutoOpen>]
module TabItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TabItem widget.</summary>
        /// <param name="header">The header of the TabItem.</param>
        /// <param name="content">The content of the TabItem.</param>
        static member TabItem(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a TabItem widget.</summary>
        /// <param name="header">The header of the TabItem.</param>
        /// <param name="content">The content of the TabItem.</param>
        static member TabItem(header: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )


type TabItemModifiers =
    /// <summary>Sets the TabStripPlacement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TabStripPlacement value.</param>
    [<Extension>]
    static member inline tabStripPlacement(this: WidgetBuilder<'msg, #IFabTabItem>, value: Dock) =
        this.AddScalar(TabItem.TabStripPlacement.WithValue(value))

    /// <summary>Sets the IsSelected property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSelected value.</param>
    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabTabItem>, value: bool) =
        this.AddScalar(TabItem.IsSelected.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TabItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabTabItem>, value: ViewRef<TabItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
