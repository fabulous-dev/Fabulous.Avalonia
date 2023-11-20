namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabWindowBase =
    inherit IFabTopLevel

module WindowBase =

    let Topmost =
        Attributes.defineAvaloniaPropertyWithEquality WindowBase.TopmostProperty

    let Activated =
        Attributes.defineEventNoArg "WindowBase_Activated" (fun target -> (target :?> WindowBase).Activated)

    let Deactivated =
        Attributes.defineEventNoArg "WindowBase_Deactivated" (fun target -> (target :?> WindowBase).Deactivated)

    let PositionChanged =
        Attributes.defineEvent "WindowBase_PositionChanged" (fun target -> (target :?> WindowBase).PositionChanged)

    let Resized =
        Attributes.defineEvent "WindowBase_Resized" (fun target -> (target :?> WindowBase).Resized)

[<Extension>]
type WindowBaseModifiers =
    /// <summary>Sets the Topmost property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Topmost value.</param>
    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabWindowBase>, value: bool) =
        this.AddScalar(WindowBase.Topmost.WithValue(value))

    /// <summary>Listens to the WindowBase Activated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is activated.</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindowBase>, msg: 'msg) =
        this.AddScalar(WindowBase.Activated.WithValue(MsgValue msg))

    /// <summary>Listens to the WindowBase Deactivated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is deactivated.</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindowBase>, msg: 'msg) =
        this.AddScalar(WindowBase.Deactivated.WithValue(MsgValue msg))

    /// <summary>Listens to the WindowBase PositionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window position is changed.</param>
    [<Extension>]
    static member inline onPositionChanged(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: PixelPointEventArgs -> 'msg) =
        this.AddScalar(WindowBase.PositionChanged.WithValue(fn))

    /// <summary>Listens to the WindowBase Resized event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is resized.</param>
    [<Extension>]
    static member inline onResized(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: WindowResizedEventArgs -> 'msg) =
        this.AddScalar(WindowBase.Resized.WithValue(fn))
