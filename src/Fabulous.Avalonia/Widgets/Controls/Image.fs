namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImage =
    inherit IFabControl

module ImageSource =
    let fromString (source: string) =
        let uri =
            if source.StartsWith("/") then
                Uri(source, UriKind.Relative)
            else
                Uri(source, UriKind.RelativeOrAbsolute)

        if uri.IsAbsoluteUri && uri.IsFile then
            new Bitmap(uri.LocalPath)
        else
            let assets = AvaloniaLocator.Current.GetService<IAssetLoader>()
            new Bitmap(assets.Open(uri))

module Image =
    let WidgetKey = Widgets.register<Image>()

    let Source = Attributes.defineAvaloniaPropertyWithEquality Image.SourceProperty

    let SourceWidget = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty

    let StretchDirection =
        Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Avalonia.View with

        static member Image<'msg>(source: IImage) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(source), Image.Stretch.WithValue(Stretch.Uniform))

        static member Image<'msg>(source: IImage, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(source), Image.Stretch.WithValue(stretch))

        static member Image<'msg>(source: string) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(ImageSource.fromString source), Image.Stretch.WithValue(Stretch.Uniform))
                
        static member Image<'msg>(source: string, stretch: Stretch) =
            WidgetBuilder<'msg, IFabImage>(Image.WidgetKey, Image.Source.WithValue(ImageSource.fromString source), Image.Stretch.WithValue(stretch))

        static member Image<'msg>(source: WidgetBuilder<'msg, IFabDrawingImage>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(Stretch.Uniform)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )
            
        static member Image<'msg>(stretch: Stretch, source: WidgetBuilder<'msg, IFabDrawingImage>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

        static member Image<'msg>(source: WidgetBuilder<'msg, IFabCroppedBitmap>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(Stretch.Uniform)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

        static member Image<'msg>(stretch: Stretch, source: WidgetBuilder<'msg, IFabCroppedBitmap>) =
            WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(StackList.one(Image.Stretch.WithValue(stretch)), ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |], ValueNone)
            )

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))
