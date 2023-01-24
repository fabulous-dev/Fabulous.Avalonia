namespace Gallery

open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module ProgressBar =
    type Model = { Progress: int; Max: int }

    type Msg =
        | Clicked
        | ProgressChanged of float

    let init () = { Progress = 5; Max = 20 }

    let update msg model =
        match msg with
        | Clicked ->
            { model with
                Progress = model.Progress % model.Max + 1 }
        | ProgressChanged p -> model

    let view model =
        VStack(spacing = 15.) {
            TextBlock("Progress Bar")

            ProgressBar(0, model.Max, model.Progress, ProgressChanged)
                .showProgressText(true)

            Button("Advance Progress Bar", Clicked)

            TextBlock("Indeterminate Progress Bar").margin(0, 30, 0, 0)

            ProgressBar(0, model.Max, model.Progress, ProgressChanged).isIndeterminate(true)
        }

    let sample =
        { Name = "ProgressBar"
          Description = "A progress bar widget."
          Program = Helper.createProgram init update view }
