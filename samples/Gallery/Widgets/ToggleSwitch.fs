namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToggleSwitch =
    type Model =
        { Value1: bool
          Value2: bool option
          Text2: string }

    type Msg =
        | ValueChanged of bool
        | ValueChanged1 of bool option
        | IntermediaryChanged

    let init () =
        { Value1 = false
          Value2 = Some false
          Text2 = "Toggle me" }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Value1 = value }
        | ValueChanged1 value ->
            let text =
                match value with
                | Some true -> "Yessss"
                | Some false -> "Nooo"
                | None -> "Intermediary"

            { model with
                Value2 = value
                Text2 = text }
        | IntermediaryChanged -> model

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
                .onIndeterminate(IntermediaryChanged)
        }

    let sample =
        { Name = "ToggleSwitch"
          Description = "Control that can be toggled between two states"
          Program = Helper.createProgram init update view }
