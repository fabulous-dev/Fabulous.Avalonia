namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabMenuFlyout =
    inherit IFabPopupFlyoutBase

module MenuFlyout =
    let WidgetKey = Widgets.register<MenuFlyout>()

    let Items =
        Attributes.defineListWidgetCollection "MenuFlyout_Items" (fun target -> (target :?> MenuFlyout).Items :?> IList<_>)

[<AutoOpen>]
module MenuFlyoutBuilders =
    type Fabulous.Avalonia.View with

        static member inline MenuFlyout() =
            CollectionBuilder<'msg, IFabMenuFlyout, IFabMenuItem>(MenuFlyout.WidgetKey, MenuFlyout.Items)

[<Extension>]
type MenuFlyoutModifiers =
    /// <summary>Link a ViewRef to access the direct MenuFlyout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMenuFlyout>, value: ViewRef<MenuFlyout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type MenuFlyoutCollectionBuilderExtensions =
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
