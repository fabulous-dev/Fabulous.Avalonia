namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module SelectableTextBlock =
    type Model = { Count: int }

    type Msg = | Clicked

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Clicked -> model

    let view model =
        VStack(spacing = 15.) {
            SelectableTextBlock("Select some text. You can use the cursor to change the selection.")
                .selectionBrush(SolidColorBrush(Colors.LightBlue))
                .selectionStart(7)
                .selectionEnd (11)
        }

    let sample =
        { Name = "SelectableTextBlock"
          Description = "A text block with selectable text"
          Program = Helper.createProgram init update view }
