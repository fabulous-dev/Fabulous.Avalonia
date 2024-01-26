namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ToggleSplitButtonPage =
    type Model =
        { Count: int
          IsChecked: bool
          IsChecked2: bool }

    type Msg =
        | Clicked
        | Increment
        | Decrement
        | Reset
        | CheckedChanged of bool
        | CheckedChanged2 of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Count = 0
          IsChecked = false
          IsChecked2 = false },
        []

    let update msg model =
        match msg with
        | Clicked -> model, []
        | Increment -> { model with Count = model.Count + 1 }, []
        | Decrement -> { model with Count = model.Count - 1 }, []
        | Reset -> { model with Count = 0 }, []
        | CheckedChanged b -> { model with IsChecked = b }, []
        | CheckedChanged2 b -> { model with IsChecked2 = b }, []

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

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
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
            let! model = Mvu.State

            VStack(spacing = 15.) {
                TextBlock($"Count: i {model.Count}")

                ToggleSplitButton("Press me!", model.IsChecked, CheckedChanged)
                    .flyout(menu())

                ToggleSplitButton(
                    model.IsChecked2,
                    CheckedChanged2,
                    HStack() {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .size(32., 32.)
                    }
                )
                    .flyout(menu())
            }
        }
