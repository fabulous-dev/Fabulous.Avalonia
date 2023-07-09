namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous

type IFabFlyoutBase =
    inherit IFabElement

module FlyoutBase =
    let AttachedFlyout =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.AttachedFlyoutProperty

    let Target = Attributes.defineAvaloniaPropertyWithEquality FlyoutBase.TargetProperty

    let Opened =
        Attributes.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        Attributes.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

[<Extension>]
type FlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabFlyoutBase>, fn: 'msg) =
        this.AddScalar(FlyoutBase.Opened.WithValue(fun _ -> fn |> box))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabFlyoutBase>, fn: 'msg) =
        this.AddScalar(FlyoutBase.Closed.WithValue(fun _ -> fn |> box))

    /// <summary>Sets the Target property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Target value</param>
    [<Extension>]
    static member inline target(this: WidgetBuilder<'msg, #IFabFlyoutBase>, value: ViewRef<#Control>) =
        match value.TryValue with
        | None -> this
        | Some value -> this.AddScalar(FlyoutBase.Target.WithValue(value))
