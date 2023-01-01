namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ToggleSplitButton =
    type Model = { Count: int; IsChecked: bool }

    type Msg =
        | Clicked
        | Increment
        | Decrement
        | Reset
        | CheckedChanged of bool

    let init () = { Count = 0; IsChecked = false }

    let update msg model =
        match msg with
        | Clicked -> model
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
        | Reset -> { model with Count = 0 }
        | CheckedChanged b -> { model with IsChecked = b }

    let view model =
        VStack(spacing = 15.) {
            TextBlock($"Count: i {model.Count}")

            ToggleSplitButton("Press me!", Clicked)
                .onCheckedChanged(model.IsChecked, CheckedChanged)
                .flyout (
                    Flyout(
                        VStack() {
                            Button("Increment", Increment).width (100)
                            Button("Decrement", Decrement).width (100)
                            Button("Reset", Reset).width (100)
                        }
                    )
                        .showMode(FlyoutShowMode.Standard)
                        .placement (FlyoutPlacementMode.RightEdgeAlignedTop)
                )
        }

    let sample =
        { Name = "ToggleSplitButton"
          Description =
            "The ToggleSplitButton functions as a ToggleButton with primary and secondary parts that can each be pressed separately. The primary part behaves like a normal ToggleButton and the secondary part opens a Flyout with additional actions."
          Program = Helper.createProgram init update view }
