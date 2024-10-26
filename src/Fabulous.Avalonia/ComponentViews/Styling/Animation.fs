namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentAnimation =
    inherit IFabComponentElement
    inherit IFabAnimation

module ComponentAnimation =
    let Children =
        ComponentAttributes.defineAvaloniaListWidgetCollection "Animation_KeyFramesProperty" (fun target -> (target :?> Animation).Children)

[<AutoOpen>]
module ComponentAnimationBuilders =

    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates an Animation widget with the specified duration and keyframes.</summary>
        /// <param name="duration">The main Window of the Application.</param>
        static member Animation(duration: TimeSpan) =
            CollectionBuilder<unit, IFabComponentAnimation, IFabKeyFrame>(
                Animation.WidgetKey,
                ComponentAnimation.Children,
                Animation.Duration.WithValue(duration)
            )

        /// <summary>Creates an Animation widget with keyframes.</summary>
        static member Animation() =
            CollectionBuilder<unit, IFabComponentAnimation, IFabKeyFrame>(Animation.WidgetKey, ComponentAnimation.Children)

type ComponentAnimationCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentKeyFrame>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentKeyFrame>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentKeyFrame>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentKeyFrame>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabComponentAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabComponentAnimatable and 'itemType :> IFabComponentAnimation>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabComponentAnimatable and 'itemType :> IFabComponentAnimation>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabComponentAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

[<AutoOpen>]
module ComponentAnimationAttachedBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary> Creates a Animation widget with the specified duration and keyframes.</summary>
        /// <param name="keyFrame">The keyframe to add to the animation.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member inline Animation(keyFrame: WidgetBuilder<'msg, IFabKeyFrame>, duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, ComponentAnimation.Children, Animation.Duration.WithValue(duration)) {
                keyFrame
            }
