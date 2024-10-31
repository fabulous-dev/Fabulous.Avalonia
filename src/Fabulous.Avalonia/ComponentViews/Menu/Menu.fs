namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentMenu =
    inherit IFabComponentMenuBase
    inherit IFabMenu

[<AutoOpen>]
module ComponentMenuBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Menu widget.</summary>
        static member Menu() =
            CollectionBuilder<unit, IFabComponentMenu, IFabComponentMenuItem>(Menu.WidgetKey, ComponentItemsControl.Items)

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
