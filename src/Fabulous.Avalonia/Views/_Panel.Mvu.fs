namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous.Avalonia

module MvuPanel =
    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Panel_Children" (fun x -> (x :?> Panel).Children)
