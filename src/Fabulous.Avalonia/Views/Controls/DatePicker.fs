namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabDatePicker =
    inherit IFabTemplatedControl

module DatePicker =
    let WidgetKey = Widgets.register<DatePicker>()

    let DayVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayVisibleProperty

    let MonthVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthVisibleProperty

    let YearVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearVisibleProperty

    let DayFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayFormatProperty

    let MonthFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthFormatProperty

    let YearFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearFormatProperty

    let MinYear =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MinYearProperty

    let MaxYear =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MaxYearProperty

    let SelectedDate =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.SelectedDateProperty

    let SelectedDateChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent "DatePicker_SelectedDateChanged" DatePicker.SelectedDateProperty Nullable Nullable.op_Explicit

[<AutoOpen>]
module DatePickerBuilders =
    type Fabulous.Avalonia.View with

        static member inline DatePicker(date: DateTimeOffset, onValueChanged: DateTimeOffset -> 'msg) =
            WidgetBuilder<'msg, IFabDatePicker>(
                DatePicker.WidgetKey,
                DatePicker.SelectedDate.WithValue(date),
                DatePicker.SelectedDateChanged.WithValue(ValueEventData.create date (fun args -> onValueChanged args |> box))
            )

[<Extension>]
type DatePickerModifiers =
    [<Extension>]
    static member inline dayVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.DayVisible.WithValue(value))

    [<Extension>]
    static member inline monthVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.MonthVisible.WithValue(value))

    [<Extension>]
    static member inline yearVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.YearVisible.WithValue(value))

    [<Extension>]
    static member inline dayFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.DayFormat.WithValue(value))

    [<Extension>]
    static member inline monthFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.MonthFormat.WithValue(value))

    [<Extension>]
    static member inline yearFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.YearFormat.WithValue(value))

    [<Extension>]
    static member inline minYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MinYear.WithValue(value))

    [<Extension>]
    static member inline maxYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MaxYear.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DatePicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDatePicker>, value: ViewRef<DatePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
