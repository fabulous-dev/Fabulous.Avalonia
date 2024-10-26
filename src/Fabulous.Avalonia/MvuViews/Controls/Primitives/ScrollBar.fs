namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Layout
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
        static member inline ScrollBar(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabMvuScrollBar>(
                ScrollBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn)
            )

type MvuScrollBarModifiers =
    /// <summary>Listens to the ScrollBar Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Scroll value changes.</param>
    [<Extension>]
    static member inline onScroll(this: WidgetBuilder<unit, #IFabMvuScrollBar>, fn: ScrollEventArgs -> unit) =
        this.AddScalar(MvuScrollBar.Scroll.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct ScrollBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuScrollBar>, value: ViewRef<ScrollBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
