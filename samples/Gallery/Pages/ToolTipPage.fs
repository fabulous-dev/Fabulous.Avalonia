namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ToolTipPage =
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
        VStack(spacing = 15.) {
            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tooltip("Im a tooltip!")

            Border(TextBlock("Hover over me!"))
                .padding(10.)
                .background(SolidColorBrush(Colors.LightGray))
                .tooltip(
                    VStack() {
                        TextBlock("ToolTip")
                        TextBlock("A control which pops up a hint when a control is hovered")
                    }
                )
                .tooltipShowDelay(1000)
        }
