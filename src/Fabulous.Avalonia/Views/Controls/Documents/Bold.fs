namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous

type IFabBold =
    inherit IFabSpan

module Bold =
    let WidgetKey = Widgets.register<Bold>()

[<AutoOpen>]
module BoldBuilders =
    type Fabulous.Avalonia.View with

        static member private Bold<'msg>() =
            CollectionBuilder<'msg, IFabBold, IFabInline>(Bold.WidgetKey, Span.Inlines)

        static member Bold<'msg>(text: string) =
            Fabulous.Avalonia.View.Bold<'msg>() { View.Run<'msg>(text) }
