namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module RadioButton =
    type Model =
        { IsChecked1: bool
          IsChecked2: bool
          IsChecked3: bool
          IsChecked4: bool
          IsChecked5: bool
          IsChecked6: bool option }

    type Msg =
        | Checked
        | UnChecked

    let init () =
        { IsChecked1 = false
          IsChecked2 = false
          IsChecked3 = true
          IsChecked4 = false
          IsChecked5 = false
          IsChecked6 = Some false }

    let update msg model =
        match msg with
        | Checked -> model
        | UnChecked -> model


    let view model =
        VStack() {
            VStack() {
                TextBlock("Are you ready?")

                RadioButton("Yes", model.IsChecked1)
                    .groupName("ready")
                    .onChecked(Checked)
                    .onUnchecked(UnChecked)

                RadioButton("No", model.IsChecked2).groupName("ready")
                RadioButton("Maybe", model.IsChecked3).groupName("ready")
            }

            VStack() {
                TextBlock("Male or female?")
                RadioButton("Male", model.IsChecked4).groupName("sex")
                RadioButton("Female", model.IsChecked5).groupName("sex")
                ThreeStateRadioButton("Prefer not to say", model.IsChecked6).groupName("sex")
            }
        }

    let sample =
        { Name = "RadioButton"
          Description = "Represents a button that allows a user to select a single option from a group of options."
          Program = Helper.createProgram init update view }
