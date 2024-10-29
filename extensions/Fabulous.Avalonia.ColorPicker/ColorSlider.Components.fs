namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentColorSlider =
    inherit IFabComponentSlider
    inherit IFabColorSlider

module ComponentColorSlider =
    let ColorChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorSlider_ColorChanged" ColorSlider.ColorProperty

[<AutoOpen>]
module ComponentColorSliderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ColorSlider widget.</summary>
        static member ColorSlider() =
            WidgetBuilder<unit, IFabComponentColorSlider>(ColorSlider.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSlider(color: Color) =
            WidgetBuilder<unit, IFabComponentColorSlider>(
                ColorSlider.WidgetKey,
                AttributesBundle(StackList.one(ColorSlider.Color.WithValue(color)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSlider(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabComponentColorSlider>(
                ColorSlider.WidgetKey,
                ComponentColorSlider.ColorChanged.WithValue(ComponentValueEventData.create color fn)
            )
