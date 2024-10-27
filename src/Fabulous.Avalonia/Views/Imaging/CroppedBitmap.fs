namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media.Imaging
open Fabulous

type IFabCroppedBitmap =
    inherit IFabElement

module CroppedBitmap =

    let WidgetKey = Widgets.register<CroppedBitmap>()

    let Source = Attributes.defineBindableImageSource CroppedBitmap.SourceProperty

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality CroppedBitmap.SourceRectProperty

type CroppedBitmapModifiers =
    /// <summary>Link a ViewRef to access the direct CroppedBitmap control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCroppedBitmap>, value: ViewRef<CroppedBitmap>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
