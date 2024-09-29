namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuGradientBrush =
    inherit IFabMvuBrush
    inherit IFabGradientBrush

module MvuGradientBrush =
    let GradientStops =
        MvuAttributes.defineAvaloniaListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops)

type MvuGradientBrushModifiers =

    /// <summary>Sets the SpreadMethod property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SpreadMethod value.</param>
    [<Extension>]
    static member inline spreadMethod(this: WidgetBuilder<'msg, #IFabGradientBrush>, value: GradientSpreadMethod) =
        this.AddScalar(GradientBrush.SpreadMethod.WithValue(value))
