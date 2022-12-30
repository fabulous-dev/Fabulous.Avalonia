namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabCalendarDatePicker =
    inherit IFabTemplatedControl

module CalendarDatePicker =
    let WidgetKey = Widgets.register<CalendarDatePicker> ()

    let DisplayDate =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.DisplayDateProperty

    let DisplayDateStart =
        Attributes.defineAvaloniaPropertyWithEqualityConverter
            CalendarDatePicker.DisplayDateStartProperty
            Option.toNullable

    let DisplayDateEnd =
        Attributes.defineAvaloniaPropertyWithEqualityConverter
            CalendarDatePicker.DisplayDateEndProperty
            Option.toNullable

    let FirstDayOfWeek =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.FirstDayOfWeekProperty

    let IsDropDownOpen =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.IsDropDownOpenProperty

    let IsTodayHighlighted =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.IsTodayHighlightedProperty

    let SelectedDate =
        Attributes.defineAvaloniaPropertyWithEqualityConverter CalendarDatePicker.SelectedDateProperty Option.toNullable

    let SelectedDateChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent
            "CalendarDatePicker_SelectedDateChanged"
            CalendarDatePicker.SelectedDateProperty
            Option.toNullable
            Option.ofNullable

    let SelectedDateFormat =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.SelectedDateFormatProperty

    let CustomDateFormatString =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.CustomDateFormatStringProperty

    let Text =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.TextProperty

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.WatermarkProperty

    let UseFloatingWatermark =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.UseFloatingWatermarkProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.VerticalContentAlignmentProperty

    let DateValidationError =
        Attributes.defineEvent "CalendarDatePicker_DateValidationError" (fun target ->
            (target :?> CalendarDatePicker).DateValidationError)

    let CalendarClosed =
        Attributes.defineEventNoArg "CalendarDatePicker_CalendarClosed" (fun target ->
            (target :?> CalendarDatePicker).CalendarClosed)

    let CalendarOpened =
        Attributes.defineEventNoArg "CalendarDatePicker_CalendarOpened" (fun target ->
            (target :?> CalendarDatePicker).CalendarOpened)

[<AutoOpen>]
module CalendarDatePickerBuilders =
    type Fabulous.Avalonia.View with

        static member CalendarDatePicker(date: DateTime option, onValueChanged: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabCalendarDatePicker>(
                CalendarDatePicker.WidgetKey,
                CalendarDatePicker.SelectedDate.WithValue(date),
                CalendarDatePicker.SelectedDateChanged.WithValue(
                    ValueEventData.create date (fun args -> onValueChanged args |> box)
                )
            )

[<Extension>]
type CalendarDatePickerModifiers =
    [<Extension>]
    static member inline displayDate(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime) =
        this.AddScalar(CalendarDatePicker.DisplayDate.WithValue(value))

    [<Extension>]
    static member inline displayDateStart(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime option) =
        this.AddScalar(CalendarDatePicker.DisplayDateStart.WithValue(value))

    [<Extension>]
    static member inline displayDateEnd(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime option) =
        this.AddScalar(CalendarDatePicker.DisplayDateEnd.WithValue(value))

    [<Extension>]
    static member inline firstDayOfWeek(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DayOfWeek) =
        this.AddScalar(CalendarDatePicker.FirstDayOfWeek.WithValue(value))

    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.IsDropDownOpen.WithValue(value))

    [<Extension>]
    static member inline isTodayHighlighted(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.IsTodayHighlighted.WithValue(value))

    [<Extension>]
    static member inline selectedDateFormat
        (
            this: WidgetBuilder<'msg, #IFabCalendarDatePicker>,
            value: CalendarDatePickerFormat
        ) =
        this.AddScalar(CalendarDatePicker.SelectedDateFormat.WithValue(value))

    [<Extension>]
    static member inline customDateFormatString(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.CustomDateFormatString.WithValue(value))

    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.Text.WithValue(value))

    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.Watermark.WithValue(value))

    [<Extension>]
    static member inline useFloatingWatermark(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.UseFloatingWatermark.WithValue(value))

    [<Extension>]
    static member inline horizontalContentAlignment
        (
            this: WidgetBuilder<'msg, #IFabCalendarDatePicker>,
            value: HorizontalAlignment
        ) =
        this.AddScalar(CalendarDatePicker.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment
        (
            this: WidgetBuilder<'msg, #IFabCalendarDatePicker>,
            value: VerticalAlignment
        ) =
        this.AddScalar(CalendarDatePicker.VerticalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline onDateValidationError
        (
            this: WidgetBuilder<'msg, #IFabCalendarDatePicker>,
            onDateValidationError: CalendarDatePickerDateValidationErrorEventArgs -> 'msg
        ) =
        this.AddScalar(CalendarDatePicker.DateValidationError.WithValue(fun args -> onDateValidationError args |> box))

    [<Extension>]
    static member inline onCalendarClosed(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, onCalendarClosed: 'msg) =
        this.AddScalar(CalendarDatePicker.CalendarClosed.WithValue(onCalendarClosed))

    [<Extension>]
    static member inline onCalendarOpened(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, onCalendarOpened: 'msg) =
        this.AddScalar(CalendarDatePicker.CalendarOpened.WithValue(onCalendarOpened))
