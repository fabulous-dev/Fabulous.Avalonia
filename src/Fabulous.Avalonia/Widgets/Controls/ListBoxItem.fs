namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabListBoxItem =
    inherit IFabContentControl

module ListBoxItem =
    let WidgetKey = Widgets.register<ListBoxItem> ()

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality ListBoxItem.IsSelectedProperty

[<AutoOpen>]
module ListBoxItemBuilders =
    type Fabulous.Avalonia.View with

        static member inline ListBoxItem(content: WidgetBuilder<'msg, #IFabControl>, ?isSelected: bool) =
            match isSelected with
            | Some isSelected ->
                WidgetBuilder<'msg, IFabListBoxItem>(
                    ListBoxItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(isSelected)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )
            | None ->
                WidgetBuilder<'msg, IFabListBoxItem>(
                    ListBoxItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(false)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )
