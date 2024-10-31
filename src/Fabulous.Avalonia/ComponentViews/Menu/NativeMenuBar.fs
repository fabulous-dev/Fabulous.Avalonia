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
