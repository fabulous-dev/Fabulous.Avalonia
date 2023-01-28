namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module RadioButton =
    type Model = Id

    type Msg =
        | Checked
        | UnChecked

    let init () = Id

    let update msg model =
        match msg with
        | Checked -> model
        | UnChecked -> model

    let view _ =
        VStack() {
            TextBlock("Allows the selection of a single option of many")

            HStack(16.) {
                VStack(16.) {
                    RadioButton("Option 1", true).onChecked(Checked).onUnchecked(UnChecked)

                    RadioButton("Option 1", true)
                    RadioButton("Option 2", false)
                    ThreeStateRadioButton("Option 3", None)
                    ThreeStateRadioButton("Option 3", None)
                    RadioButton("Disabled", false).isEnabled(false)
                }

                VStack(16.) {
                    ThreeStateRadioButton("Three States: Option 1", Some true)
                    ThreeStateRadioButton("Three States: Option 1", Some true)
                    ThreeStateRadioButton("Three States: Option 2", Some false)
                    ThreeStateRadioButton("Three States: Option 2", Some false)
                    ThreeStateRadioButton("Three States: Option 3", None)
                    ThreeStateRadioButton("Three States: Option 3", None)
                    ThreeStateRadioButton("Disabled", None).isEnabled(false)
                    ThreeStateRadioButton("Disabled", None).isEnabled(false)
                }

                VStack(16.) {
                    RadioButton("Group A: Option 1", true).groupName("A")
                    RadioButton("Group A: Option 1", true).groupName("A")
                    RadioButton("Group A: Disabled", false).groupName("A").isEnabled(false)
                    RadioButton("Group B: Option 1", false).groupName("B")
                    ThreeStateRadioButton("Group B: Option 3", None).groupName("B")
                    ThreeStateRadioButton("Group B: Option 3", None).groupName("B")
                }

                VStack(16.) {
                    RadioButton("Group A: Option 2", true).groupName("A")
                    RadioButton("Group A: Option 2", true).groupName("A")
                    RadioButton("Group B: Option 2", false).groupName("B")
                    ThreeStateRadioButton("Group B: Option 4", None).groupName("B")
                    ThreeStateRadioButton("Group B: Option 4", None).groupName("B")
                }
            }
        }

    let sample =
        { Name = "RadioButton"
          Description = "Represents a button that allows a user to select a single option from a group of options."
          Program = Helper.createProgram init update view }
