namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

module RenderOptions =

    let BitmapInterpolationMode =
        Attributes.defineAvaloniaPropertyWithEquality RenderOptions.BitmapInterpolationModeProperty

[<Extension>]
type RenderOptionsModifiers =
    [<Extension>]
    static member inline bitmapInterpolationMode(this: WidgetBuilder<'msg, #IFabElement>, value: BitmapInterpolationMode) =
        this.AddScalar(RenderOptions.BitmapInterpolationMode.WithValue(value))
