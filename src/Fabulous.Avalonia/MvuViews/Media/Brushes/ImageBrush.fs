namespace Fabulous.Avalonia.Mvu

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabMvuImageBrush =
    inherit IFabMvuTileBrush
    inherit IFabImageBrush

[<AutoOpen>]
module MvuImageBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Bitmap) =
            WidgetBuilder<'msg, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Bitmap(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: string) =
            WidgetBuilder<'msg, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.File(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Uri) =
            WidgetBuilder<'msg, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Uri(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Stream) =
            WidgetBuilder<'msg, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Stream(source)))
