namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type MvuTransitionCollectionModifiers =
    /// <summary>Sets the Transitions property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, #IFabAnimatable>) =
        AttributeCollectionBuilder<'msg, #IFabAnimatable, #IFabTransition>(this, MvuAnimatable.Transitions)

    /// <summary>Sets the Transition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transition value.</param>
    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, #IFabAnimatable>, value: WidgetBuilder<'msg, #IFabTransition>) =
        MvuTransitionCollectionModifiers.transition(this) { value }
