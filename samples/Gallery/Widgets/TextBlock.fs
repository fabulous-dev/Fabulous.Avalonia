namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TextBlock =
    type Model = { Count: int }

    type Msg =
        | Clicked
        | Increment
        | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Clicked -> model
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        VStack(spacing = 15.) { TextBlock("Hello World!") }

    let sample =
        { Name = "TextBlock"
          Description = "A simple text block"
          Program = Helper.createProgram init update view }
