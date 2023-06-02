namespace Gallery.Pages

open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Controls
open Fabulous

open type Fabulous.Avalonia.View

module DockPanelPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing
    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view _ =
        (Dock() {
            Rectangle().fill(SolidColorBrush(Colors.Red)).height(100.).dock(Dock.Top)

            Rectangle().fill(SolidColorBrush(Colors.Blue)).width(100.).dock(Dock.Left)

            Rectangle().fill(SolidColorBrush(Colors.Green)).height(100.).dock(Dock.Bottom)

            Rectangle().fill(SolidColorBrush(Colors.Orange)).width(100.).dock(Dock.Right)

            Rectangle().fill(SolidColorBrush(Colors.Gray))
        })
            .size(300., 300.)
