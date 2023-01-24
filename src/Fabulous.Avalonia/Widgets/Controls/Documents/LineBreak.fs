namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabLineBreak =
    inherit IFabInline

module LineBreak =
    let WidgetKey = Widgets.register<LineBreak>()

[<AutoOpen>]
module LineBreakBuilders =
    type Fabulous.Avalonia.View with

        static member LineBreak() =
            WidgetBuilder<'msg, IFabLineBreak>(LineBreak.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
