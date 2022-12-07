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
        Attributes.defineAvaloniaListWidgetCollection "GradientBrush_GradientStops" (fun target ->
            (target :?> PathFigure).Segments)

[<Extension>]
type GradientBrushModifiers =

    [<Extension>]
    static member inline spreadMethod(this: WidgetBuilder<'msg, #IFabGradientBrush>, value: GradientSpreadMethod) =
        this.AddScalar(GradientBrush.SpreadMethod.WithValue(value))
