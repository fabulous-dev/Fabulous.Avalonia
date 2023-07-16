namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabCalendarDatePicker =
    inherit IFabTemplatedControl

module CalendarDatePicker =
    let WidgetKey = Widgets.register<CalendarDatePicker>()

    let DisplayDate =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.DisplayDateProperty

    let DisplayDateStart =
        Attributes.defineAvaloniaPropertyWithEqualityConverter CalendarDatePicker.DisplayDateStartProperty Option.toNullable

    let DisplayDateEnd =
        Attributes.defineAvaloniaPropertyWithEqualityConverter CalendarDatePicker.DisplayDateEndProperty Option.toNullable

    let FirstDayOfWeek =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.FirstDayOfWeekProperty

    let IsDropDownOpen =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.IsDropDownOpenProperty

    let IsTodayHighlighted =
        Attributes.defineAvaloniaPropertyWithEquality CalendarDatePicker.IsTodayHighlightedProperty

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
        Attributes.defineEvent "CalendarDatePicker_DateValidationError" (fun target -> (target :?> CalendarDatePicker).DateValidationError)

    let CalendarClosed =
        Attributes.defineEventNoArg "CalendarDatePicker_CalendarClosed" (fun target -> (target :?> CalendarDatePicker).CalendarClosed)

    let CalendarOpened =
        Attributes.defineEventNoArg "CalendarDatePicker_CalendarOpened" (fun target -> (target :?> CalendarDatePicker).CalendarOpened)

[<AutoOpen>]
module CalendarDatePickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CalendarDatePicker widget</summary>
        /// <param name="date">The selected date</param>
        /// <param name="fn">Raised when the selected date changes</param>
        static member CalendarDatePicker(date: DateTime option, fn: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabCalendarDatePicker>(
                CalendarDatePicker.WidgetKey,
                CalendarDatePicker.SelectedDateChanged.WithValue(ValueEventData.create date (fun args -> fn args |> box))
            )

[<Extension>]
type CalendarDatePickerModifiers =
    /// <summary>Sets the DisplayDate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDate value</param>
    [<Extension>]
    static member inline displayDate(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime) =
        this.AddScalar(CalendarDatePicker.DisplayDate.WithValue(value))

    /// <summary>Sets the DisplayDateStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateStart value</param>
    [<Extension>]
    static member inline displayDateStart(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime option) =
        this.AddScalar(CalendarDatePicker.DisplayDateStart.WithValue(value))

    /// <summary>Sets the DisplayDateEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateEnd value</param>
    [<Extension>]
    static member inline displayDateEnd(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DateTime option) =
        this.AddScalar(CalendarDatePicker.DisplayDateEnd.WithValue(value))

    /// <summary>Sets the FirstDayOfWeek property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FirstDayOfWeek value</param>
    [<Extension>]
    static member inline firstDayOfWeek(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: DayOfWeek) =
        this.AddScalar(CalendarDatePicker.FirstDayOfWeek.WithValue(value))

    /// <summary>Sets the IsDropDownOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDropDownOpen value</param>
    [<Extension>]
    static member inline isDropDownOpen(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.IsDropDownOpen.WithValue(value))

    /// <summary>Sets the IsTodayHighlighted property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTodayHighlighted value</param>
    [<Extension>]
    static member inline isTodayHighlighted(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.IsTodayHighlighted.WithValue(value))

    /// <summary>Sets the SelectedDateFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedDateFormat value</param>
    [<Extension>]
    static member inline selectedDateFormat(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: CalendarDatePickerFormat) =
        this.AddScalar(CalendarDatePicker.SelectedDateFormat.WithValue(value))

    /// <summary>Sets the CustomDateFormatString property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CustomDateFormatString value</param>
    [<Extension>]
    static member inline customDateFormatString(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.CustomDateFormatString.WithValue(value))

    /// <summary>Sets the Text property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Text value</param>
    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.Text.WithValue(value))

    /// <summary>Sets the Watermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Watermark value</param>
    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: string) =
        this.AddScalar(CalendarDatePicker.Watermark.WithValue(value))

    /// <summary>Sets the UseFloatingWatermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseFloatingWatermark value</param>
    [<Extension>]
    static member inline useFloatingWatermark(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: bool) =
        this.AddScalar(CalendarDatePicker.UseFloatingWatermark.WithValue(value))

    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: HorizontalAlignment) =
        this.AddScalar(CalendarDatePicker.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, value: VerticalAlignment) =
        this.AddScalar(CalendarDatePicker.VerticalContentAlignment.WithValue(value))

    /// <summary>Listens to the CalendarDatePicker DateValidationError event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker detects a format error.</param>
    [<Extension>]
    static member inline onDateValidationError(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: CalendarDatePickerDateValidationErrorEventArgs -> 'msg) =
        this.AddScalar(CalendarDatePicker.DateValidationError.WithValue(fun args -> fn args |> box))

    /// <summary>Listens to the CalendarDatePicker CalendarClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker closes its calendar.</param>
    [<Extension>]
    static member inline onCalendarClosed(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: 'msg) =
        this.AddScalar(CalendarDatePicker.CalendarClosed.WithValue(fn))

    /// <summary>Listens to the CalendarDatePicker CalendarOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker opens its calendar.</param>
    [<Extension>]
    static member inline onCalendarOpened(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: 'msg) =
        this.AddScalar(CalendarDatePicker.CalendarOpened.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct CalendarDatePicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCalendarDatePicker>, value: ViewRef<CalendarDatePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
