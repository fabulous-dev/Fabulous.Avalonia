namespace Fabulous.Avalonia

open Avalonia.Animation

type IFabAnimatable =
    inherit IFabElement

module Animatable =

    let Clock = Attributes.defineAvaloniaPropertyWidget Animatable.ClockProperty

    let Transitions =
        Attributes.defineAvaloniaPropertyWithEquality Animatable.TransitionsProperty
