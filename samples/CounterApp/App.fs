namespace CounterApp

open System
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Avalonia.Interactivity

module App =
    type Model =
        { Count: int
          Step: int
          TimerOn: bool
          Date: DateTimeOffset
          EntryText: string
          CopyTest: string }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick
        | DateSelected of DateTimeOffset
        | EntryTextChanged of string
        | TextCopied of RoutedEventArgs

    let initModel =
        { Count = 0
          Step = 1
          TimerOn = false
          Date = DateTimeOffset.Now
          EntryText = ""
          CopyTest = "" }

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
        | DateSelected date -> { model with Date = date }, Cmd.none
        | EntryTextChanged text -> { model with EntryText = text }, Cmd.none
        | TextCopied eventArgs ->
            { model with CopyTest = $"Text copied from {eventArgs.Source.ToString()} at {DateTime.Now:``HH:mm:ss``}" },
            Cmd.none

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

            DatePicker(model.Date, DateSelected)

            TextBlock($"Selected date: {model.Date:``yyyy-MM-dd``}").centerText ()

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
                .selectionForegroundBrush(SolidColorBrush(Colors.Yellow))
                .undoLimit(5)
                .onCopyingToClipboard (TextCopied)


            TextBlock($"You Entered: {model.EntryText}")

            TextBlock(model.CopyTest)

        })
            .center ()

#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmd init update app
