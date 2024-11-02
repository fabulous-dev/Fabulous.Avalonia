namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Avalonia

type ComponentTransitionCollectionModifiers =
    /// <summary>Sets the Transitions property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<unit, IFabAnimatable>) =
        AttributeCollectionBuilder<unit, IFabAnimatable, IFabTransition>(this, ComponentAnimatable.Transitions)

    /// <summary>Sets the Transition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transition value.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<unit, IFabAnimatable>, value: WidgetBuilder<unit, IFabTransition>) =
        ComponentTransitionCollectionModifiers.transition(this) { value }
