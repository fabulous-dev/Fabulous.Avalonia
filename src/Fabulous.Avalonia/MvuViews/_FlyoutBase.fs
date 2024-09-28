namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuFlyoutBase =
    inherit IFabMvuElement
    inherit IFabFlyoutBase

module MvuFlyoutBase =
    let Opened =
        MvuAttributes.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        MvuAttributes.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

type FlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabMvuFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(MvuFlyoutBase.Opened.WithValue(msg))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabMvuFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(MvuFlyoutBase.Closed.WithValue(msg))
