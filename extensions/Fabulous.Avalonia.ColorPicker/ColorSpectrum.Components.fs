namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentColorSpectrum =
    inherit IFabComponentTemplatedControl
    inherit IFabColorSpectrum

module ComponentColorSpectrum =
    let ColorChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorSpectrum_ColorChanged" ColorSpectrum.ColorProperty

[<AutoOpen>]
module ComponentColorSpectrumBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ColorSpectrum widget.</summary>
        static member ColorSpectrum() =
            WidgetBuilder<unit, IFabComponentColorSpectrum>(ColorSpectrum.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSpectrum(color: Color) =
            WidgetBuilder<unit, IFabComponentColorSpectrum>(
                ColorSpectrum.WidgetKey,
                AttributesBundle(StackList.one(ColorSpectrum.Color.WithValue(color)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSpectrum(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabComponentColorSpectrum>(
                ColorSpectrum.WidgetKey,
                ComponentColorSpectrum.ColorChanged.WithValue(ComponentValueEventData.create color fn)
            )
