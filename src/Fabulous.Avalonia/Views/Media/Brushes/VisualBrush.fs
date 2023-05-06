namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabVisualBrush =
    inherit IFabTileBrush

module VisualBrush =
    let WidgetKey = Widgets.register<VisualBrush>()

    let Visual = Attributes.defineAvaloniaPropertyWidget VisualBrush.VisualProperty

[<AutoOpen>]
module VisualBrushBuilders =
    type Fabulous.Avalonia.View with

        static member VisualBrush(content: WidgetBuilder<'msg, #IFabVisual>) =
            WidgetBuilder<'msg, IFabVisualBrush>(
                VisualBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| VisualBrush.Visual.WithValue(content.Compile()) |], ValueNone)
            )
