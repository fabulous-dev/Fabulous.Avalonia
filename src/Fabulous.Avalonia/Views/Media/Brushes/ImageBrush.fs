namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabImageBrush =
    inherit IFabTileBrush

module ImageBrush =
    let WidgetKey = Widgets.register<ImageBrush>()

    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (eg. string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline private defineSourceAttribute<'model when 'model: equality> ([<InlineIfLambda>] convertModelToValue: 'model -> Bitmap) =
        Attributes.defineScalar<'model, 'model> ImageBrush.SourceProperty.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> ImageBrush

            match newValueOpt with
            | ValueNone -> target.ClearValue(ImageBrush.SourceProperty)
            | ValueSome v -> target.SetValue(ImageBrush.SourceProperty, convertModelToValue v) |> ignore)

    let Source = Attributes.defineAvaloniaPropertyWithEquality ImageBrush.SourceProperty

    let SourceFile = defineSourceAttribute<string> ImageSource.fromString

    let SourceUri = defineSourceAttribute<Uri> ImageSource.fromUri

    let SourceStream = defineSourceAttribute<Stream> ImageSource.fromStream

[<AutoOpen>]
module ImageBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Bitmap) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(source))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: string) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.SourceFile.WithValue(source))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Uri) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.SourceUri.WithValue(source))

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Stream) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.SourceStream.WithValue(source))

[<Extension>]
type ImageBrushModifiers =
    /// <summary>Link a ViewRef to access the direct ImageBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImageBrush>, value: ViewRef<ImageBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
