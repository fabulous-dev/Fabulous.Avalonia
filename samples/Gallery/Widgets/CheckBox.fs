namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CheckBox =
    type Model =
        { IsChecked1: bool
          IsChecked2: bool
          IsChecked3: bool }

    type Msg =
        | ValueChanged of bool
        | ValueChanged2 of bool
        | ValueChanged3 of bool

    let init () =
        { IsChecked1 = false
          IsChecked2 = true
          IsChecked3 = false }

    let update msg model =
        match msg with
        | ValueChanged b -> { model with IsChecked1 = b }
        | ValueChanged2 b -> { model with IsChecked2 = b }
        | ValueChanged3 b -> { model with IsChecked3 = b }

    let view model =
        VStack(spacing = 15.) {
            CheckBox("Not checked by default", model.IsChecked1, ValueChanged)
            CheckBox("Checked by default", model.IsChecked2, ValueChanged2)
            CheckBox(model.IsChecked3, ValueChanged3)
        }

    let sample =
        { Name = "CheckBox"
          Description = "Control that can be checked or unchecked"
          Program = Helper.createProgram init update view }
