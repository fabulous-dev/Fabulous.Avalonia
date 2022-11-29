namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Fabulous

type IFabAnimatable =
    inherit IFabElement

module Animatable =

    let Clock = Attributes.defineAvaloniaPropertyWithEquality Animatable.ClockProperty

    let Transitions =
        Attributes.defineSimpleScalarWithEquality<ITransition list> "Animatable_Transitions" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Animatable.TransitionsProperty)
            | ValueSome points ->
                let coll = Transitions()
                points |> List.iter coll.Add
                target.SetValue(Animatable.TransitionsProperty, coll) |> ignore)


[<Extension>]
type AnimatableModifiers =
    [<Extension>]
    static member inline clock(this: WidgetBuilder<'msg, #IFabAnimatable>, clock: IClock) =
        this.AddScalar(Animatable.Clock.WithValue(clock))

    [<Extension>]
    static member inline transitions(this: WidgetBuilder<'msg, #IFabAnimatable>, transitions: ITransition list) =
        this.AddScalar(Animatable.Transitions.WithValue(transitions))
