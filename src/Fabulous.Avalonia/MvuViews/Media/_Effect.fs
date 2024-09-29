namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuEffect =
    inherit IFabMvuAnimatable
    inherit IFabEffect

module MvuEffect =
    let Invalidated =
        MvuAttributes.defineEventNoArg "Effect_Invalidated" (fun target -> (target :?> Effect).Invalidated)

type MvuEffectModifiers =
    /// <summary>Listens the Effect Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Effect is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabMvuEffect>, msg: 'smg) =
        this.AddScalar(MvuEffect.Invalidated.WithValue(MsgValue msg))
