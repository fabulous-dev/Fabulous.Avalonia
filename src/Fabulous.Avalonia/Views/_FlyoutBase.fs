namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabFlyoutBase =
    inherit IFabAvaloniaObject

module FlyoutBase =
    let AttachedFlyout =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.AttachedFlyoutProperty

    let Opened =
        Attributes.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        Attributes.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

[<Extension>]
type FlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabFlyoutBase>, msg: 'msg) =
        this.AddScalar(FlyoutBase.Opened.WithValue(MsgValue msg))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabFlyoutBase>, msg: 'msg) =
        this.AddScalar(FlyoutBase.Closed.WithValue(MsgValue msg))
