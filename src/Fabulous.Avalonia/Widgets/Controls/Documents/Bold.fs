namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabBold =
    inherit IFabSpan

module Bold =
    let WidgetKey = Widgets.register<Bold> ()

[<AutoOpen>]
module BoldBuilders =
    type Fabulous.Avalonia.View with

        static member Bold<'msg>() =
            WidgetBuilder<'msg, IFabBold>(Bold.WidgetKey, AttributesBundle(StackList.empty (), ValueNone, ValueNone))
