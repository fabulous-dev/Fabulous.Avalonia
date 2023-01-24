namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module RadioButton =
    type Model =
        { IsChecked1: bool
          IsChecked2: bool
          IsChecked3: bool }

    type Msg =
        | Checked1
        | Unchecked1

        | Checked2
        | Unchecked2

        | Checked3
        | Unchecked3

    let init () =
        { IsChecked1 = false
          IsChecked2 = false
          IsChecked3 = true }

    let update msg model =
        match msg with
        | Checked1 -> { model with IsChecked1 = true }
        | Unchecked1 -> { model with IsChecked1 = false }
        | Checked2 -> { model with IsChecked2 = true }
        | Unchecked2 -> { model with IsChecked2 = false }
        | Checked3 -> { model with IsChecked3 = true }
        | Unchecked3 -> { model with IsChecked3 = false }

    let view model =
        VStack() {
            VStack() {
                TextBlock("Are you ready?")
                RadioButton("Yes", model.IsChecked1).groupName("ready")
                RadioButton("No", model.IsChecked2).groupName("ready")
                RadioButton("Maybe", model.IsChecked3).groupName("ready")
            }

            VStack() {
                TextBlock("Male or female?")
                RadioButton("Male", false).groupName("sex").onChecked(Checked1)

                RadioButton("Female", false).groupName("sex")
                RadioButton("Prefer not to say", true).groupName("sex")
            }
        }

    let sample =
        { Name = "RadioButton"
          Description = "Represents a button that allows a user to select a single option from a group of options."
          Program = Helper.createProgram init update view }
