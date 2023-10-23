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

        static member ColorPicker<'msg>() =
            WidgetBuilder<'msg, IFabColorPicker>(
                ColorPicker.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueNone,
                    ValueNone)
                )

[<Extension>]
type ColorPickerModifiers =
    /// <summary>Link a ViewRef to access the direct ColorPicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorPicker>, value: ViewRef<ColorPicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
    //
    // /// <summary>Set the HorizontalCacheLength property.</summary>
    // /// <param name="this">Current widget.</param>
    // /// <param name="value">The HorizontalCacheLength value.</param>
    // [<Extension>]
    // static member inline horizontalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
    //     this.AddScalar(ColorPicker.HorizontalCacheLength.WithValue(value))
    //
    // /// <summary>Set the VerticalCacheLength property.</summary>
    // /// <param name="this">Current widget.</param>
    // /// <param name="value">The VerticalCacheLength value.</param>
    // [<Extension>]
    // static member inline verticalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
    //     this.AddScalar(ColorPicker.VerticalCacheLength.WithValue(value))
    //
    // /// <summary>Set the Layout property.</summary>
    // /// <param name="this">Current widget.</param>
    // /// <param name="value">The Layout value.</param>
    // [<Extension>]
    // static member inline layout(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: AttachedLayout) =
    //     this.AddScalar(ColorPicker.Layout.WithValue(value))
