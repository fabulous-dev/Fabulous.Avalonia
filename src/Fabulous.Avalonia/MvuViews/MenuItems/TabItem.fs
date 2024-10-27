namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuTabItem =
    inherit IFabMvuHeaderedContentControl
    inherit IFabTabItem

[<AutoOpen>]
module MvuTabItemBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TabItem widget.</summary>
        /// <param name="header">The header of the TabItem.</param>
        /// <param name="content">The content of the TabItem.</param>
        static member TabItem(header: string, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuTabItem>(
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
            WidgetBuilder<'msg, IFabMvuTabItem>(
                TabItem.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
