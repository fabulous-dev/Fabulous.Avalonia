namespace Gallery

open System
open System.Diagnostics
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module CalendarDatePickerPage =
    type Model = { Date: DateTime option }

    type Msg = SelectedDateChanged of DateTime option

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Date = Some DateTime.Now }, []

    let update msg model =
        match msg with
        | SelectedDateChanged dateTime -> { Date = dateTime }, []

    let startFromYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1.0))

    let showUpToTomorrow = DateTime.Today.Add(TimeSpan.FromDays(1.0))

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
                TextBlock($"Selected date: {model.Date}")

                CalendarDatePicker(model.Date, SelectedDateChanged)
                    .watermark("Select a date")
                    .displayDateStart(Some startFromYesterday)
                    .displayDateEnd(Some showUpToTomorrow)
                    .isTodayHighlighted(true)
                    .useFloatingWatermark(true)
                    .isDropDownOpen(true)
                    .centerHorizontal()
            }
        }
