namespace Fabulous.Avalonia.Components

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentContextMenu =
    inherit IFabComponentMenuBase
    inherit IFabContextMenu

module ComponentContextMenu =
    let Opening =
        ComponentAttributes.defineCancelEvent "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        ComponentAttributes.defineCancelEvent "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

[<AutoOpen>]
module ComponentContextMenuBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ContextMenu widget.</summary>
        /// <param name="placement">The placement mode of the ContextMenu.</param>
        static member ContextMenu(placement: PlacementMode) =
            CollectionBuilder<unit, IFabComponentContextMenu, IFabComponentControl>(
                ContextMenu.WidgetKey,
                ComponentItemsControl.Items,
                ContextMenu.Placement.WithValue(placement)
            )

        /// <summary>Creates a ContextMenu widget.</summary>
        static member ContextMenu() =
            CollectionBuilder<unit, IFabComponentContextMenu, IFabComponentControl>(
                ContextMenu.WidgetKey,
                ComponentItemsControl.Items,
                ContextMenu.Placement.WithValue(PlacementMode.Bottom)
            )

type ComponentContextMenuModifiers =
    /// <summary>Listens to the ContextMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentContextMenu.Opening.WithValue(fn))

    /// <summary>Listens to the ContextMenu Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Closing event fires.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentContextMenu.Closing.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct ContextMenu control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentContextMenu>, value: ViewRef<ContextMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type ComponentContextMenuAttachedModifiers =
    /// <summary>Sets the ContextMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContextMenu value.</param>
    [<Extension>]
    static member inline contextMenu(this: WidgetBuilder<'msg, #IFabComponentControl>, value: WidgetBuilder<'msg, IFabComponentContextMenu>) =
        this.AddWidget(Control.ContextMenu.WithValue(value.Compile()))

type ComponentContextMenuCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabControl>
        (_: CollectionBuilder<'msg, 'marker, IFabControl>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
