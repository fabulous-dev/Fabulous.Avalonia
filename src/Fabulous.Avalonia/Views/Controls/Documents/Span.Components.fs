namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

module ComponentSpan =
    let Inlines =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module ComponentSpanBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<unit, IFabSpan, IFabInline>(Span.WidgetKey, ComponentSpan.Inlines)
