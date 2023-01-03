namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module MaskedTextBox =
    type Model = { MaskedText: string }

    type Msg = TextChanged of string

    let init () = { MaskedText = "" }

    let update msg model =
        match msg with
        | TextChanged text -> { model with MaskedText = text }

    let view model =
        VStack(spacing = 15) {

            TextBlock("Enter a ten-digit number:")

            MaskedTextBox(model.MaskedText, "(000) 000-0000", TextChanged)

            TextBlock($"You Entered: {model.MaskedText}")
        }

    let sample =
        { Name = "MaskedTextBox"
          Description =
            "A control for text input restricted by a mask. The Mask Property follows the same configuration as WPF masks."
          Program = Helper.createProgram init update view }
