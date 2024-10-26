namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentToolTip =
    inherit IFabComponentContentControl
    inherit IFabToolTip

[<AutoOpen>]
module ComponentToolTipBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: string) =
            WidgetBuilder<unit, IFabComponentToolTip>(ToolTip.WidgetKey, ContentControl.ContentString.WithValue(content))

        /// <summary>Creates a ToolTip widget.</summary>
        static member ToolTip(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentToolTip>(
                ToolTip.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
