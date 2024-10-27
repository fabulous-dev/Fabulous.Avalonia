namespace Gallery


open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module TabStripPage =
    let view () =
        TabStrip([ "Tab 1"; "Tab 2"; "Tab 3" ], (fun x -> TextBlock(x)))
