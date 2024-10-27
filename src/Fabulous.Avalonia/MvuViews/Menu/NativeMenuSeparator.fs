namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuNativeMenuItemSeparator =
    inherit IFabMvuNativeMenuItem
    inherit IFabNativeMenuItemSeparator

[<AutoOpen>]
module MvuNativeMenuItemSeparatorBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NativeMenuItemSeparator widget.</summary>
        static member NativeMenuItemSeparator() =
            WidgetBuilder<'msg, IFabMvuNativeMenuItemSeparator>(NativeMenuItemSeparator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
