namespace Gallery

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module DataGridPage =
    type Model = { Nothing: int }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = 0 }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view _ =
        DataGrid([ "A"; "B" ], (fun x -> TextBlock(x)))
