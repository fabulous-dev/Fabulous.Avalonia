namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabCroppedBitmap =
    inherit IFabElement

module CroppedBitmap =

    let WidgetKey = Widgets.register<CroppedBitmap>()

    let Source =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceProperty

    let SourceWidget =
        Attributes.defineAvaloniaPropertyWidget CroppedBitmap.SourceProperty

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

        static member CroppedBitmap(source: WidgetBuilder<'msg, #IFabDrawing>, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(
                CroppedBitmap.WidgetKey,
                AttributesBundle(
                    StackList.one(CroppedBitmap.SourceRect.WithValue(rect)),
                    ValueSome [| CroppedBitmap.SourceWidget.WithValue(source.Compile()) |],
                    ValueNone
                )
            )
