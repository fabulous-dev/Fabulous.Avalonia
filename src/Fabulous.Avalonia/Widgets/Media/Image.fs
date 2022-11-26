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
    inherit IFabIImage

module internal ImageSource =
    let fromFile source =
        let assets = AvaloniaLocator.Current.GetService<IAssetLoader>()
        new Bitmap(assets.Open(Uri(source, UriKind.RelativeOrAbsolute)))

module Image =
    let WidgetKey = Widgets.register<Image>()
    
    let Source = Attributes.defineAvaloniaPropertyWithEquality Image.SourceProperty
    
    let SourceWidget = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty
    
    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty
    
    let StretchDirection = Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty
    
[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Avalonia.View with
        static member Image(source: IImage) =
             WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(
                    StackList.one(Image.Source.WithValue(source)),
                    ValueNone,
                    ValueNone)
                )
             
        static member Image(source: string) =
            View.Image(ImageSource.fromFile source)
             
        static member Image(source: WidgetBuilder<'msg, #IFabIImage>) =
             WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| Image.SourceWidget.WithValue(source.Compile()) |],
                    ValueNone)
                )
             

[<Extension>]             
type ImageModifiers =
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabImage>, value: Stretch) =
        this.AddScalar(Image.Stretch.WithValue(value))
        
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))
