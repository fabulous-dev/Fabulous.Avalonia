namespace Fabulous.Avalonia.Components

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentImageDrawing =
    inherit IFabComponentDrawing
    inherit IFabImageDrawing

[<AutoOpen>]
module ComponentImageDrawingBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: Bitmap, rect: Rect) =
            WidgetBuilder<'msg, IFabComponentImageDrawing>(
                ImageDrawing.WidgetKey,
                ImageDrawing.ImageSource.WithValue(ImageSourceValue.Bitmap(source)),
                ImageDrawing.Rect.WithValue(rect)
            )

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: string, rect: Rect) =
            WidgetBuilder<'msg, IFabComponentImageDrawing>(
                ImageDrawing.WidgetKey,
                ImageDrawing.ImageSource.WithValue(ImageSourceValue.File(source)),
                ImageDrawing.Rect.WithValue(rect)
            )

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: Uri, rect: Rect) =
            WidgetBuilder<'msg, IFabComponentImageDrawing>(
                ImageDrawing.WidgetKey,
                ImageDrawing.ImageSource.WithValue(ImageSourceValue.Uri(source)),
                ImageDrawing.Rect.WithValue(rect)
            )

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: Stream, rect: Rect) =
            WidgetBuilder<'msg, IFabComponentImageDrawing>(
                ImageDrawing.WidgetKey,
                ImageDrawing.ImageSource.WithValue(ImageSourceValue.Stream(source)),
                ImageDrawing.Rect.WithValue(rect)
            )

        /// <summary>Creates a ImageDrawing widget.</summary>
        /// <param name="source">The source of the image.</param>
        /// <param name="rect">The rectangle to draw the image in.</param>
        static member ImageDrawing(source: WidgetBuilder<'msg, #IFabDrawing>, rect: Rect) =
            WidgetBuilder<'msg, IFabComponentImageDrawing>(
                ImageDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(ImageDrawing.Rect.WithValue(rect)),
                    ValueSome [| ImageDrawing.ImageSourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )
