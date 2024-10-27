namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuMenu =
    inherit IFabMvuMenuBase
    inherit IFabMenu

[<AutoOpen>]
module MvuMenuBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Menu widget.</summary>
        static member Menu() =
            CollectionBuilder<'msg, IFabMvuMenu, IFabMvuMenuItem>(Menu.WidgetKey, MvuItemsControl.Items)

type MenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
