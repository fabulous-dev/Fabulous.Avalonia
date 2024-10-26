namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentGradientBrush =
    inherit IFabComponentBrush
    inherit IFabGradientBrush

module ComponentGradientBrush =
    let GradientStops =
        ComponentAttributes.defineAvaloniaListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops)

type ComponentGradientBrushModifiers =

    /// <summary>Sets the SpreadMethod property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SpreadMethod value.</param>
    [<Extension>]
    static member inline spreadMethod(this: WidgetBuilder<'msg, #IFabGradientBrush>, value: GradientSpreadMethod) =
        this.AddScalar(GradientBrush.SpreadMethod.WithValue(value))
