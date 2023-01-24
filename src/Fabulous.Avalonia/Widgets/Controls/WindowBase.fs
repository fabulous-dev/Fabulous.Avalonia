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
    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabWindowBase>, value: bool) =
        this.AddScalar(WindowBase.Topmost.WithValue(value))

    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindowBase>, onActivated: 'msg) =
        this.AddScalar(WindowBase.Activated.WithValue(onActivated))

    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindowBase>, onDeactivated: 'msg) =
        this.AddScalar(WindowBase.Deactivated.WithValue(onDeactivated))

    [<Extension>]
    static member inline onPositionChanged(this: WidgetBuilder<'msg, #IFabWindowBase>, onPositionChanged: PixelPointEventArgs -> 'msg) =
        this.AddScalar(WindowBase.PositionChanged.WithValue(fun args -> onPositionChanged args |> box))
