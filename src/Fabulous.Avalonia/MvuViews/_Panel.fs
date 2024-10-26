namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous.Avalonia

type IFabMvuPanel =
    inherit IFabMvuControl
    inherit IFabPanel

module MvuPanel =
    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)
