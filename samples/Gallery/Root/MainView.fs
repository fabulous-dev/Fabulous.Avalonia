namespace Gallery.Root


open Fabulous
open Fabulous.Avalonia
open Gallery
open Types

open type Fabulous.Avalonia.View

module MainView =
    let view (model: Model) =
        SingleViewApplication(Grid() { View.map PageMsg (Pages.View.view model.PageModel) })
