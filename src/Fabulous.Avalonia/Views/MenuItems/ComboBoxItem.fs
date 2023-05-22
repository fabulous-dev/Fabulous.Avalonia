namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabComboBoxItem =
    inherit IFabListBoxItem

module ComboBoxItem =
    let WidgetKey = Widgets.register<ComboBoxItem>()

[<AutoOpen>]
module ComboBoxItemBuilders =
    type Fabulous.Avalonia.View with

        static member inline ComboBoxItem(content: string) =
            WidgetBuilder<'msg, IFabComboBoxItem>(ComboBoxItem.WidgetKey, ContentControl.ContentString.WithValue(content))

        static member inline ComboBoxItem(content: string, isSelected: bool) =
            WidgetBuilder<'msg, IFabComboBoxItem>(
                ComboBoxItem.WidgetKey,
                ContentControl.ContentString.WithValue(content),
                ListBoxItem.IsSelected.WithValue(isSelected)
            )

        static member inline ComboBoxItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabComboBoxItem>(
                ComboBoxItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

        static member inline ComboBoxItem(isSelected: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabComboBoxItem>(
                ComboBoxItem.WidgetKey,
                AttributesBundle(
                    StackList.one(ListBoxItem.IsSelected.WithValue(isSelected)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ComboBoxItemModifiers =
    /// <summary>Link a ViewRef to access the direct MenuItem control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComboBoxItem>, value: ViewRef<ComboBoxItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
