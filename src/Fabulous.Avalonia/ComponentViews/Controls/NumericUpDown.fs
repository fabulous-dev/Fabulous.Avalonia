namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices
open Fabulous.Avalonia

type IFabComponentNumericUpDown =
    inherit IFabComponentTemplatedControl
    inherit IFabNumericUpDown

module ComponentNumericUpDown =
    let ValueChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent "NumericUpDown_ValueChanged" NumericUpDown.ValueProperty Option.toNullable Option.ofNullable

[<AutoOpen>]
module ComponentNumericUpDownBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NumericUpDown widget.</summary>
        /// <param name="value">The value of the NumericUpDown.</param>
        /// <param name="fn">Raised when the NumericUpDown value changes.</param>
        static member NumericUpDown(value: float option, fn: float option -> unit) =
            WidgetBuilder<unit, IFabComponentNumericUpDown>(
                NumericUpDown.WidgetKey,
                ComponentNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    ComponentValueEventData.create value (Option.map float >> fn)
                )
            )

        /// <summary>Creates a NumericUpDown widget.</summary>
        /// <param name="min">The minimum value of the NumericUpDown.</param>
        /// <param name="max">The maximum value of the NumericUpDown.</param>
        /// <param name="value">The value of the NumericUpDown.</param>
        /// <param name="fn">Raised when the NumericUpDown value changes.</param>
        static member NumericUpDown(min: float, max: float, value: float option, fn: float option -> unit) =
            WidgetBuilder<unit, IFabNumericUpDown>(
                NumericUpDown.WidgetKey,
                NumericUpDown.MinimumMaximum.WithValue(struct (decimal min, decimal max)),
                ComponentNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    ComponentValueEventData.create value (Option.map float >> fn)
                )
            )

type ComponentNumericUpDownModifiers =
    /// <summary>Link a ViewRef to access the direct NumericUpDown control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentNumericUpDown>, value: ViewRef<NumericUpDown>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
