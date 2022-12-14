namespace Gallery

open System
open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ButtonSpinner =
    type Model = { Count: int }

    type Msg = Increment of SpinEventArgs

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment args ->

            let spinner = args.Source :?> ButtonSpinner
            let currentSpinValue = spinner.Content :?> string

            let mutable currentValue =
                if System.String.IsNullOrEmpty(currentSpinValue) then
                    0
                else
                    Convert.ToInt32(currentSpinValue)

            if (args.Direction = SpinDirection.Increase) then
                currentValue <- currentValue + 1
            else
                currentValue <- currentValue - 1

            spinner.Content <- currentValue.ToString()

            { model with Count = model.Count + 1 }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("Button spinner")

            ButtonSpinner("1", Increment)
        }

    let sample =
        { Name = "ButtonSpinner"
          Description = "A button widget that repeats its command when pressed and held"
          Program = Helper.createProgram init update view }
