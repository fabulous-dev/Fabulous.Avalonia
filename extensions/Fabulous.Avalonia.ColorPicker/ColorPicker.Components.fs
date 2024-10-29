namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentColorPicker =
    inherit IFabComponentColorView

[<AutoOpen>]
module ComponentColorPickerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ColorPicker widget.</summary>
        static member ColorPicker() =
            WidgetBuilder<unit, IFabColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorPicker(color: Color) =
            WidgetBuilder<unit, IFabColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.one(ColorView.Color.WithValue(color)), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPicker(color: Color, fn: Color -> unit) =
            WidgetBuilder<unit, IFabMvuColorPicker>(ColorPicker.WidgetKey, ComponentColorView.ColorChanged.WithValue(ComponentValueEventData.create color fn))
