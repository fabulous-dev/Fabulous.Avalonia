namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

module ComponentFlyoutBase =
    let Opened =
        Attributes.defineEventNoArgNoDispatch "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        Attributes.defineEventNoArgNoDispatch "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

type ComponentFlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(ComponentFlyoutBase.Opened.WithValue(msg))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabFlyoutBase>, msg: unit -> unit) =
        this.AddScalar(ComponentFlyoutBase.Closed.WithValue(msg))
