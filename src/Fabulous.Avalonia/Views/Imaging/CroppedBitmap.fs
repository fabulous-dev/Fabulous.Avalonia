namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabCroppedBitmap =
    inherit IFabAvaloniaObject

module CroppedBitmap =

    let WidgetKey = Widgets.register<CroppedBitmap>()

    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (eg. string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline private defineSourceAttribute<'model when 'model: equality> ([<InlineIfLambda>] convertModelToValue: 'model -> Bitmap) =
        Attributes.defineScalar<'model, 'model> CroppedBitmap.SourceProperty.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> CroppedBitmap

            match newValueOpt with
            | ValueNone -> target.ClearValue(CroppedBitmap.SourceProperty)
            | ValueSome v -> target.SetValue(CroppedBitmap.SourceProperty, convertModelToValue v) |> ignore)

    let Source =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceProperty

    let SourceFile = defineSourceAttribute<string> ImageSource.fromString

    let SourceUri = defineSourceAttribute<Uri> ImageSource.fromUri

    let SourceStream = defineSourceAttribute<Stream> ImageSource.fromStream

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceRectProperty

[<AutoOpen>]
module CroppedBitmapBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: IImage, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(CroppedBitmap.WidgetKey, CroppedBitmap.Source.WithValue(source), CroppedBitmap.SourceRect.WithValue(rect))

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: string, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.SourceFile.WithValue(source),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Uri, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(CroppedBitmap.WidgetKey, CroppedBitmap.SourceUri.WithValue(source), CroppedBitmap.SourceRect.WithValue(rect))

        /// <summary>Creates a CroppedBitmap widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: Stream, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.SourceStream.WithValue(source),
                CroppedBitmap.SourceRect.WithValue(rect)
            )

[<Extension>]
type CroppedBitmapModifiers =
    /// <summary>Link a ViewRef to access the direct CroppedBitmap control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCroppedBitmap>, value: ViewRef<CroppedBitmap>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
