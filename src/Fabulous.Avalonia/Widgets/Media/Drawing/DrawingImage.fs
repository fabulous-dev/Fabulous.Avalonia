namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingImage =
    inherit IFabElement

module DrawingImage =
    let WidgetKey = Widgets.register<DrawingImage> ()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingImage.DrawingProperty

[<AutoOpen>]
module DrawingImageBuilders =
    type Fabulous.Avalonia.View with

        static member DrawingImage(source: WidgetBuilder<'msg, #IFabDrawing>) =
            WidgetBuilder<'msg, IFabDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| DrawingImage.Drawing.WithValue(source.Compile()) |],
                    ValueNone
                )
            )
