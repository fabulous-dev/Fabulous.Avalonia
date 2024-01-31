namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabColorPicker =
    inherit IFabColorView

module ColorPicker =
    let WidgetKey = Widgets.register<ColorPicker>()

[<AutoOpen>]
module ColorPickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorPicker widget.</summary>
        static member ColorPicker() =
            WidgetBuilder<'msg, IFabColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorPicker<'msg>(color: Color) =
            WidgetBuilder<'msg, IFabColorPicker>(ColorPicker.WidgetKey, AttributesBundle(StackList.one(ColorView.Color.WithValue(color)), ValueNone, ValueNone))

        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPicker(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabColorPicker>(ColorPicker.WidgetKey, ColorView.ColorChanged.WithValue(ValueEventData.create color fn))

[<Extension>]
type ColorPickerModifiers =
    /// <summary>Link a ViewRef to access the direct ColorPicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorPicker>, value: ViewRef<ColorPicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
