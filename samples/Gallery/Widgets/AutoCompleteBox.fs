namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module AutoCompleteBox =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 15.) {
            AutoCompleteBox([ "Item 1"; "Item 2"; "Item 3" ])
        }

    let sample =
        { Name = "AutoCompleteBox"
          Description = "Represents a control that provides a text box for user input and a drop-down that contains possible matches based on the input in the text box."
          Program = Helper.createProgram init update view }
