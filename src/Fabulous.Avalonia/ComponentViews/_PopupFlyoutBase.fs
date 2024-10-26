namespace Fabulous.Avalonia.Components

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentPopupFlyoutBase =
    inherit IFabComponentFlyoutBase
    inherit IFabPopupFlyoutBase

module ComponentPopupFlyoutBase =
    let Opening =
        Attributes.defineEventNoArgNoDispatch "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        Attributes.defineEventNoDispatch "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

type ComponentPopupFlyoutBaseModifiers =
    /// <summary>Listens to the PopupFlyoutBase Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is opening.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<unit, #IFabComponentPopupFlyoutBase>, fn: unit -> unit) =
        this.AddScalar(ComponentPopupFlyoutBase.Opening.WithValue(fn))

    /// <summary>Listens to the PopupFlyoutBase Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is closing.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<unit, #IFabComponentPopupFlyoutBase>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentPopupFlyoutBase.Closing.WithValue(fn))
