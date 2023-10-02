namespace Gallery

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ButtonsPage =
    type Model = { Nothing: bool }

    type Msg = | Clicked

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | Clicked -> model, []

    let view _ =
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
                    Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
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
