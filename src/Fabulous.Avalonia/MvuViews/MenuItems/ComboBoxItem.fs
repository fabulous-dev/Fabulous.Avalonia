namespace Fabulous.Avalonia.Mvu


open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuComboBoxItem =
    inherit IFabMvuListBoxItem
    inherit IFabComboBoxItem

[<AutoOpen>]
module MvuComboBoxItemBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ComboBoxItem widget.</summary>
        /// <param name="content">The content of the ComboBoxItem.</param>
        static member ComboBoxItem(content: string) =
            WidgetBuilder<'msg, IFabMvuComboBoxItem>(ComboBoxItem.WidgetKey, ContentControl.ContentString.WithValue(content))

        /// <summary>Creates a ComboBoxItem widget.</summary>
        /// <param name="content">The content of the ComboBoxItem.</param>
        /// <param name="isSelected">Whether the ComboBoxItem is selected.</param>
        static member ComboBoxItem(content: string, isSelected: bool) =
            WidgetBuilder<'msg, IFabMvuComboBoxItem>(
                ComboBoxItem.WidgetKey,
                ContentControl.ContentString.WithValue(content),
                ListBoxItem.IsSelected.WithValue(isSelected)
            )

        /// <summary>Creates a ComboBoxItem widget.</summary>
        /// <param name="content">The content of the ComboBoxItem.</param>
        static member ComboBoxItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuComboBoxItem>(
                ComboBoxItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a ComboBoxItem widget.</summary>
        /// <param name="isSelected">Whether the ComboBoxItem is selected.</param>
        /// <param name="content">The content of the ComboBoxItem.</param>
        static member ComboBoxItem(isSelected: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuComboBoxItem>(
                ComboBoxItem.WidgetKey,
                AttributesBundle(
                    StackList.one(ListBoxItem.IsSelected.WithValue(isSelected)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
