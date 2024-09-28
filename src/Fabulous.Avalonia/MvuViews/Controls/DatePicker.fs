namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuDatePicker =
    inherit IFabMvuTemplatedControl
    inherit IFabDatePicker

module MvuDatePicker =
    let SelectedDateChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent
            "DatePicker_SelectedDateChanged"
            DatePicker.SelectedDateProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module MvuDatePickerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DatePicker widget.</summary>
        /// <param name="date">The initial date.</param>
        /// <param name="fn">Raised when the selected date changes.</param>
        static member DatePicker(date: DateTimeOffset, fn: DateTimeOffset -> unit) =
            WidgetBuilder<unit, IFabMvuDatePicker>(
                DatePicker.WidgetKey,
                MvuDatePicker.SelectedDateChanged.WithValue(MvuValueEventData.create date fn)
            )

type MvuDatePickerModifiers =

    /// <summary>Link a ViewRef to access the direct DatePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuDatePicker>, value: ViewRef<DatePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
