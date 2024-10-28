namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuColorPicker =
    inherit IFabMvuColorView

[<AutoOpen>]
module MvuColorPickerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorPicker widget.</summary>
        static member ColorPicker() =
            WidgetBuilder<'msg, IFabMvuColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorPicker(color: Color) =
            WidgetBuilder<'msg, IFabMvuColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.one(ColorView.Color.WithValue(color)), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPicker(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabMvuColorPicker>(ColorPicker.WidgetKey, MvuColorView.ColorChanged.WithValue(MvuValueEventData.create color fn))