namespace Gallery.Pages

open System
open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CalendarPage =
    type Model = { Date1: DateTime option }

    type Msg = SelectedDateChanged of DateTime option

    let init () = { Date1 = Some DateTime.Now }

    let update msg model =
        match msg with
        | SelectedDateChanged dateTime -> { model with Date1 = dateTime }

    let startFromYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1.0))

    let showUpToTomorrow = DateTime.Today.Add(TimeSpan.FromDays(1.0))

    let view model =
        VStack(spacing = 15.) {
            TextBlock($"Selected: {model.Date1}")
            TextBlock("SingleDate").centerHorizontal()

            Calendar(model.Date1, SelectedDateChanged)
                .displayDateStart(startFromYesterday)
                .displayDateEnd(showUpToTomorrow)
                .centerHorizontal()

            TextBlock("MultipleRange").centerHorizontal()

            Calendar(model.Date1, SelectedDateChanged, CalendarSelectionMode.MultipleRange)
                .displayMode(CalendarMode.Month)
                .center()

            TextBlock("SingleRange").centerHorizontal()

            Calendar(model.Date1, SelectedDateChanged, CalendarSelectionMode.SingleRange)
                .centerHorizontal()
        }
