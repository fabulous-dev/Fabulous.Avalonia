namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabTimePicker =
    inherit IFabTemplatedControl

module TimePicker =
    let WidgetKey = Widgets.register<TimePicker> ()

    let ClockIdentifier =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.ClockIdentifierProperty

    let MinuteIncrement =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.MinuteIncrementProperty

    let SelectedTime =
        Attributes.defineAvaloniaProperty<TimeSpan, Nullable<TimeSpan>>
            TimePicker.SelectedTimeProperty
            Nullable
            ScalarAttributeComparers.equalityCompare

    let SelectedTimeChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent
            "TimePicker_SelectedTimeChanged"
            TimePicker.SelectedTimeProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module TimePickerBuilders =
    type Fabulous.Avalonia.View with

        static member inline TimePicker(time: TimeSpan, onValueChanged: TimeSpan -> 'msg) =
            WidgetBuilder<'msg, IFabTimePicker>(
                TimePicker.WidgetKey,
                TimePicker.SelectedTime.WithValue(time),
                TimePicker.SelectedTimeChanged.WithValue(
                    ValueEventData.create time (fun args -> onValueChanged args |> box)
                )
            )

[<Extension>]
type TimePickerModifiers =

    [<Extension>]
    static member inline clockIdentifier(this: WidgetBuilder<'msg, #IFabTimePicker>, value: string) =
        this.AddScalar(TimePicker.ClockIdentifier.WithValue(value))

    [<Extension>]
    static member inline minuteIncrement(this: WidgetBuilder<'msg, #IFabTimePicker>, value: int) =
        this.AddScalar(TimePicker.MinuteIncrement.WithValue(value))
