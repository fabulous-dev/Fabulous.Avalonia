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

[<Extension>]
type WindowBaseModifiers =
    // <summary>Set the Topmost property</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabWindowBase>, value: bool) =
        this.AddScalar(WindowBase.Topmost.WithValue(value))

    // <summary>Listens to the Activated event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Msg to send when the event is raised</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindowBase>, msg: 'msg) =
        this.AddScalar(WindowBase.Activated.WithValue(msg))

    /// <summary>Listens to the Deactivated event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Msg to send when the event is raised</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindowBase>, msg: 'msg) =
        this.AddScalar(WindowBase.Deactivated.WithValue(msg))

    /// <summary>Listens to the PositionChanged event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Function to call when the event is raised</param>
    [<Extension>]
    static member inline onPositionChanged(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: PixelPointEventArgs -> 'msg) =
        this.AddScalar(WindowBase.PositionChanged.WithValue(fun args -> fn args |> box))
