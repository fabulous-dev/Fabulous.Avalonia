namespace CounterApp

open System
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =
    type Model =
        { Count: int
          Step: int
          TimerOn: bool
          EntryText: string }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick
        | EntryTextChanged of string

    let initModel =
        { Count = 0
          Step = 1
          TimerOn = false
          EntryText = "" }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.ofAsyncMsg

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, Cmd.none
        | Decrement -> { model with Count = model.Count - model.Step }, Cmd.none
        | Reset -> initModel, Cmd.none
        | SetStep n -> { model with Step = int (n + 0.5) }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd () else Cmd.none)
        | TimedTick ->
            if model.TimerOn then
                { model with Count = model.Count + model.Step }, timerCmd ()
            else
                model, Cmd.none
        | EntryTextChanged text -> { model with EntryText = text }, Cmd.none

    let view model =
        (VStack() {
            TextBlock($"%d{model.Count}").centerText ()

            Button("Increment", Increment).centerHorizontal ()

            Button("Decrement", Decrement).centerHorizontal ()

            (HStack() {
                TextBlock("Timer").centerVertical ()

                ToggleSwitch(model.TimerOn, TimerToggled)

                CheckBox(model.TimerOn, TimerToggled)
            })
                .margin(20.)
                .centerHorizontal ()

            Slider(0.0, 10.0, double model.Step, SetStep)

            TextBlock($"Step size: %d{model.Step}").centerText ()

            Button("Reset", Reset).centerHorizontal ()

            DatePicker(Some DateTimeOffset.Now)

            TextBox(model.EntryText, EntryTextChanged)
                .margin(0, 10)
                .height(100)
                .textAlignment(TextAlignment.Center)
                .verticalContentAlignment(VerticalAlignment.Center)
                .acceptsReturn(true)
                .acceptsTab(true)
                .maxLines(3)
                .watermark("Enter some text...")
                .useFloatingWatermark(false)
                .caretBrush(SolidColorBrush(Colors.Green))
                .selectionBrush(SolidColorBrush(Colors.Red))
                .selectionForegroundBrush (SolidColorBrush(Colors.Yellow))

            TextBlock($"You Entered: {model.EntryText}")

        })
            .center ()

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
