namespace Fabulous.Avalonia


open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Imaging
open Avalonia.Platform
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabCroppedBitmap =
    inherit IFabElement
    
module CroppedBitmap =
    
    let WidgetKey = Widgets.register<CroppedBitmap>()
    
    let Source = Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceProperty
    
    let SourceRect = Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceRectProperty
    
[<AutoOpen>]
module CroppedBitmapBuilders =
    type Fabulous.Avalonia.View with
        static member CroppedBitmap(source: IImage) =
             WidgetBuilder<'msg, IFabCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                AttributesBundle(
                    StackList.one(CroppedBitmap.Source.WithValue(source)),
                    ValueNone,
                    ValueNone)
                )

[<Extension>]             
type CroppedBitmapModifiers =
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabCroppedBitmap>, x: int, y: int, width: int, height: int) =
        this.AddScalar(CroppedBitmap.SourceRect.WithValue(PixelRect(x, y, width, height)))
        
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabCroppedBitmap>, value: PixelSize) =
        this.AddScalar(CroppedBitmap.SourceRect.WithValue(PixelRect(value)))
        
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabCroppedBitmap>, position: PixelPoint, size: PixelSize) =
        this.AddScalar(CroppedBitmap.SourceRect.WithValue(PixelRect(position, size)))
        
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabCroppedBitmap>, topLeft: PixelPoint, bottomRight: PixelPoint) =
        this.AddScalar(CroppedBitmap.SourceRect.WithValue(PixelRect(topLeft, bottomRight)))
