namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabNativeMenuItemSeparator =
    inherit IFabNativeMenuItem

module NativeMenuItemSeparator =
    let WidgetKey = Widgets.register<NativeMenuItemSeparator>()

[<AutoOpen>]
module NativeMenuItemSeparatorBuilders =
    type Fabulous.Avalonia.View with

        static member inline NativeMenuItemSeparator() =
            WidgetBuilder<'msg, IFabNativeMenuItemSeparator>(NativeMenuItemSeparator.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
