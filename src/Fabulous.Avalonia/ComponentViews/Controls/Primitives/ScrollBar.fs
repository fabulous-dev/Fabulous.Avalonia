namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentScrollBar =
    inherit IFabComponentRangeBase
    inherit IFabScrollBar

module ComponentScrollBar =
    let Scroll =
        Attributes.defineEventNoDispatch "ScrollBar_Scroll" (fun target -> (target :?> ScrollBar).Scroll)

[<AutoOpen>]
module ComponentScrollBarBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ScrollBar widget.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="value">Current value.</param>
        /// <param name="fn">Raised when the value changes.</param>
        static member inline ScrollBar(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabComponentScrollBar>(
                ScrollBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn)
            )

type ComponentScrollBarModifiers =
    /// <summary>Listens to the ScrollBar Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Scroll value changes.</param>
    [<Extension>]
    static member inline onScroll(this: WidgetBuilder<unit, #IFabComponentScrollBar>, fn: ScrollEventArgs -> unit) =
        this.AddScalar(ComponentScrollBar.Scroll.WithValue(fn))
