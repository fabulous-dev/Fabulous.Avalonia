namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module RepeatButton =
    type Model = { Count: int }

    type Msg = | Increment

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("Repeat button")

            RepeatButton("Click me, or press and hold!", Increment).delay(400).interval(200)

            TextBlock($"Count: {model.Count}").centerVertical()
        }

    let sample =
        { Name = "RepeatButton"
          Description = "A button widget that reacts to single touch or repeats while depressed."
          Program = Helper.createProgram init update view }
