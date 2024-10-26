namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuHeaderedContentControl =
    inherit IFabMvuContentControl
    inherit IFabHeaderedContentControl

[<AutoOpen>]
module MvuHeaderedContentControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header string.</param>
        /// <param name="content">The content widget.</param>
        static member HeaderedContentControl(header: string, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabMvuHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                AttributesBundle(
                    StackList.one(HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header widget.</param>
        /// <param name="content">The content widget.</param>
        static member HeaderedContentControl(header: WidgetBuilder<unit, #IFabControl>, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabMvuHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile())
                           ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a HeaderedContentControl widget.</summary>
        /// <param name="header">The header string.</param>
        /// <param name="content">The content string.</param>
        static member HeaderedContentControl(header: string, content: string) =
            WidgetBuilder<unit, IFabMvuHeaderedContentControl>(
                HeaderedContentControl.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ContentControl.ContentString.WithValue(content)
            )
