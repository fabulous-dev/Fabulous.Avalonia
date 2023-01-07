namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabCroppedBitmap =
    inherit IFabElement

module CroppedBitmap =

    let WidgetKey = Widgets.register<CroppedBitmap> ()

    let Source =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceProperty

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceRectProperty

[<AutoOpen>]
module CroppedBitmapBuilders =
    type Fabulous.Avalonia.View with

        static member CroppedBitmap(source: IImage, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                CroppedBitmap.Source.WithValue(source),
                CroppedBitmap.SourceRect.WithValue(rect)
            )
