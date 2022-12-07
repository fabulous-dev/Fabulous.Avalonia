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
    let fromFile source =
        let assets = AvaloniaLocator.Current.GetService<IAssetLoader>()
        new Bitmap(assets.Open(Uri(source, UriKind.RelativeOrAbsolute)))

module Image =
    let WidgetKey = Widgets.register<Image> ()

    let Source = Attributes.defineAvaloniaPropertyWithEquality Image.SourceProperty

    let SourceWidget = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty

    let StretchDirection =
        Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Avalonia.View with

        static member Image(source: IImage, ?stretch: Stretch) =
            match stretch with
            | Some value ->
                WidgetBuilder<'msg, IFabImage>(
                    Image.WidgetKey,
                    Image.Source.WithValue(source),
                    Image.Stretch.WithValue(value)
                )
            | None ->
                WidgetBuilder<'msg, IFabImage>(
                    Image.WidgetKey,
                    Image.Source.WithValue(source),
                    Image.Stretch.WithValue(Stretch.Uniform)
                )

        static member Image(source: WidgetBuilder<'msg, #IFabDrawingImage>, ?stretch: Stretch) =
            match stretch with
            | Some value ->
                WidgetBuilder<'msg, IFabImage>(
                    Image.WidgetKey,
                    AttributesBundle(
                        StackList.one (Image.Stretch.WithValue(value)),
                        ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |],
                        ValueNone
                    )
                )
            | None ->
                WidgetBuilder<'msg, IFabImage>(
                    Image.WidgetKey,
                    AttributesBundle(
                        StackList.one (Image.Stretch.WithValue(Stretch.Uniform)),
                        ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |],
                        ValueNone
                    )
                )

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))
