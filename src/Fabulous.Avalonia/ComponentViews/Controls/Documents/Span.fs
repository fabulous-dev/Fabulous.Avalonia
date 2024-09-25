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
            CollectionBuilder<'msg, IFabComponentSpan, IFabComponentInline>(Span.WidgetKey, ComponentSpan.Inlines)

type ComponentSpanComponentModifiers =
    /// <summary>Link a ViewRef to access the direct Span control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentSpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentSpanCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComponentInline>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabComponentInline>
        (_: CollectionBuilder<unit, 'marker, IFabComponentInline>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }
