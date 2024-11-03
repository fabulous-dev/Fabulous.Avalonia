namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

module ComponentColorSlider =
    let ColorChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorSlider_ColorChanged" ColorSlider.ColorProperty

[<AutoOpen>]
module ComponentColorSliderBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSlider(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabColorSlider>(ColorSlider.WidgetKey, ComponentColorSlider.ColorChanged.WithValue(ComponentValueEventData.create color fn))
