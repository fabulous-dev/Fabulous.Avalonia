namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Layout

open Fabulous
open Fabulous.Avalonia

type IFabComponentSlider =
    inherit IFabComponentRangeBase
    inherit IFabSlider

[<AutoOpen>]
module ComponentSliderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member Slider(value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabComponentSlider>(Slider.WidgetKey, ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn))

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="min">The minimum value of the slider.</param>
        /// <param name="max">The maximum value of the slider.</param>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member inline Slider(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<unit, IFabComponentSlider>(
                Slider.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn)
            )

type ComponentSliderModifiers =
    /// <summary>Link a ViewRef to access the direct Slider control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentSlider>, value: ViewRef<Slider>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
