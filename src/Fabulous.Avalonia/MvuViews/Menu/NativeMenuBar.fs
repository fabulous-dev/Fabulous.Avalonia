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
            WidgetBuilder<'msg, IFabMvuNativeMenuBar>(NativeMenuBar.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
