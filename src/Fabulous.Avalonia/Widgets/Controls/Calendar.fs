namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabCalendar =
    inherit IFabTemplatedControl

module Calendar =
    let WidgetKey = Widgets.register<Calendar>()

    let FirstDayOfWeek =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.FirstDayOfWeekProperty

    let HeaderBackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Calendar.HeaderBackgroundProperty
        
    let HeaderBackground =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.HeaderBackgroundProperty

    let DisplayMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayModeProperty

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.SelectionModeProperty

    let SelectedDate =
        Attributes.defineAvaloniaPropertyWithEqualityConverter Calendar.SelectedDateProperty Option.toNullable

    let SelectedDateChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent "Calendar_SelectedDateChanged" Calendar.SelectedDateProperty Option.toNullable Option.ofNullable

    let DisplayDate =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateProperty

    let DisplayDateStart =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateStartProperty

    let DisplayDateEnd =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateEndProperty

    let DisplayDateChanged =
        Attributes.defineEvent "Calendar_DisplayDateChanged" (fun target -> (target :?> Calendar).DisplayDateChanged)

    let DisplayModeChanged =
        Attributes.defineEvent "Calendar_DisplayModeChanged" (fun target -> (target :?> Calendar).DisplayModeChanged)

[<AutoOpen>]
module CalendarBuilders =
    type Fabulous.Avalonia.View with

        static member Calendar(date: DateTime option, onSelectionChanged: DateTime option -> 'msg, ?selectionMode: CalendarSelectionMode) =
            match selectionMode with
            | None ->
                WidgetBuilder<'msg, IFabCalendar>(
                    Calendar.WidgetKey,
                    Calendar.SelectedDate.WithValue(date),
                    Calendar.SelectionMode.WithValue(CalendarSelectionMode.SingleDate),
                    Calendar.SelectedDateChanged.WithValue(ValueEventData.create date (fun args -> onSelectionChanged args |> box))
                )

            | Some selectionMode ->
                WidgetBuilder<'msg, IFabCalendar>(
                    Calendar.WidgetKey,
                    Calendar.SelectedDate.WithValue(date),
                    Calendar.SelectionMode.WithValue(selectionMode),
                    Calendar.SelectedDateChanged.WithValue(ValueEventData.create date (fun args -> onSelectionChanged args |> box))
                )

[<Extension>]
type CalendarModifiers =
    [<Extension>]
    static member inline firstDayOfWeek(this: WidgetBuilder<'msg, #IFabCalendar>, value: DayOfWeek) =
        this.AddScalar(Calendar.FirstDayOfWeek.WithValue(value))

    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Calendar.HeaderBackgroundWidget.WithValue(content.Compile()))
        
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, brush: string) =
        this.AddScalar(Calendar.HeaderBackground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline displayMode(this: WidgetBuilder<'msg, #IFabCalendar>, value: CalendarMode) =
        this.AddScalar(Calendar.DisplayMode.WithValue(value))

    [<Extension>]
    static member inline displayDate(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDate.WithValue(value))

    [<Extension>]
    static member inline displayDateStart(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateStart.WithValue(value))

    [<Extension>]
    static member inline displayDateEnd(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateEnd.WithValue(value))

    [<Extension>]
    static member inline onDisplayDateChanged(this: WidgetBuilder<'msg, #IFabCalendar>, onDisplayDateChanged: CalendarDateChangedEventArgs -> 'msg) =
        this.AddScalar(Calendar.DisplayDateChanged.WithValue(fun args -> onDisplayDateChanged args |> box))

    [<Extension>]
    static member inline onDisplayModeChanged(this: WidgetBuilder<'msg, #IFabCalendar>, onDisplayModeChanged: CalendarModeChangedEventArgs -> 'msg) =
        this.AddScalar(Calendar.DisplayModeChanged.WithValue(fun args -> onDisplayModeChanged args |> box))
