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
    /// <summary> Set the BitmapInterpolationMode property.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The BitmapInterpolationMode value</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type BitmapInterpolationMode =
    /// | Default = 0
    /// | LowQuality = 1
    /// | MediumQuality = 2
    /// | HighQuality = 3
    /// </code>
    /// </example>
    [<Extension>]
    static member inline bitmapInterpolationMode(this: WidgetBuilder<'msg, #IFabElement>, value: BitmapInterpolationMode) =
        this.AddScalar(RenderOptions.BitmapInterpolationMode.WithValue(value))
