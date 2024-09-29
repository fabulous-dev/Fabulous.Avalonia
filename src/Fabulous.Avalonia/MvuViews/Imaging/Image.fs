namespace Fabulous.Avalonia.Mvu

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuImage =
    inherit IFabMvuControl
    inherit IFabImage

[<AutoOpen>]
module MvuImageBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: Bitmap) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                Image.Source.WithValue(ImageSourceValue.Bitmap(source)),
                Image.Stretch.WithValue(Stretch.Uniform)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: Bitmap, stretch: Stretch) =
            WidgetBuilder<unit, IFabMvuImage>(Image.WidgetKey, Image.Source.WithValue(ImageSourceValue.Bitmap(source)), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: string) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                Image.Source.WithValue(ImageSourceValue.File(source)),
                Image.Stretch.WithValue(Stretch.Uniform)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: string, stretch: Stretch) =
            WidgetBuilder<unit, IFabMvuImage>(Image.WidgetKey, Image.Source.WithValue(ImageSourceValue.File(source)), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: Uri) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                Image.Source.WithValue(ImageSourceValue.Uri(source)),
                Image.Stretch.WithValue(Stretch.Uniform)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: Uri, stretch: Stretch) =
            WidgetBuilder<unit, IFabMvuImage>(Image.WidgetKey, Image.Source.WithValue(ImageSourceValue.Uri(source)), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: Stream) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                Image.Source.WithValue(ImageSourceValue.Stream(source)),
                Image.Stretch.WithValue(Stretch.Uniform)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="stretch">The stretch mode.</param>
        static member Image(source: Stream, stretch: Stretch) =
            WidgetBuilder<unit, IFabMvuImage>(Image.WidgetKey, Image.Source.WithValue(ImageSourceValue.Stream(source)), Image.Stretch.WithValue(stretch))

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: WidgetBuilder<unit, IFabDrawingImage>) =
            WidgetBuilder<unit, IFabMvuImage>(
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
        static member Image(stretch: Stretch, source: WidgetBuilder<unit, IFabDrawingImage>) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

        /// <summary>Creates an Image widget.</summary>
        /// <param name="source">The source image.</param>
        static member Image(source: WidgetBuilder<unit, IFabMvuCroppedBitmap>) =
            WidgetBuilder<unit, IFabMvuImage>(
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
        static member Image(stretch: Stretch, source: WidgetBuilder<unit, IFabMvuCroppedBitmap>) =
            WidgetBuilder<unit, IFabMvuImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

type MvuImageModifiers =
    /// <summary>Link a ViewRef to access the direct Image control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuImage>, value: ViewRef<Image>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
