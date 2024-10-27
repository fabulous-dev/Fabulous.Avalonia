namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuScrollBar =
    inherit IFabMvuRangeBase
    inherit IFabScrollBar

module MvuScrollBar =
    let Scroll =
        Attributes.defineEvent "ScrollBar_Scroll" (fun target -> (target :?> ScrollBar).Scroll)

[<AutoOpen>]
module MvuScrollBarBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ScrollBar widget.</summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="value">Current value.</param>
        /// <param name="fn">Raised when the value changes.</param>
        static member inline ScrollBar(min: float, max: float, value: float, fn: float -> 'msg) =
            WidgetBuilder<'msg, IFabMvuScrollBar>(
                ScrollBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn)
            )

type MvuScrollBarModifiers =
    /// <summary>Listens to the ScrollBar Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Scroll value changes.</param>
    [<Extension>]
    static member inline onScroll(this: WidgetBuilder<'msg, #IFabMvuScrollBar>, fn: ScrollEventArgs -> 'msg) =
        this.AddScalar(MvuScrollBar.Scroll.WithValue(fn))
