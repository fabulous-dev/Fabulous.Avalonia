namespace Fabulous.Avalonia.Components

open Avalonia.Controls
open System.Runtime.CompilerServices

open Fabulous
open Fabulous.Avalonia

type IFabComponentProgressBar =
    inherit IFabComponentRangeBase
    inherit IFabProgressBar

[<AutoOpen>]
module ComponentProgressBarBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ProgressBar widget.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="value">Current value.</param>
        /// <param name="fn">Raised when the value changes.</param>
        static member ProgressBar(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabComponentProgressBar>(
                ProgressBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn)
            )
