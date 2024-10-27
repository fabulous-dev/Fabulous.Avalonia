namespace Fabulous.Avalonia.Components


open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentListBoxItem =
    inherit IFabComponentContentControl
    inherit IFabListBoxItem

[<AutoOpen>]
module ComponentListBoxItemBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="content">The content of the ListBoxItem.</param>
        /// <param name="isSelected">Whether the ListBoxItem is selected.</param>
        static member ListBoxItem(content: string, isSelected: bool) =
            WidgetBuilder<unit, IFabComponentListBoxItem>(
                ListBoxItem.WidgetKey,
                ContentControl.ContentString.WithValue(content),
                ListBoxItem.IsSelected.WithValue(isSelected)
            )

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="content">The content of the ListBoxItem.</param>
        static member ListBoxItem(content: string) =
            WidgetBuilder<unit, IFabComponentListBoxItem>(ListBoxItem.WidgetKey, ContentControl.ContentString.WithValue(content))

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="isSelected">Whether the ListBoxItem is selected.</param>
        /// <param name="content">The content of the ListBoxItem.</param>
        static member ListBoxItem(isSelected: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabListBoxItem>(
                ListBoxItem.WidgetKey,
                AttributesBundle(
                    StackList.one(ListBoxItem.IsSelected.WithValue(isSelected)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="content">The content of the ListBoxItem.</param>
        static member ListBoxItem(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabListBoxItem>(
                ListBoxItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
