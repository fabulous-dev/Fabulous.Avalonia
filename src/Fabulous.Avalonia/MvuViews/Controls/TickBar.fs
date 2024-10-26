namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
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
            WidgetBuilder<'msg, IFabMvuTickBar>(TickBar.WidgetKey, TickBar.Minimum.WithValue(min), TickBar.Maximum.WithValue(max))

type MvuTickBarExtraModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: Color) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: string) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))
