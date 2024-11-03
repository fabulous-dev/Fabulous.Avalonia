namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

module ComponentColorView =
    let ColorChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorView_ColorChanged" ColorView.ColorProperty

[<AutoOpen>]
module ComponentColorViewBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorView(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabColorView>(ColorView.WidgetKey, ComponentColorView.ColorChanged.WithValue(ComponentValueEventData.create color fn))
