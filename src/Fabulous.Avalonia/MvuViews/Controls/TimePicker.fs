namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuTimePicker =
    inherit IFabMvuTemplatedControl
    inherit IFabTimePicker

module MvuTimePicker =
    let SelectedTimeChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent "TimePicker_SelectedTimeChanged" TimePicker.SelectedTimeProperty Nullable Nullable.op_Explicit

[<AutoOpen>]
module MvuTimePickerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TimePicker widget.</summary>
        /// <param name="time">The initial time.</param>
        /// <param name="fn">Raised when the selected time changes.</param>
        static member TimePicker(time: TimeSpan, fn: TimeSpan -> unit) =
            WidgetBuilder<unit, IFabMvuTimePicker>(TimePicker.WidgetKey, MvuTimePicker.SelectedTimeChanged.WithValue(MvuValueEventData.create time fn))

type MvuTimePickerModifiers =
    /// <summary>Link a ViewRef to access the direct TimePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuTimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
