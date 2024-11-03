namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuContextMenu =
    let Opening =
        MvuAttributes.defineCancelEvent "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        MvuAttributes.defineCancelEvent "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

[<AutoOpen>]
module MvuContextMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ContextMenu widget.</summary>
        /// <param name="placement">The placement mode of the ContextMenu.</param>
        static member ContextMenu(placement: PlacementMode) =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(ContextMenu.WidgetKey, MvuItemsControl.Items, ContextMenu.Placement.WithValue(placement))

        /// <summary>Creates a ContextMenu widget.</summary>
        static member ContextMenu() =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(
                ContextMenu.WidgetKey,
                MvuItemsControl.Items,
                ContextMenu.Placement.WithValue(PlacementMode.Bottom)
            )

type MvuContextMenuModifiers =
    /// <summary>Listens to the ContextMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(MvuContextMenu.Opening.WithValue(fn))

    /// <summary>Listens to the ContextMenu Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Closing event fires.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(MvuContextMenu.Closing.WithValue(fn))
