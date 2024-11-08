namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabListBoxItem =
    inherit IFabContentControl

module ListBoxItem =
    let WidgetKey = Widgets.register<ListBoxItem>()

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality ListBoxItem.IsSelectedProperty


[<AutoOpen>]
module ListBoxItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="content">The content of the ListBoxItem.</param>
        /// <param name="isSelected">Whether the ListBoxItem is selected.</param>
        static member ListBoxItem(content: string, isSelected: bool) =
            WidgetBuilder<'msg, IFabListBoxItem>(
                ListBoxItem.WidgetKey,
                ContentControl.ContentString.WithValue(content),
                ListBoxItem.IsSelected.WithValue(isSelected)
            )

        /// <summary>Creates a ListBoxItem widget.</summary>
        /// <param name="content">The content of the ListBoxItem.</param>
        static member ListBoxItem(content: string) =
            WidgetBuilder<'msg, IFabListBoxItem>(ListBoxItem.WidgetKey, ContentControl.ContentString.WithValue(content))

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

type ListBoxItemModifiers =
    /// <summary>Link a ViewRef to access the direct MenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabListBoxItem>, value: ViewRef<ListBoxItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
