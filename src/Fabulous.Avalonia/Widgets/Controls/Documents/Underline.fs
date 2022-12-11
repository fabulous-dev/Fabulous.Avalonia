namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabUnderline =
    inherit IFabSpan

module Underline =
    let WidgetKey = Widgets.register<Underline> ()

[<AutoOpen>]
module UnderlineBuilders =
    type Fabulous.Avalonia.View with

        static member Underline<'msg>() =
            WidgetBuilder<'msg, IFabUnderline>(
                Underline.WidgetKey,
                AttributesBundle(StackList.empty (), ValueNone, ValueNone)
            )
