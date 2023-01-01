namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToggleButton =
    type Model = { Value1: bool }

    type Msg =
        | ToggleMe
        | Checked
        | UnChecked

    let init () = { Value1 = false }

    let update msg model =
        match msg with
        | ToggleMe -> model
        | Checked -> { model with Value1 = true }
        | UnChecked -> { model with Value1 = false }

    let view _ =
        VStack(spacing = 15.) { ToggleButton("Toggle me", ToggleMe).onChecked(Checked).onUnchecked (UnChecked) }

    let sample =
        { Name = "ToggleButton"
          Description = "Control that can be toggled between two states"
          Program = Helper.createProgram init update view }
