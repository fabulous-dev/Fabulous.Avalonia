namespace Fabulous.Avalonia.Mvu

open System
open System.IO
open Avalonia
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabMvuCroppedBitmap =
    inherit IFabMvuElement
    inherit IFabCroppedBitmap

[<AutoOpen>]
module MvuCroppedBitmapBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Bitmap, rect: PixelRect) =
            WidgetBuilder<'msg, IFabMvuCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Bitmap(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: string, rect: PixelRect) =
            WidgetBuilder<'msg, IFabMvuCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.File(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Uri, rect: PixelRect) =
            WidgetBuilder<'msg, IFabMvuCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Uri(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Stream, rect: PixelRect) =
            WidgetBuilder<'msg, IFabMvuCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Stream(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )
