namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabLinearGradientBrush =
    inherit IFabGradientBrush

module LinearGradientBrush =
    let WidgetKey = Widgets.register<LinearGradientBrush>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LinearGradientBrush.EndPointProperty

type LinearGradientBrushModifiers =
    /// <summary>Link a ViewRef to access the direct LinearGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabLinearGradientBrush>, value: ViewRef<LinearGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
