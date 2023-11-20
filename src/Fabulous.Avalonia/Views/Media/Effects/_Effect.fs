namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabEffect =
    inherit IFabAnimatable

module Effect =
    let Invalidated =
        Attributes.defineEventNoArg "Effect_Invalidated" (fun target -> (target :?> Effect).Invalidated)

[<Extension>]
type EffectModifiers =
    /// <summary>Listens the Effect Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Effect is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabEffect>, msg: 'msg) =
        this.AddScalar(Effect.Invalidated.WithValue(MsgValue msg))

[<Extension>]
type AttachedEffectModifiers =
    /// <summary>Sets the Effect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Effect value.</param>
    [<Extension>]
    static member inline effect(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabEffect>) =
        this.AddWidget(Visual.EffectWidget.WithValue(value.Compile()))

    /// <summary>Sets the Effect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Effect value.</param>
    [<Extension>]
    static member inline effect(this: WidgetBuilder<'msg, #IFabVisual>, value: string) =
        this.AddScalar(Visual.Effect.WithValue(Effect.Parse(value)))
