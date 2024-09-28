namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentNativeMenuItemSeparator =
    inherit IFabComponentNativeMenuItem
    inherit IFabNativeMenuItemSeparator

module NativeMenuItemSeparator =
    let WidgetKey = Widgets.register<NativeMenuItemSeparator>()

[<AutoOpen>]
module NativeMenuItemSeparatorBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenuItemSeparator widget.</summary>
        static member NativeMenuItemSeparator() =
            WidgetBuilder<'msg, IFabNativeMenuItemSeparator>(NativeMenuItemSeparator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type NativeMenuItemSeparatorModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuItemSeparator control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuItemSeparator>, value: ViewRef<NativeMenuItemSeparator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
