namespace Fabulous.Avalonia

open Avalonia.Animation
open Fabulous.Avalonia

module ComponentAnimatable =
    let Transitions =
        Attributes.defineAvaloniaListWidgetCollectionNoLifecycle "Animatable_Transitions" (fun target ->
            let target = (target :?> Animatable)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)
