namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

module ComponentSpan =
    let Inlines =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module ComponentSpanBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<'msg, IFabSpan, IFabInline>(Span.WidgetKey, ComponentSpan.Inlines)
