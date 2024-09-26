namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentTimePicker =
    inherit IFabComponentTemplatedControl
    inherit IFabTimePicker

module ComponentTimePicker =
    let SelectedTimeChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent "TimePicker_SelectedTimeChanged" TimePicker.SelectedTimeProperty Nullable Nullable.op_Explicit

[<AutoOpen>]
module ComponentTimePickerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TimePicker widget.</summary>
        /// <param name="time">The initial time.</param>
        /// <param name="fn">Raised when the selected time changes.</param>
        static member TimePicker(time: TimeSpan, fn: TimeSpan -> unit) =
            WidgetBuilder<unit, IFabComponentTimePicker>(TimePicker.WidgetKey, ComponentTimePicker.SelectedTimeChanged.WithValue(ComponentValueEventData.create time fn))

type ComponentTimePickerModifiers =
    /// <summary>Link a ViewRef to access the direct TimePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentTimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
