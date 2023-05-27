namespace Gallery.Pages

open System
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

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
        | SelectedDateChanged dateTime -> { model with Date = dateTime }

    let startFromYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1.0))

    let showUpToTomorrow = DateTime.Today.Add(TimeSpan.FromDays(1.0))

    let view model =
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
