namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module SplitButton =
    type Model = { Count: int }

    type Msg =
        | Clicked
        | Increment
        | Decrement
        | Reset

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Clicked -> model
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
        | Reset -> { model with Count = 0 }

    let view model =
        VStack(spacing = 15.) {

            TextBlock($"Count: i {model.Count}")

            SplitButton("Press me!", Clicked)
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
        { Name = "SplitButton"
          Description =
            "The SplitButton functions as a Button with primary and secondary parts that can each be pressed separately. The primary part behaves like normal Button and the secondary part opens a Flyout with additional actions."
          Program = Helper.createProgram init update view }
