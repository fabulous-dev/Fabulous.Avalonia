namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous

type IFabUnderline =
    inherit IFabSpan

module Underline =
    let WidgetKey = Widgets.register<Underline> ()

[<AutoOpen>]
module UnderlineBuilders =
    type Fabulous.Avalonia.View with

        static member private Underline<'msg>() =
            CollectionBuilder<'msg, IFabUnderline, IFabInline>(Underline.WidgetKey, Span.Inlines)

        static member Underline<'msg>(text: string) =
            Fabulous.Avalonia.View.Underline<'msg>() { View.Run<'msg>(text) }
