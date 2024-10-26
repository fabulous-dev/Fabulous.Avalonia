namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuToolTip =
    inherit IFabMvuContentControl
    inherit IFabToolTip

[<AutoOpen>]
module MvuToolTipBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: string) =
            WidgetBuilder<'msg, IFabMvuToolTip>(ToolTip.WidgetKey, ContentControl.ContentString.WithValue(content))

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuToolTip>(
                ToolTip.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
