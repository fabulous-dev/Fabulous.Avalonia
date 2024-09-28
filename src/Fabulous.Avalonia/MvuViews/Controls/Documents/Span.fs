namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuSpan =
    inherit IFabMvuInline
    inherit IFabSpan

module MvuSpan =
    let Inlines =
        MvuAttributes.defineAvaloniaListWidgetCollection "Span_Inlines" (fun target -> (target :?> Span).Inlines)

[<AutoOpen>]
module MvuSpanBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Span widget.</summary>
        static member Span() =
            CollectionBuilder<'msg, IFabMvuSpan, IFabMvuInline>(Span.WidgetKey, MvuSpan.Inlines)

type MvuSpanMvuModifiers =
    /// <summary>Link a ViewRef to access the direct Span control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuSpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MvuSpanCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuInline>, x: WidgetBuilder<unit, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMvuInline>
        (_: CollectionBuilder<unit, 'marker, IFabMvuInline>, x: WidgetBuilder<unit, Memo.Memoized<'itemType>>)
        : Content<unit> =
        { Widgets = MutStackArray1.One(x.Compile()) }
