namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module DropDownButton =
    type Model = { Count: int }

    type Msg =
        | Clicked
        | Clicked2
        | Increment
        | Decrement
        | Reset

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Clicked -> model
        | Clicked2 -> model
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
        | Reset -> { model with Count = 0 }

    let menu () =
        Flyout(
            VStack() {
                Button("Increment", Increment).width(100)
                Button("Decrement", Decrement).width(100)
                Button("Reset", Reset).width(100)
            }
        )
            .showMode(FlyoutShowMode.Standard)
            .placement(PlacementMode.RightEdgeAlignedTop)

    let view model =
        VStack(spacing = 15.) {
            TextBlock($"Count: {model.Count}").centerVertical()

            DropDownButton("Open...", Clicked).flyout(menu())

            DropDownButton(
                Clicked2,
                HStack() {
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                        .size(32., 32.)
                }
            )
                .flyout(menu())
        }

    let sample =
        { Name = "DropDownButton"
          Description = "A button with an added drop-down chevron to visually indicate it has a flyout with additional actions."
          Program = Helper.createProgram init update view }
