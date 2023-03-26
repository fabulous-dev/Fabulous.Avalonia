namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingBrush =
    inherit IFabTileBrush

module DrawingBrush =
    let WidgetKey = Widgets.register<DrawingBrush>()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingBrush.DrawingProperty

[<AutoOpen>]
module DrawingBrushBuilders =
    type Fabulous.Avalonia.View with

        static member DrawingBrush(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingBrush>(
                DrawingBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingBrush.Drawing.WithValue(source.Compile()) |], ValueNone)
            )
