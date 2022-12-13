namespace Gallery

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =
    type Model = { Text: string }

    type Msg = Id

    let initModel = { Text = "Hello World" }


    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Id -> model, Cmd.none

    let view _ =
        TabControl(Dock.Left) {
            TabItem("First header", VStack() { TextBlock("First content") })
            TabItem("Second header", VStack() { TextBlock("Second content") })
            TabItem("Third header", VStack() { TextBlock("Third content") })
            TabItem("Fourth header", VStack() { TextBlock("Fourth content") })
        }

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
