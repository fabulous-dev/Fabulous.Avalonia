namespace Fabulous.Avalonia.Mvu

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuContextMenu =
    inherit IFabMvuMenuBase
    inherit IFabContextMenu

module MvuContextMenu =
    let Opening =
        MvuAttributes.defineCancelEvent "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        MvuAttributes.defineCancelEvent "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

[<AutoOpen>]
module MvuContextMenuBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ContextMenu widget.</summary>
        /// <param name="placement">The placement mode of the ContextMenu.</param>
        static member ContextMenu(placement: PlacementMode) =
            CollectionBuilder<unit, IFabMvuContextMenu, IFabMvuControl>(
                ContextMenu.WidgetKey,
                MvuItemsControl.Items,
                ContextMenu.Placement.WithValue(placement)
            )

        /// <summary>Creates a ContextMenu widget.</summary>
        static member ContextMenu() =
            CollectionBuilder<unit, IFabMvuContextMenu, IFabMvuControl>(
                ContextMenu.WidgetKey,
                MvuItemsControl.Items,
                ContextMenu.Placement.WithValue(PlacementMode.Bottom)
            )

type MvuContextMenuModifiers =
    /// <summary>Listens to the ContextMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(MvuContextMenu.Opening.WithValue(fn))

    /// <summary>Listens to the ContextMenu Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Closing event fires.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(MvuContextMenu.Closing.WithValue(fn))

type MvuContextMenuAttachedModifiers =
    /// <summary>Sets the ContextMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContextMenu value.</param>
    [<Extension>]
    static member inline contextMenu(this: WidgetBuilder<'msg, #IFabMvuControl>, value: WidgetBuilder<'msg, IFabMvuContextMenu>) =
        this.AddWidget(Control.ContextMenu.WithValue(value.Compile()))

type MvuContextMenuCollectionBuilderExtensions =
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
