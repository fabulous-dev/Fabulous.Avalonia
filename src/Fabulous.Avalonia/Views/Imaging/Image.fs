namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous

type IFabImage =
    inherit IFabControl

module Image =
    let WidgetKey = Widgets.register<Image>()

    let Source = Attributes.defineBindableImageSource Image.SourceProperty

    let SourceWidget = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty

    let StretchDirection =
        Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty

type ImageModifiers =
    /// <summary>Sets the StretchDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StretchDirection value.</param>
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Image control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImage>, value: ViewRef<Image>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
