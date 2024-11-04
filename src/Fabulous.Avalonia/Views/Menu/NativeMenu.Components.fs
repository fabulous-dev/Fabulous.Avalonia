namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentNativeMenu =
    let Items =
        Attributes.defineAvaloniaListWidgetCollectionNoDispatch "NativeMenu_Items" (fun target -> (target :?> NativeMenu).Items)

    let Opening =
        Attributes.defineEventNoDispatch "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Opening)

    let Closed =
        Attributes.defineEventNoDispatch "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Closed)

    let NeedsUpdate =
        Attributes.defineEventNoDispatch "NativeMenu_NeedsUpdate" (fun target -> (target :?> NativeMenu).NeedsUpdate)


[<AutoOpen>]
module ComponentNativeMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenu widget</summary>
        static member NativeMenu() =
            CollectionBuilder<'msg, IFabNativeMenu, IFabNativeMenuItem>(NativeMenu.WidgetKey, ComponentNativeMenu.Items)

type ComponentNativeMenuModifiers =
    /// <summary>Listens to the NativeMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.Opening.WithValue(msg))

    /// <summary>Listens to the NativeMenu Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Closed event fires.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.Closed.WithValue(msg))

    /// <summary>Listens to the NativeMenu NeedsUpdate event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the NeedsUpdate event fires.</param>
    [<Extension>]
    static member inline onNeedsUpdate(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.NeedsUpdate.WithValue(msg))
