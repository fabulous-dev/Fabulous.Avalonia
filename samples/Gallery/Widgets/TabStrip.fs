namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TabStrip =
    type Model = { Items: string list }

    type Msg = Id

    let init () =
        { Items = [ "Tab 1"; "Tab 2"; "Tab 3" ] }

    let update msg model =
        match msg with
        | Id -> model

    let view model =
        TabStrip(model.Items, (fun x -> TextBlock(x)))

    let sample =
        { Name = "TabStrip"
          Description = "TabStrip is a control that displays a collection of tabs."
          Program = Helper.createProgram init update view }
