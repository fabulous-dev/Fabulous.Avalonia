namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

module MvuSpan =
    let Inlines =
        Attributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module MvuSpanBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<'msg, IFabSpan, IFabInline>(Span.WidgetKey, MvuSpan.Inlines)
