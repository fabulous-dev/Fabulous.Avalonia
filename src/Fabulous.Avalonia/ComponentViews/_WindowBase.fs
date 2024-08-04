namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentWindowBase =
    inherit IFabComponentTopLevel
    inherit IFabWindowBase

module ComponentWindowBase =
    let Activated =
        ComponentAttributes.defineEventNoArg "WindowBase_Activated" (fun target -> (target :?> WindowBase).Activated)

    let Deactivated =
        ComponentAttributes.defineEventNoArg "WindowBase_Deactivated" (fun target -> (target :?> WindowBase).Deactivated)

    let PositionChanged =
        ComponentAttributes.defineEvent "WindowBase_PositionChanged" (fun target -> (target :?> WindowBase).PositionChanged)

    let Resized =
        ComponentAttributes.defineEvent "WindowBase_Resized" (fun target -> (target :?> WindowBase).Resized)

type ComponentWindowBaseModifiers =
    /// <summary>Listens to the WindowBase Activated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is activated.</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<unit, #IFabComponentWindowBase>, msg: unit -> unit) =
        this.AddScalar(ComponentWindowBase.Activated.WithValue(msg))

    /// <summary>Listens to the WindowBase Deactivated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is deactivated.</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabComponentWindowBase>, msg: unit -> unit) =
        this.AddScalar(ComponentWindowBase.Deactivated.WithValue(msg))

    /// <summary>Listens to the WindowBase PositionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window position is changed.</param>
    [<Extension>]
    static member inline onPositionChanged(this: WidgetBuilder<unit, #IFabComponentWindowBase>, fn: PixelPointEventArgs -> unit) =
        this.AddScalar(ComponentWindowBase.PositionChanged.WithValue(fn))

    /// <summary>Listens to the WindowBase Resized event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is resized.</param>
    [<Extension>]
    static member inline onResized(this: WidgetBuilder<unit, #IFabComponentWindowBase>, fn: WindowResizedEventArgs -> unit) =
        this.AddScalar(ComponentWindowBase.Resized.WithValue(fn))
