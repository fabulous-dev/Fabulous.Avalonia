namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TabStripPage =
    type Model = { Items: string list }

    type Msg = DoNothing

    let init () =
        { Items = [ "Tab 1"; "Tab 2"; "Tab 3" ] }

    let update msg model =
        match msg with
        | DoNothing -> model

    let view model =
        TabStrip(model.Items, (fun x -> TextBlock(x)))
