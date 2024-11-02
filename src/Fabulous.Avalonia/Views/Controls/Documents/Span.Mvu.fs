namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

module MvuSpan =
    let Inlines =
        MvuAttributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module MvuSpanBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<'msg, IFabSpan, IFabInline>(Span.WidgetKey, MvuSpan.Inlines)