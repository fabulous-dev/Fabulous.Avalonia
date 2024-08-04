namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open Fabulous.Avalonia

type IFabComponentPanel =
    inherit IFabComponentControl
    inherit IFabPanel

module ComponentPanel =
    let Children =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)
