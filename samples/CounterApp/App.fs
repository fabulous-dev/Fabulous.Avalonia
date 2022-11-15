namespace CounterApp

open System
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

module App =
    type Model =
        { Count: int
          Step: int
          TimerOn: bool }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick

    let initModel = { Count = 0; Step = 1; TimerOn = false }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.ofAsyncMsg

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment ->
            { model with
                  Count = model.Count + model.Step },
            Cmd.none
        | Decrement ->
            { model with
                  Count = model.Count - model.Step },
            Cmd.none
        | Reset -> initModel, Cmd.none
        | SetStep n -> { model with Step = int(n + 0.5) }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd() else Cmd.none)
        | TimedTick ->
            if model.TimerOn then
                { model with
                      Count = model.Count + model.Step },
                timerCmd()
            else
                model, Cmd.none

    let view model =
        SingleViewApplication(
            (VStack() {
                TextBlock($"%d{model.Count}").centerText()
                
                Button("Increment", Increment)
                    .centerHorizontal()
                
                Button("Decrement", Decrement)
                    .centerHorizontal()
                
                (HStack() {
                    TextBlock("Timer")
                
                    ToggleSwitch(model.TimerOn, TimerToggled)
                 })
                    .margin(20.)
                    .centerHorizontal()
                
                Slider(0.0, 10.0, double model.Step, SetStep)
                
                TextBlock($"Step size: %d{model.Step}")
                    .centerText()
                
                Button("Reset", Reset)
                    .centerHorizontal()
                    
                DatePicker(DateTimeOffset.Now)
                    
             })
                .center()
        )
            .styles() {
                FluentTheme(FluentThemeMode.Light)
            }
            

    let program = Program.statefulWithCmd init update view
