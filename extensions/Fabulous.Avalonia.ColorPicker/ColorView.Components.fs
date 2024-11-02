namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentColorView =
    inherit IFabComponentTemplatedControl
    inherit IFabColorView

module ComponentColorView =
    let ColorChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorView_ColorChanged" ColorView.ColorProperty

[<AutoOpen>]
module ComponentColorViewBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ColorView widget.</summary>
        static member ColorView() =
            WidgetBuilder<'msg, IFabComponentColorView>(ColorView.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorView(color: Color) =
            WidgetBuilder<unit, IFabComponentColorView>(
                ColorView.WidgetKey,
                AttributesBundle(StackList.one(ColorView.Color.WithValue(color)), ValueNone, ValueNone)
            )

        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorView(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabComponentColorView>(ColorView.WidgetKey, ComponentColorView.ColorChanged.WithValue(ComponentValueEventData.create color fn))
