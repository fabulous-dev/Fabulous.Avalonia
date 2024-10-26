namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentNativeMenuBar =
    inherit IFabComponentTemplatedControl
    inherit IFabNativeMenuBar

[<AutoOpen>]
module ComponentNativeMenuBarBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NativeMenuBar widget.</summary>
        static member NativeMenuBar() =
            WidgetBuilder<unit, IFabComponentNativeMenuBar>(NativeMenuBar.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentNativeMenuBarAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentNativeMenuBar>, value: ViewRef<NativeMenuBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
