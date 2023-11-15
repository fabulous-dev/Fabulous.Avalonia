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

    let IsTodayHighlighted =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.IsTodayHighlightedProperty

    let HeaderBackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Calendar.HeaderBackgroundProperty

    let HeaderBackground =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.HeaderBackgroundProperty

    let DisplayMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayModeProperty

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.SelectionModeProperty

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

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(CalendarSelectionMode.SingleDate),
                Calendar.SelectedDateChanged.WithValue(ValueEventData.create date fn)
            )

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        /// <param name="mode">The selection mode.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg, mode: CalendarSelectionMode) =
            WidgetBuilder<'msg, IFabCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(mode),
                Calendar.SelectedDateChanged.WithValue(ValueEventData.create date fn)
            )

type CalendarModifiers =
    /// <summary>Sets the FirstDayOfWeek property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FirstDayOfWeek value.</param>
    [<Extension>]
    static member inline firstDayOfWeek(this: WidgetBuilder<'msg, #IFabCalendar>, value: DayOfWeek) =
        this.AddScalar(Calendar.FirstDayOfWeek.WithValue(value))

    /// <summary>Sets the IsTodayHighlighted property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTodayHighlighted value.</param>
    [<Extension>]
    static member inline isTodayHighlighted(this: WidgetBuilder<'msg, #IFabCalendar>, value: bool) =
        this.AddScalar(Calendar.IsTodayHighlighted.WithValue(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Calendar.HeaderBackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: IBrush) =
        this.AddScalar(Calendar.HeaderBackground.WithValue(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: string) =
        this.AddScalar(Calendar.HeaderBackground.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the DisplayMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayMode value.</param>
    [<Extension>]
    static member inline displayMode(this: WidgetBuilder<'msg, #IFabCalendar>, value: CalendarMode) =
        this.AddScalar(Calendar.DisplayMode.WithValue(value))

    /// <summary>Sets the DisplayDate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDate value.</param>
    [<Extension>]
    static member inline displayDate(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDate.WithValue(value))

    /// <summary>Sets the DisplayDateStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateStart value.</param>
    [<Extension>]
    static member inline displayDateStart(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateStart.WithValue(value))

    /// <summary>Sets the DisplayDateEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateEnd value.</param>
    [<Extension>]
    static member inline displayDateEnd(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateEnd.WithValue(value))

    /// <summary>Listens to the Calendar DisplayDateChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayDateChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayDateChanged(this: WidgetBuilder<'msg, #IFabCalendar>, fn: CalendarDateChangedEventArgs -> 'msg) =
        this.AddScalar(Calendar.DisplayDateChanged.WithValue(fn))

    /// <summary>Listens to the Calendar DisplayModeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayModeChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayModeChanged(this: WidgetBuilder<'msg, #IFabCalendar>, fn: CalendarModeChangedEventArgs -> 'msg) =
        this.AddScalar(Calendar.DisplayModeChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Calendar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCalendar>, value: ViewRef<Calendar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
