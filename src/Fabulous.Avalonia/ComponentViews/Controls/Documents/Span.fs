namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentSpan =
    inherit IFabComponentInline
    inherit IFabSpan

module ComponentSpan =
    let Inlines =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module ComponentSpanBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<unit, IFabComponentSpan, IFabComponentInline>(Span.WidgetKey, ComponentSpan.Inlines)

type ComponentSpanCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentInline>
        (_: CollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, 'itemType>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComponentInline>
        (_: CollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }
