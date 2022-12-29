namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TabStrip =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        TabStrip() {
            TabStripItem(TextBlock("Tab 1"))
            TabStripItem("Tab 2")
            TabStripItem(TextBlock("Tab 3"), true)
        }

    let sample =
        { Name = "TabStrip"
          Description = "TabStrip is a control that displays a collection of tabs."
          Program = Helper.createProgram init update view }
