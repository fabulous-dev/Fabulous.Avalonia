namespace Gallery

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =
    type Model = { Text: string }

    type Msg = SelectionIndexChanged of int

    let initModel = { Text = "Hello World" }


    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | SelectionIndexChanged i -> model, Cmd.none

    let buttonSpinnerHeader () = VStack() { TextBlock("Im a pane") }

    let buttonSpinnerContent () =
        VStack() { TextBlock("Im the content") }

    let view _ =
        SplitView(buttonSpinnerHeader().background (SolidColorBrush(Colors.Red)), buttonSpinnerContent ())
            .isPaneOpen (true)
    // (TabControl(Dock.Left) {
    //
    //     TabItem(buttonSpinnerHeader (), buttonSpinnerContent ())
    //     TabItem("Second header", VStack() { TextBlock("Second content") })
    //     TabItem("Third header", VStack() { TextBlock("Third content") })
    //     TabItem("Fourth header", VStack() { TextBlock("Fourth content") })
    // }).onSelectedIndexChanged(0, SelectionIndexChanged)

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
