namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabColorPicker =
    inherit IFabColorView

module ColorPicker =
    let WidgetKey = Widgets.register<ColorPicker>()

type ColorPickerModifiers =
    /// <summary>Link a ViewRef to access the direct ColorPicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabColorPicker>, value: ViewRef<ColorPicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
