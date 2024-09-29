namespace Fabulous.Avalonia.Mvu

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuPopupFlyoutBase =
    inherit IFabMvuFlyoutBase
    inherit IFabPopupFlyoutBase

module MvuPopupFlyoutBase =
    let Opening =
        MvuAttributes.defineEventNoArg "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        MvuAttributes.defineEvent "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

type MvuPopupFlyoutBaseModifiers =
    /// <summary>Listens to the PopupFlyoutBase Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is opening.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<unit, #IFabMvuPopupFlyoutBase>, fn: 'msg) =
        this.AddScalar(MvuPopupFlyoutBase.Opening.WithValue(MsgValue fn))

    /// <summary>Listens to the PopupFlyoutBase Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is closing.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<unit, #IFabMvuPopupFlyoutBase>, fn: CancelEventArgs -> unit) =
        this.AddScalar(MvuPopupFlyoutBase.Closing.WithValue(fn))
