namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuCalendar =
    inherit IFabMvuTemplatedControl
    inherit IFabCalendar

module MvuCalendar =
    let SelectedDateChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent "Calendar_SelectedDateChanged" Calendar.SelectedDateProperty Option.toNullable Option.ofNullable

    let DisplayDateChanged =
        Attributes.defineEvent "Calendar_DisplayDateChanged" (fun target -> (target :?> Calendar).DisplayDateChanged)

    let DisplayModeChanged =
        Attributes.defineEvent "Calendar_DisplayModeChanged" (fun target -> (target :?> Calendar).DisplayModeChanged)

[<AutoOpen>]
module MvuCalendarBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabMvuCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(CalendarSelectionMode.SingleDate),
                MvuCalendar.SelectedDateChanged.WithValue(MvuValueEventData.create date fn)
            )

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        /// <param name="mode">The selection mode.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg, mode: CalendarSelectionMode) =
            WidgetBuilder<'msg, IFabMvuCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(mode),
                MvuCalendar.SelectedDateChanged.WithValue(MvuValueEventData.create date fn)
            )

type MvuCalendarModifiers =
    /// <summary>Listens to the Calendar DisplayDateChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayDateChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayDateChanged(this: WidgetBuilder<'msg, #IFabMvuCalendar>, fn: CalendarDateChangedEventArgs -> 'msg) =
        this.AddScalar(MvuCalendar.DisplayDateChanged.WithValue(fn))

    /// <summary>Listens to the Calendar DisplayModeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayModeChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayModeChanged(this: WidgetBuilder<'msg, #IFabMvuCalendar>, fn: CalendarModeChangedEventArgs -> 'msg) =
        this.AddScalar(MvuCalendar.DisplayModeChanged.WithValue(fn))

type MvuCalendarExtraModifiers =
    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: Color) =
        CalendarModifiers.headerBackground(this, View.SolidColorBrush(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: string) =
        CalendarModifiers.headerBackground(this, View.SolidColorBrush(value))