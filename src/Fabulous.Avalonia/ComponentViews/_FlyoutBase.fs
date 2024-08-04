namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentFlyoutBase =
    inherit IFabComponentElement
    inherit IFabFlyoutBase

module ComponentFlyoutBase =
    let Opened =
        ComponentAttributes.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        ComponentAttributes.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

type FlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabComponentFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(ComponentFlyoutBase.Opened.WithValue(msg))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabComponentFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(ComponentFlyoutBase.Closed.WithValue(msg))
