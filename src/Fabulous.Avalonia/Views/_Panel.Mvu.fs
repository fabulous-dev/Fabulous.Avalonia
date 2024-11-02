namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous.Avalonia

module MvuPanel =
    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)
