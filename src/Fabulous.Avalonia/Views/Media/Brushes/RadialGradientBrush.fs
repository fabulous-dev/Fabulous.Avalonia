namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabRadialGradientBrush =
    inherit IFabGradientBrush

module RadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let Radius =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusProperty

type RadialGradientBrushModifiers =

    /// <summary>Sets the Radius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radius(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: float) =
        this.AddScalar(RadialGradientBrush.Radius.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RadialGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: ViewRef<RadialGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
