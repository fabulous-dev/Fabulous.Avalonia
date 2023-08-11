namespace Gallery.Root

open Fabulous.Avalonia
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        SingleViewApplication(Panel() { HamburgerMenu.mainView model })
