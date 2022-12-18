namespace Gallery

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Button =
    type Model = { Count: int }

    type Msg =
        | Clicked
        | Increment
        | Decrement

    let init() = { Count = 0 }

    let update msg model =
        match msg with
        | Clicked -> model
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        VStack(spacing = 15.) {
            TextBlock("Regular button")
            Button("Click me!", Clicked)

            TextBlock("Disabled button")
            Button("Disabled button", Clicked).isEnabled(false)

            TextBlock("Button with styling")

            (HStack(spacing = 15.) {
                Button("Decrement", Decrement)
                    .background(SolidColorBrush(Color.Parse("#FF0000")))
                    .foreground(SolidColorBrush(Color.Parse("#FFFFFF")))
                    .padding(5.)

                TextBlock($"Count: {model.Count}").centerVertical()

                Button("Increment", Increment)
                    .background(SolidColorBrush(Color.Parse("#43ab2f")))
                    .padding(5.)
            })
                .centerHorizontal()
        }
    let sample =
        { Name = "Button"
          Description = "A button widget that reacts to touch events."
          Program = Helper.createProgram init update view }
