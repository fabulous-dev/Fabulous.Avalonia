namespace Fabulous.Avalonia.Components

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabComponentCroppedBitmap =
    inherit IFabComponentElement
    inherit IFabCroppedBitmap

[<AutoOpen>]
module ComponentCroppedBitmapBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Bitmap, rect: PixelRect) =
            WidgetBuilder<unit, IFabComponentCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Bitmap(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: string, rect: PixelRect) =
            WidgetBuilder<unit, IFabComponentCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.File(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Uri, rect: PixelRect) =
            WidgetBuilder<unit, IFabComponentCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Uri(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Stream, rect: PixelRect) =
            WidgetBuilder<unit, IFabComponentCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(ImageSourceValue.Stream(source)),
                CroppedBitmap.SourceRect.WithValue(rect)
            )
