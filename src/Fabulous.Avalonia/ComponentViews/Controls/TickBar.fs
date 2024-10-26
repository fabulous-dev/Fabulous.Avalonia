namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
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

type ComponentTickBarExtraModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<unit, #IFabTickBar>, value: Color) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<unit, #IFabTickBar>, value: string) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))
