namespace Fabulous.Avalonia.Components

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentContextMenu =
    let Opening =
        ComponentAttributes.defineCancelEvent "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        ComponentAttributes.defineCancelEvent "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

[<AutoOpen>]
module ComponentContextMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ContextMenu widget.</summary>
        /// <param name="placement">The placement mode of the ContextMenu.</param>
        static member ContextMenu(placement: PlacementMode) =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(
                ContextMenu.WidgetKey,
                ComponentItemsControl.Items,
                ContextMenu.Placement.WithValue(placement)
            )

        /// <summary>Creates a ContextMenu widget.</summary>
        static member ContextMenu() =
            CollectionBuilder<'msg, IFabContextMenu, IFabControl>(
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
