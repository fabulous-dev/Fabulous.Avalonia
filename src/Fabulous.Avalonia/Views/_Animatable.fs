namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Animators
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabAnimatable =
    inherit IFabElement

module AnimatableUpdaters =
    let transitionApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> Animatable
        let childViewNode = node.TreeContext.GetViewNode(target.Transitions)
        childViewNode.ApplyDiff(&diff)

    let transitionUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> Animatable

        match currOpt with
        | ValueNone -> target.Transitions.Add(Unchecked.defaultof<_>)
        | ValueSome widget ->
            let struct (_, transition) = Helpers.createViewForWidget node widget

            let transitions =
                if target.Transitions = null then
                    let newColl = Transitions()
                    target.Transitions <- newColl
                    newColl
                else
                    target.Transitions

            match transition with
            | :? Transition<ITransform> as transition -> transitions.Add(transition)
            | :? Transition<IBrush> as transition -> transitions.Add(transition)
            | :? AnimatorDrivenTransition<double, DoubleAnimator> as transition -> transitions.Add(transition)
            | :? AnimatorDrivenTransition<BoxShadows, BoxShadowsAnimator> as transition -> transitions.Add(transition)
            | :? AnimatorDrivenTransition<CornerRadius, CornerRadiusAnimator> as transition -> transitions.Add(transition)
            | :? AnimatorDrivenTransition<Thickness, ThicknessAnimator> as transition -> transitions.Add(transition)
            | _ -> failwithf $"Unsupported transition type: %A{transition}"

module Animatable =

    let Clock = Attributes.defineAvaloniaPropertyWithEquality Animatable.ClockProperty

    let Transition =
        Attributes.defineWidget "Transitions" AnimatableUpdaters.transitionApplyDiff AnimatableUpdaters.transitionUpdateNode

    let Transitions =
        Attributes.defineAvaloniaListWidgetCollection "Animatable_Transitions" (fun target ->
            let target = (target :?> Animatable)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)

[<Extension>]
type AnimatableModifiers =
    [<Extension>]
    static member inline clock(this: WidgetBuilder<'msg, #IFabAnimatable>, clock: IClock) =
        this.AddScalar(Animatable.Clock.WithValue(clock))

    [<Extension>]
    static member inline transitions(this: WidgetBuilder<'msg, #IFabAnimatable>) =
        AttributeCollectionBuilder<'msg, #IFabAnimatable, IFabTransition>(this, Animatable.Transitions)

    [<Extension>]
    static member inline transition(this: WidgetBuilder<'msg, #IFabAnimatable>, transition: WidgetBuilder<'msg, #IFabTransition>) =
        this.AddWidget(Animatable.Transition.WithValue(transition.Compile()))


[<Extension>]
type AnimatableCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabTransition>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabTransition>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabTransition>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabTransition>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
