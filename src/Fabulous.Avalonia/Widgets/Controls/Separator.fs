namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabSeparator = inherit IFabTemplatedControl

module Separator =
    let WidgetKey = Widgets.register<Separator>()

[<AutoOpen>]
module SeparatorBuilders =
    type Fabulous.Avalonia.View with
        static member Separator() =
            WidgetBuilder<'msg, IFabSeparator>(
                Separator.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueNone,
                    ValueNone
                )
            )
