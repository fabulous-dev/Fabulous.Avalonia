namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuColorSpectrum =
    inherit IFabMvuTemplatedControl
    inherit IFabColorSpectrum

module MvuColorSpectrum =
    let ColorChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorSpectrum_ColorChanged" ColorSpectrum.ColorProperty

[<AutoOpen>]
module MvuColorSpectrumBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorSpectrum widget.</summary>
        static member ColorSpectrum() =
            WidgetBuilder<'msg, IFabMvuColorSpectrum>(ColorSpectrum.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSpectrum(color: Color) =
            WidgetBuilder<'msg, IFabMvuColorSpectrum>(
                ColorSpectrum.WidgetKey,
                AttributesBundle(StackList.one(ColorSpectrum.Color.WithValue(color)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSpectrum(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabMvuColorSpectrum>(ColorSpectrum.WidgetKey, MvuColorSpectrum.ColorChanged.WithValue(MvuValueEventData.create color fn))
