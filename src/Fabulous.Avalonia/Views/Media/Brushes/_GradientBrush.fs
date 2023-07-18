namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabGradientBrush =
    inherit IFabBrush

module GradientBrush =

    let SpreadMethod =
        Attributes.defineAvaloniaPropertyWithEquality GradientBrush.SpreadMethodProperty

    let GradientStops =
        Attributes.defineAvaloniaListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops)

[<Extension>]
type GradientBrushModifiers =

    /// <summary>Sets the SpreadMethod property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SpreadMethod value.</param>
    [<Extension>]
    static member inline spreadMethod(this: WidgetBuilder<'msg, #IFabGradientBrush>, value: GradientSpreadMethod) =
        this.AddScalar(GradientBrush.SpreadMethod.WithValue(value))
