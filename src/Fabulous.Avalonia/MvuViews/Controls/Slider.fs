namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Layout

open Fabulous
open Fabulous.Avalonia

type IFabMvuSlider =
    inherit IFabMvuRangeBase
    inherit IFabSlider

[<AutoOpen>]
module MvuSliderBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member Slider(value: float, fn: float -> 'msg) =
            WidgetBuilder<'msg, IFabMvuSlider>(Slider.WidgetKey, MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn))

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="min">The minimum value of the slider.</param>
        /// <param name="max">The maximum value of the slider.</param>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member inline Slider(min: float, max: float, value: float, fn: float -> 'msg) =
            WidgetBuilder<'msg, IFabMvuSlider>(
                Slider.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                MvuRangeBase.ValueChanged.WithValue(MvuValueEventData.create value fn)
            )
