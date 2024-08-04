namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia

type IFabComponentTickBar =
    inherit IFabComponentControl
    inherit IFabTickBar

[<AutoOpen>]
module ComponentTickBarBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TickBar widget.</summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        static member TickBar(min: float, max: float) =
            WidgetBuilder<unit, IFabComponentTickBar>(TickBar.WidgetKey, TickBar.Minimum.WithValue(min), TickBar.Maximum.WithValue(max))
