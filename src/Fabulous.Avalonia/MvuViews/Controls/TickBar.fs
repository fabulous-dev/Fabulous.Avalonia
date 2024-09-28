namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuTickBar =
    inherit IFabMvuControl
    inherit IFabTickBar

[<AutoOpen>]
module MvuTickBarBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TickBar widget.</summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        static member TickBar(min: float, max: float) =
            WidgetBuilder<unit, IFabMvuTickBar>(TickBar.WidgetKey, TickBar.Minimum.WithValue(min), TickBar.Maximum.WithValue(max))
