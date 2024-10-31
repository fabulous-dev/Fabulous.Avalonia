namespace Fabulous.Avalonia.Components

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabComponentImageBrush =
    inherit IFabComponentTileBrush
    inherit IFabImageBrush

[<AutoOpen>]
module ComponentImageBrushBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Bitmap) =
            WidgetBuilder<unit, IFabComponentImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Bitmap(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: string) =
            WidgetBuilder<unit, IFabComponentImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.File(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Uri) =
            WidgetBuilder<unit, IFabComponentImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Uri(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Stream) =
            WidgetBuilder<unit, IFabComponentImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Stream(source)))
