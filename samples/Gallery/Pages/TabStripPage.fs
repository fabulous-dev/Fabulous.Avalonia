namespace Gallery.Pages

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module TabStripPage =
    type Model = { Items: string list }

    type Msg = DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Items = [ "Tab 1"; "Tab 2"; "Tab 3" ] }, []

    let update msg model =
        match msg with
        | DoNothing -> model

    let view model =
        TabStrip(model.Items, (fun x -> TextBlock(x)))
