namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImageDrawing =
    inherit IFabDrawing

module ImageDrawing =
    let WidgetKey = Widgets.register<ImageDrawing> ()

    let ImageSource =
        Attributes.defineAvaloniaPropertyWithEquality ImageDrawing.ImageSourceProperty

    let ImageSourceWidget =
        Attributes.defineAvaloniaPropertyWidget ImageDrawing.ImageSourceProperty

    let Rect = Attributes.defineAvaloniaPropertyWithEquality ImageDrawing.RectProperty

[<AutoOpen>]
module ImageDrawingBuilders =
    type Fabulous.Avalonia.View with

        static member ImageDrawing(source: IImage, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(
                ImageDrawing.WidgetKey,
                ImageDrawing.ImageSource.WithValue(source),
                ImageDrawing.Rect.WithValue(rect)
            )

        static member ImageDrawing(source: WidgetBuilder<'msg, #IFabDrawing>, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(
                ImageDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one (ImageDrawing.Rect.WithValue(rect)),
                    ValueSome [| ImageDrawing.ImageSourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )
