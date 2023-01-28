namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToggleButton =
    type Model =
        { Text1: string
          Value1: bool
          Text2: string
          Value2: bool
          Text3: string
          Value3: bool option
          Text4: string
          Value4: bool option }

    type Msg =
        | CheckedChanged of bool
        | CheckedChanged2 of bool

        | IntermediaryState3
        | CheckedChanged3 of bool option
        | CheckedChanged4 of bool option
        | IntermediaryState4



    let init () =
        { Text1 = "Unchecked"
          Value1 = false
          Text2 = "Unchecked"
          Value2 = false
          Text3 = "Toggle me"
          Value3 = Some false
          Text4 = "Toggle me"
          Value4 = Some false }

    let update msg model =
        match msg with
        | CheckedChanged b ->
            let text =
                match b with
                | true -> "Checked"
                | false -> "Unchecked"

            { model with Value1 = b; Text1 = text }

        | CheckedChanged2 b ->
            let text =
                match b with
                | true -> "Checked"
                | false -> "Unchecked"

            { model with Value2 = b; Text2 = text }

        | IntermediaryState3 -> model
        | CheckedChanged3 b ->
            let text =
                match b with
                | Some true -> "Checked"
                | Some false -> "Unchecked"
                | None -> "Intermediary"

            { model with Value3 = b; Text3 = text }

        | IntermediaryState4 -> model
        | CheckedChanged4 b ->
            let text =
                match b with
                | Some true -> "Checked"
                | Some false -> "Unchecked"
                | None -> "Intermediary"

            { model with Value4 = b; Text4 = text }

    let view model =
        VStack(spacing = 15.) {
            ToggleButton(model.Text1, model.Value1, CheckedChanged)

            ToggleButton(
                model.Value2,
                CheckedChanged2,
                HStack() {
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                        .size(16., 16.)

                    TextBlock(model.Text2)
                }
            )

            ThreeStateToggleButton(model.Text3, model.Value3, CheckedChanged3)
                .onIndeterminate(IntermediaryState3)

            ThreeStateToggleButton(
                model.Value4,
                CheckedChanged4,
                HStack() {
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                        .size(16., 16.)

                    TextBlock(model.Text4)
                }
            )
                .onIndeterminate(IntermediaryState4)
        }

    let sample =
        { Name = "ToggleButton"
          Description = "Control that can be toggled between two/three states"
          Program = Helper.createProgram init update view }
