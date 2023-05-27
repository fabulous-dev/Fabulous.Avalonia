namespace Gallery.Pages

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open type Fabulous.Avalonia.View
open Gallery

module PanelPage =
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model

    let view model =
        (Panel() {
            Rectangle()
                .fill(SolidColorBrush(Colors.Red))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Top)

            Rectangle()
                .fill(SolidColorBrush(Colors.Blue))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Right)

            Rectangle()
                .fill(SolidColorBrush(Colors.Green))
                .height(100.)
                .verticalAlignment(VerticalAlignment.Bottom)

            Rectangle()
                .fill(SolidColorBrush(Colors.Orange))
                .width(100.)
                .horizontalAlignment(HorizontalAlignment.Left)
        })
            .width(300.)
            .height(300.)
