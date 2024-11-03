namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

module MvuColorSlider =
    let ColorChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorSlider_ColorChanged" ColorSlider.ColorProperty

[<AutoOpen>]
module MvuColorSliderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorSlider widget.</summary>
        static member ColorSlider() =
            WidgetBuilder<'msg, IFabColorSlider>(ColorSlider.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSlider(color: Color) =
            WidgetBuilder<'msg, IFabColorSlider>(
                ColorSlider.WidgetKey,
                AttributesBundle(StackList.one(ColorSlider.Color.WithValue(color)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSlider(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabColorSlider>(ColorSlider.WidgetKey, MvuColorSlider.ColorChanged.WithValue(MvuValueEventData.create color fn))
