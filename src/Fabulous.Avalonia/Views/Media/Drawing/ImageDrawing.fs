namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
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

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: IImage, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(ImageDrawing.WidgetKey, ImageDrawing.ImageSource.WithValue(source), ImageDrawing.Rect.WithValue(rect))

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: WidgetBuilder<'msg, #IFabDrawing>, rect: Rect) =
            WidgetBuilder<'msg, IFabImageDrawing>(
                ImageDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(ImageDrawing.Rect.WithValue(rect)),
                    ValueSome [| ImageDrawing.ImageSourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ImageDrawingModifiers =

    /// <summary>Link a ViewRef to access the direct ImageDrawing control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImageDrawing>, value: ViewRef<ImageDrawing>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
