namespace Fabulous.Avalonia.Mvu


open Fabulous
open Fabulous.Avalonia

type IFabMvuProgressBar =
    inherit IFabMvuRangeBase
    inherit IFabProgressBar

[<AutoOpen>]
module MvuProgressBarBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ProgressBar widget.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="value">Current value.</param>
        /// <param name="fn">Raised when the value changes.</param>
        static member ProgressBar(min: float, max: float, value: float, fn: float -> 'msg) =
            WidgetBuilder<'msg, IFabMvuProgressBar>(
                ProgressBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn)
            )
