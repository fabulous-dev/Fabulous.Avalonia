namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous

type IFabFlyoutBase =
    inherit IFabElement

module FlyoutBase =
    let Opened =
        Attributes.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        Attributes.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

[<Extension>]
type FlyoutBaseModifiers =
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabFlyoutBase>, onOpened: 'msg) =
        this.AddScalar(FlyoutBase.Opened.WithValue(fun _ -> onOpened |> box))

    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabFlyoutBase>, onClosed: 'msg) =
        this.AddScalar(FlyoutBase.Closed.WithValue(fun _ -> onClosed |> box))
