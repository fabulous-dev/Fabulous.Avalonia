namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module RepeatButton =
    type Model = Id

    type Msg = | Clicked

    let init () = Id

    let update msg model =
        match msg with
        | Clicked -> model

    let view _ =
        VStack(spacing = 15.) {
            RepeatButton("Click me, or press and hold!", Clicked).delay(400).interval (200)

            RepeatButton(
                Clicked,
                HStack(16.) {
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png")
                        .width(20.)
                        .height (20.)

                    TextBlock("Example with custom content")
                }
            )
                .delay(400)
                .interval (200)
        }

    let sample =
        { Name = "RepeatButton"
          Description = "A button widget that reacts to single touch or repeats while depressed."
          Program = Helper.createProgram init update view }
