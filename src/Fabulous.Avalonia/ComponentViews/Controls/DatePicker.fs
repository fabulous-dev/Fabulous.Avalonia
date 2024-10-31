namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentDatePicker =
    inherit IFabComponentTemplatedControl
    inherit IFabDatePicker

module ComponentDatePicker =
    let SelectedDateChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent
            "DatePicker_SelectedDateChanged"
            DatePicker.SelectedDateProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module ComponentDatePickerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DatePicker widget.</summary>
        /// <param name="date">The initial date.</param>
        /// <param name="fn">Raised when the selected date changes.</param>
        static member DatePicker(date: DateTimeOffset, fn: DateTimeOffset -> unit) =
            WidgetBuilder<unit, IFabComponentDatePicker>(
                DatePicker.WidgetKey,
                ComponentDatePicker.SelectedDateChanged.WithValue(ComponentValueEventData.create date fn)
            )
