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

        static member TabItem(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

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

[<Extension>]
type TabItemModifiers =
    [<Extension>]
    static member inline tabStripPlacement(this: WidgetBuilder<'msg, #IFabTabItem>, value: Dock) =
        this.AddScalar(TabItem.TabStripPlacement.WithValue(value))

    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabTabItem>, value: bool) =
        this.AddScalar(TabItem.IsSelected.WithValue(value))
