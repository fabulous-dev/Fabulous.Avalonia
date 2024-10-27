namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabConicGradientBrush =
    inherit IFabGradientBrush

module ConicGradientBrush =
    let WidgetKey = Widgets.register<ConicGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.CenterProperty

    let Angle =
        Attributes.defineAvaloniaPropertyWithEquality ConicGradientBrush.AngleProperty

type ConicGradientBrushModifiers =
    /// <summary>Link a ViewRef to access the direct ConicGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabConicGradientBrush>, value: ViewRef<ConicGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
