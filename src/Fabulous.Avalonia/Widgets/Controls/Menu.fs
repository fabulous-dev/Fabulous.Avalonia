namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabMenu =
    inherit IFabMenuBase

module Menu =
    let WidgetKey = Widgets.register<Menu> ()

[<AutoOpen>]
module MenuBuilders =
    type Fabulous.Avalonia.View with

        static member inline Menu() =
            CollectionBuilder<'msg, IFabMenu, IFabMenuItem>(Menu.WidgetKey, ItemsControl.Items)

[<Extension>]
type MenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
