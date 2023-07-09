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
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabEffect>, onInvalidated: 'msg) =
        this.AddScalar(Effect.Invalidated.WithValue(onInvalidated))

[<Extension>]
type AttachedEffectModifiers =
    [<Extension>]
    static member inline effect(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabEffect>) =
        this.AddWidget(Visual.Effect.WithValue(widget.Compile()))
