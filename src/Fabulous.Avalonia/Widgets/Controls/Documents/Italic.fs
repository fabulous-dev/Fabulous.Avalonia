namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous

type IFabItalic =
    inherit IFabSpan

module Italic =
    let WidgetKey = Widgets.register<Italic> ()

[<AutoOpen>]
module ItalicBuilders =
    type Fabulous.Avalonia.View with

        static member private Italic<'msg>() =
            CollectionBuilder<'msg, IFabItalic, IFabInline>(Italic.WidgetKey, Span.Inlines)

        static member Italic<'msg>(text: string) =
            Fabulous.Avalonia.View.Italic<'msg>() { View.Run<'msg>(text) }
