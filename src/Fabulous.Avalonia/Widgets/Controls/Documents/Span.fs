namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabSpan =
    inherit IFabInline
    
module Span =
    let WidgetKey = Widgets.register<Span> ()
    
    let Inlines =
        Attributes.defineAvaloniaListWidgetCollection
            "Span_Inlines"
            (fun target -> (target :?> Span).Inlines)
    
[<AutoOpen>]
module SpanBuilders =
    type Fabulous.Avalonia.View with
        static member Span<'msg>() =
            CollectionBuilder<'msg, IFabSpan, IFabInline>(
                Span.WidgetKey,
                Span.Inlines
            )

[<Extension>]
type SpanCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabInline>
        (
            _: CollectionBuilder<'msg, 'marker, IFabInline>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabInline>
        (
            _: CollectionBuilder<'msg, 'marker, IFabInline>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
