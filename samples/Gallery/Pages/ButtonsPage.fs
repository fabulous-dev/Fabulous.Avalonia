namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ButtonsPage =
    type Model = { Nothing: bool }

    type Msg = | Clicked

    let init () = { Nothing = true }, Cmd.none

    let update msg model =
        match msg with
        | Clicked -> model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component(program) {
            (VStack(spacing = 15.) {
                Button("Regular button", Clicked)

                Button("Disabled button", Clicked).isEnabled(false)

                Button("White text, red background", Clicked)
                    .background(SolidColorBrush(Colors.Red))
                    .foreground(SolidColorBrush(Colors.White))
                    .width(200.)

                Button(
                    Clicked,
                    HStack() {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .size(32., 32.)

                        TextBlock("Button with image")
                    }
                )

                Button("No Border", Clicked).borderThickness(0.)

                Button("Border Color", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))

                Button("Thick Border", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .borderThickness(4.)

                Button("Disabled", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .borderThickness(4.)
                    .isEnabled(false)

                Button("IsTabStop=False", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .isTabStop(false)
            })
                .horizontalAlignment(HorizontalAlignment.Center)
        }
