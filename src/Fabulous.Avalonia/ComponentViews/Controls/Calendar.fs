namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentCalendar =
    inherit IFabComponentTemplatedControl
    inherit IFabCalendar

module ComponentCalendar =
    let SelectedDateChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent
            "Calendar_SelectedDateChanged"
            Calendar.SelectedDateProperty
            Option.toNullable
            Option.ofNullable

    let DisplayDateChanged =
        ComponentAttributes.defineEvent "Calendar_DisplayDateChanged" (fun target -> (target :?> Calendar).DisplayDateChanged)

    let DisplayModeChanged =
        ComponentAttributes.defineEvent "Calendar_DisplayModeChanged" (fun target -> (target :?> Calendar).DisplayModeChanged)

[<AutoOpen>]
module ComponentCalendarBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> unit) =
            WidgetBuilder<unit, IFabComponentCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(CalendarSelectionMode.SingleDate),
                ComponentCalendar.SelectedDateChanged.WithValue(ComponentValueEventData.create date fn)
            )

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        /// <param name="mode">The selection mode.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> unit, mode: CalendarSelectionMode) =
            WidgetBuilder<unit, IFabComponentCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(mode),
                ComponentCalendar.SelectedDateChanged.WithValue(ComponentValueEventData.create date fn)
            )

type ComponentCalendarModifiers =
    /// <summary>Listens to the Calendar DisplayDateChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayDateChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayDateChanged(this: WidgetBuilder<'msg, #IFabComponentCalendar>, fn: CalendarDateChangedEventArgs -> unit) =
        this.AddScalar(ComponentCalendar.DisplayDateChanged.WithValue(fn))

    /// <summary>Listens to the Calendar DisplayModeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayModeChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayModeChanged(this: WidgetBuilder<'msg, #IFabComponentCalendar>, fn: CalendarModeChangedEventArgs -> unit) =
        this.AddScalar(ComponentCalendar.DisplayModeChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct Calendar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCalendar>, value: ViewRef<Calendar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
