namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToggleSwitch =
    type Model =
        { Value1: bool
          Value2: bool
          Value3: bool }

    type Msg =
        | ValueChanged of bool
        | ValueChanged1 of bool
        | ValueChanged2 of bool

    let init () =
        { Value1 = false
          Value2 = false
          Value3 = false }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Value1 = value }
        | ValueChanged1 value -> { model with Value2 = value }
        | ValueChanged2 value -> { model with Value3 = value }

    let view model =
        VStack(spacing = 15.) {
            ToggleSwitch(model.Value1, ValueChanged)
                .offContent(TextBlock("Nooo"))
                .onContent("Yessss")
                .content ("Toggle me")

            ToggleSwitch(model.Value2, ValueChanged1)
                .offContent("Nooo")
                .onContent(TextBlock("Yessss"))
                .content ("Toggle me")

            ToggleSwitch(model.Value3, ValueChanged2)
                .offContent("Nooo")
                .onContent("Yessss")
                .content (TextBlock("Toggle me"))
        }

    let sample =
        { Name = "ToggleSwitch"
          Description = "Control that can be toggled between two states"
          Program = Helper.createProgram init update view }
