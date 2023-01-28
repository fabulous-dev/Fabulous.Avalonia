namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CheckBox =
    type Model =
        { IsChecked1: bool
          IsChecked2: bool
          IsChecked3: bool option }

    type Msg =
        | ValueChanged of bool
        | ValueChanged2 of bool
        | ValueChanged3 of bool option

    let init () =
        { IsChecked1 = false
          IsChecked2 = true
          IsChecked3 = Some false }

    let update msg model =
        match msg with
        | ValueChanged b -> { model with IsChecked1 = b }
        | ValueChanged2 b -> { model with IsChecked2 = b }
        | ValueChanged3 b -> { model with IsChecked3 = b }

    let view model =
        VStack(spacing = 15.) {
            CheckBox(model.IsChecked1, ValueChanged)
            CheckBox("Checked by default", model.IsChecked2, ValueChanged2)

            ThreeStateCheckBox(
                model.IsChecked3,
                ValueChanged3,
                VStack() {
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                        .size(100., 100.)

                    TextBlock("Fabulous")
                }
            )
        }

    let sample =
        { Name = "CheckBox"
          Description = "Control that can be checked or unchecked"
          Program = Helper.createProgram init update view }
