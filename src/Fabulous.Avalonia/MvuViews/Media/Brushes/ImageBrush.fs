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
            WidgetBuilder<unit, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Bitmap(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: string) =
            WidgetBuilder<unit, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.File(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Uri) =
            WidgetBuilder<unit, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Uri(source)))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Stream) =
            WidgetBuilder<unit, IFabMvuImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(ImageSourceValue.Stream(source)))

type MvuImageBrushModifiers =
    /// <summary>Link a ViewRef to access the direct ImageBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuImageBrush>, value: ViewRef<ImageBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
