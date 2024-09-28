namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Avalonia.Layout
open System.Runtime.CompilerServices

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
        static member ProgressBar(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabMvuProgressBar>(
                ProgressBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn)
            )

type MvuProgressBarModifiers =
    /// <summary>Link a ViewRef to access the direct ProgressBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuProgressBar>, value: ViewRef<ProgressBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
