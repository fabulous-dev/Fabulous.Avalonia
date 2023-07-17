namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabCroppedBitmap =
    inherit IFabElement

module CroppedBitmap =

    let WidgetKey = Widgets.register<CroppedBitmap>()

    let Source =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceProperty

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceRectProperty

[<AutoOpen>]
module CroppedBitmapBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CroppedBitmap widget</summary>
        /// <param name="source">The source image</param>
        /// <param name="rect">The rectangular area that the bitmap is cropped to.</param>
        static member CroppedBitmap(source: IImage, rect: PixelRect) =
            WidgetBuilder<'msg, IFabCroppedBitmap>(CroppedBitmap.WidgetKey, CroppedBitmap.Source.WithValue(source), CroppedBitmap.SourceRect.WithValue(rect))

[<Extension>]
type CroppedBitmapModifiers =
    /// <summary>Link a ViewRef to access the direct CroppedBitmap control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCroppedBitmap>, value: ViewRef<CroppedBitmap>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
