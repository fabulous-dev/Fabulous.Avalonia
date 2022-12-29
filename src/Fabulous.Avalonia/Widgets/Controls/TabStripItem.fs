namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabTabStripItem =
    inherit IFabListBoxItem

module TabStripItem =
    let WidgetKey = Widgets.register<TabStripItem> ()

[<AutoOpen>]
module TabStripItemBuilders =
    type Fabulous.Avalonia.View with

        static member inline TabStripItem(content: WidgetBuilder<'msg, #IFabControl>, ?isSelected: bool) =
            match isSelected with
            | Some isSelected ->
                WidgetBuilder<'msg, IFabTabStripItem>(
                    TabStripItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(isSelected)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )
            | None ->
                WidgetBuilder<'msg, IFabTabStripItem>(
                    TabStripItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(false)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )

        static member inline TabStripItem(content: string, ?isSelected: bool) =
            match isSelected with
            | Some isSelected ->
                WidgetBuilder<'msg, IFabTabStripItem>(
                    TabStripItem.WidgetKey,
                    ContentControl.ContentString.WithValue(content),
                    ListBoxItem.IsSelected.WithValue(isSelected)
                )
            | None ->
                WidgetBuilder<'msg, IFabTabStripItem>(
                    TabStripItem.WidgetKey,
                    ContentControl.ContentString.WithValue(content),
                    ListBoxItem.IsSelected.WithValue(false)
                )
