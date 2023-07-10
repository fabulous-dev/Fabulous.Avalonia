namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImageDrawing =
    inherit IFabDrawing

module ImageDrawing =
    let WidgetKey = Widgets.register<ImageDrawing>()

    let ImageSource =
        Attributes.defineAvaloniaPropertyWithEquality ImageDrawing.ImageSourceProperty

    let ImageSourceWidget =
        Attributes.defineAvaloniaPropertyWidget ImageDrawing.ImageSourceProperty

    let Rect = Attributes.defineAvaloniaPropertyWithEquality ImageDrawing.RectProperty

[<AutoOpen>]
module ImageDrawingBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ImageDrawing widget</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in</param>
        static member ImageDrawing(source: IImage, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(ImageDrawing.WidgetKey, ImageDrawing.ImageSource.WithValue(source), ImageDrawing.Rect.WithValue(rect))

        /// <summary>Creates a ImageDrawing widget</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in</param>
        static member ImageDrawing(source: WidgetBuilder<'msg, #IFabDrawing>, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(
                ImageDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(ImageDrawing.Rect.WithValue(rect)),
                    ValueSome [| ImageDrawing.ImageSourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )
