namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabNativeMenuItemSeparator =
    inherit IFabNativeMenuItem

module NativeMenuItemSeparator =
    let WidgetKey = Widgets.register<NativeMenuItemSeparator>()

type NativeMenuItemSeparatorModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuItemSeparator control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuItemSeparator>, value: ViewRef<NativeMenuItemSeparator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
