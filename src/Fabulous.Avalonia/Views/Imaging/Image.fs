namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImage =
    inherit IFabControl

module Image =
    let WidgetKey = Widgets.register<Image>()

    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (eg. string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline private defineSourceAttribute<'model when 'model: equality> ([<InlineIfLambda>] convertModelToValue: 'model -> Bitmap) =
        Attributes.defineScalar<'model, 'model> Image.SourceProperty.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> Image

            match newValueOpt with
            | ValueNone -> target.ClearValue(Image.SourceProperty)
            | ValueSome v -> target.SetValue(Image.SourceProperty, convertModelToValue v) |> ignore)

    let Source = Attributes.defineAvaloniaPropertyWithEquality Image.SourceProperty

    let SourceFile = defineSourceAttribute<string> ImageSource.fromString

    let SourceUri = defineSourceAttribute<Uri> ImageSource.fromUri

    let SourceStream = defineSourceAttribute<Stream> ImageSource.fromStream

    let SourceWidget = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty

    let StretchDirection =
        Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: IImage) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(source), Image.Stretch.WithValue(Stretch.Uniform))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: IImage, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(source), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: string, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.SourceFile.WithValue(source), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: Uri) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.SourceUri.WithValue(source), Image.Stretch.WithValue(Stretch.Uniform))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: Uri, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.SourceUri.WithValue(source), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: Stream) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.SourceStream.WithValue(source), Image.Stretch.WithValue(Stretch.Uniform))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: Stream, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.SourceStream.WithValue(source), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: WidgetBuilder<'msg, IFabDrawingImage>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(
                    StackList.one(Image.Stretch.WithValue(Stretch.Uniform)),
                    ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(stretch: Stretch, source: WidgetBuilder<'msg, IFabDrawingImage>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: WidgetBuilder<'msg, IFabCroppedBitmap>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(
                    StackList.one(Image.Stretch.WithValue(Stretch.Uniform)),
                    ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(stretch: Stretch, source: WidgetBuilder<'msg, IFabCroppedBitmap>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

[<Extension>]
type ImageModifiers =
    /// <summary>Sets the StretchDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StretchDirection value.</param>
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Image control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImage>, value: ViewRef<Image>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
