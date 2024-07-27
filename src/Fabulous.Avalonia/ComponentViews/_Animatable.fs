namespace Fabulous.Avalonia.Components

open Avalonia.Animation
open Fabulous.Avalonia

type IFabComponentAnimatable =
    inherit IFabComponentElement
    inherit IFabElement

module AnimatableComponent =
    let Transitions =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Animatable_Transitions" (fun target ->
            let target = (target :?> Animatable)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)
