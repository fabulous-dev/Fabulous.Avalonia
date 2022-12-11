namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabItalic =
    inherit IFabSpan

module Italic =
    let WidgetKey = Widgets.register<Italic> ()

[<AutoOpen>]
module ItalicBuilders =
    type Fabulous.Avalonia.View with

        static member Italic<'msg>() =
            WidgetBuilder<'msg, IFabItalic>(
                Italic.WidgetKey,
                AttributesBundle(StackList.empty (), ValueNone, ValueNone)
            )
