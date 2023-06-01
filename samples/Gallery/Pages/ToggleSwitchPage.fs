namespace Gallery.Pages

open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ToggleSwitchPage =
    type Model =
        { Value1: bool
          Value2: bool option
          Text2: string }

    type Msg =
        | ValueChanged of bool
        | ValueChanged1 of bool option
        | IntermediaryChanged

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Value1 = false
          Value2 = Some false
          Text2 = "Toggle me" },
        []

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Value1 = value }, []
        | ValueChanged1 value ->
            let text =
                match value with
                | Some true -> "Yessss"
                | Some false -> "Nooo"
                | None -> "Intermediary"

            { model with
                Value2 = value
                Text2 = text },
            []
        | IntermediaryChanged -> model, []

    let view model =
        VStack(spacing = 15.) {
            ToggleSwitch(model.Value1, ValueChanged)
                .offContent(TextBlock("Nooo"))
                .onContent("Yessss")
                .content("Toggle me")

            ThreeStateToggleSwitch(model.Value2, ValueChanged1)
                .offContent("Nooo")
                .onContent(TextBlock("Yessss"))
                .content(model.Text2)
        }
