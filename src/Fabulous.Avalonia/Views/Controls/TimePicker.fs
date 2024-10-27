namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabTimePicker =
    inherit IFabTemplatedControl

module TimePicker =
    let WidgetKey = Widgets.register<TimePicker>()

    let ClockIdentifier =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.ClockIdentifierProperty

    let MinuteIncrement =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.MinuteIncrementProperty

type TimePickerModifiers =

    /// <summary>Sets the ClockIdentifier property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClockIdentifier value.</param>
    [<Extension>]
    static member inline clockIdentifier(this: WidgetBuilder<'msg, #IFabTimePicker>, value: string) =
        this.AddScalar(TimePicker.ClockIdentifier.WithValue(value))

    /// <summary>Sets the MinuteIncrement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinuteIncrement value.</param>
    [<Extension>]
    static member inline minuteIncrement(this: WidgetBuilder<'msg, #IFabTimePicker>, value: int) =
        this.AddScalar(TimePicker.MinuteIncrement.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TimePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type TimePickerExtraModifiers =
    /// <summary>Sets the ClockIdentifier property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClockIdentifier value.</param>
    [<Extension>]
    static member inline use24HourClock(this: WidgetBuilder<'msg, #IFabTimePicker>, value: bool) =
        this.AddScalar(TimePicker.ClockIdentifier.WithValue(if value then "24HourClock" else "12HourClock"))
