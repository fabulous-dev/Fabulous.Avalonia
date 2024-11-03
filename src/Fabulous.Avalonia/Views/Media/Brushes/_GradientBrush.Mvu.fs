namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous.Avalonia

module MvuGradientBrush =
    let GradientStops =
        MvuAttributes.defineAvaloniaListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops)
