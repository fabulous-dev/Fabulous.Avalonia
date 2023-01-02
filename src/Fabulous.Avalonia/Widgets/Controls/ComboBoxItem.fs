namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabComboBoxItem =
    inherit IFabListBoxItem

module ComboBoxItem =
    let WidgetKey = Widgets.register<ComboBoxItem> ()

[<AutoOpen>]
module ComboBoxItemBuilders =
    type Fabulous.Avalonia.View with

        static member ComboBoxItem(content: WidgetBuilder<'msg, #IFabControl>, ?isSelected: bool) =
            match isSelected with
            | Some isSelected ->
                WidgetBuilder<'msg, IFabComboBoxItem>(
                    ComboBoxItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(isSelected)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )
            | None ->
                WidgetBuilder<'msg, IFabComboBoxItem>(
                    ComboBoxItem.WidgetKey,
                    AttributesBundle(
                        StackList.one (ListBoxItem.IsSelected.WithValue(false)),
                        ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                        ValueNone
                    )
                )

        static member ComboBoxItem(content: string, ?isSelected: bool) =
            match isSelected with
            | Some isSelected ->
                WidgetBuilder<'msg, IFabComboBoxItem>(
                    ComboBoxItem.WidgetKey,
                    ListBoxItem.IsSelected.WithValue(isSelected),
                    ContentControl.ContentString.WithValue(content)
                )
            | None ->
                WidgetBuilder<'msg, IFabComboBoxItem>(
                    ComboBoxItem.WidgetKey,
                    ListBoxItem.IsSelected.WithValue(false),
                    ContentControl.ContentString.WithValue(content)
                )
