namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuNativeMenuBar =
    inherit IFabMvuTemplatedControl
    inherit IFabNativeMenuBar

[<AutoOpen>]
module MvuNativeMenuBarBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NativeMenuBar widget.</summary>
        static member NativeMenuBar() =
            WidgetBuilder<unit, IFabMvuNativeMenuBar>(NativeMenuBar.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuNativeMenuBarAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuNativeMenuBar>, value: ViewRef<NativeMenuBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
