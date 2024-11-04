namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous.Avalonia

module ComponentGradientBrush =
    let GradientStops =
        Attributes.defineAvaloniaListWidgetCollectionNoDispatch "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops)
