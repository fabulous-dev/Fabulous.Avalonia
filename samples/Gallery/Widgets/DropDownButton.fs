namespace Gallery

open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module DropDownButton =
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
            TextBlock("Dropdown button")

            DropDownButton("Open...", Clicked)
                .flyout(
                    Flyout(
                        VStack() {
                            Button("Increment", Increment).width(100)
                            Button("Decrement", Decrement).width(100)
                            Button("Reset", Reset).width(100)
                        }
                    )
                        .showMode(FlyoutShowMode.Standard)
                        .placement(FlyoutPlacementMode.RightEdgeAlignedTop)
                )

            TextBlock($"Count: {model.Count}").centerVertical()
        }

    let sample =
        { Name = "DropDownButton"
          Description = "A button with an added drop-down chevron to visually indicate it has a flyout with additional actions."
          Program = Helper.createProgram init update view }
