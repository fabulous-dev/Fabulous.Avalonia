namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyle =
    inherit IFabElement

module Style =

    let WidgetKey = Widgets.register<Style>()

type StyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, #IFabStyle>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabStyle>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
