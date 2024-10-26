namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuNativeMenuItemSeparator =
    inherit IFabMvuNativeMenuItem
    inherit IFabNativeMenuItemSeparator

module NativeMenuItemSeparator =
    let WidgetKey = Widgets.register<NativeMenuItemSeparator>()

[<AutoOpen>]
module NativeMenuItemSeparatorBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NativeMenuItemSeparator widget.</summary>
        static member NativeMenuItemSeparator() =
            WidgetBuilder<'msg, IFabNativeMenuItemSeparator>(NativeMenuItemSeparator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
