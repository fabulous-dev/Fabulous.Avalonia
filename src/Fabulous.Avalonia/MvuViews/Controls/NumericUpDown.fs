namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices
open Fabulous.Avalonia

type IFabMvuNumericUpDown =
    inherit IFabMvuTemplatedControl
    inherit IFabNumericUpDown

module MvuNumericUpDown =
    let ValueChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent "NumericUpDown_ValueChanged" NumericUpDown.ValueProperty Option.toNullable Option.ofNullable

[<AutoOpen>]
module MvuNumericUpDownBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NumericUpDown widget.</summary>
        /// <param name="value">The value of the NumericUpDown.</param>
        /// <param name="fn">Raised when the NumericUpDown value changes.</param>
        static member NumericUpDown(value: float option, fn: float option -> unit) =
            WidgetBuilder<unit, IFabMvuNumericUpDown>(
                NumericUpDown.WidgetKey,
                MvuNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    MvuValueEventData.create value (Option.map float >> fn)
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
                MvuNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    MvuValueEventData.create value (Option.map float >> fn)
                )
            )
