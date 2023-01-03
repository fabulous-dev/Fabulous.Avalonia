namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Collections
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabContextMenu =
    inherit IFabMenuBase

module ContextMenu =
    let WidgetKey = Widgets.register<ContextMenu> ()

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.VerticalOffsetProperty

    let PlacementAnchor =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementAnchorProperty

    let PlacementGravity =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementGravityProperty

    let PlacementMode =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementModeProperty

    let PlacementRect =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.PlacementRectProperty

    let WindowManagerAddShadowHint =
        Attributes.defineAvaloniaPropertyWithEquality ContextMenu.WindowManagerAddShadowHintProperty

[<AutoOpen>]
module ContextMenuBuilders =
    type Fabulous.Avalonia.View with

        static member inline ContextMenu() =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(ContextMenu.WidgetKey, ItemsControl.Items)


[<Extension>]
type ContextMenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

// [<Extension>]
// static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
//     (
//         _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
//         x: WidgetBuilder<'msg, 'itemType>
//     ) : Content<'msg> =
//     { Widgets = MutStackArray1.One(x.Compile()) }
//
// [<Extension>]
// static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
//     (
//         _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
//         x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
//     ) : Content<'msg> =
//     { Widgets = MutStackArray1.One(x.Compile()) }
