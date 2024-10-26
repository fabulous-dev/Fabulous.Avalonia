namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuAnimation =
    inherit IFabMvuElement
    inherit IFabAnimation

module MvuAnimation =
    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "Animation_KeyFramesProperty" (fun target -> (target :?> Animation).Children)

[<AutoOpen>]
module MvuAnimationBuilders =

    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates an Animation widget with the specified duration and keyframes.</summary>
        /// <param name="duration">The main Window of the Application.</param>
        static member Animation(duration: TimeSpan) =
            CollectionBuilder<unit, IFabMvuAnimation, IFabKeyFrame>(
                Animation.WidgetKey,
                MvuAnimation.Children,
                Animation.Duration.WithValue(duration)
            )

        /// <summary>Creates an Animation widget with keyframes.</summary>
        static member Animation() =
            CollectionBuilder<unit, IFabMvuAnimation, IFabKeyFrame>(Animation.WidgetKey, MvuAnimation.Children)

type MvuAnimationCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuKeyFrame>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuKeyFrame>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuKeyFrame>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuKeyFrame>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMvuAnimation>
        (_: CollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuAnimatable and 'itemType :> IFabMvuAnimation>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'marker :> IFabMvuAnimatable and 'itemType :> IFabMvuAnimation>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabMvuAnimation>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

[<AutoOpen>]
module MvuAnimationAttachedBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary> Creates a Animation widget with the specified duration and keyframes.</summary>
        /// <param name="keyFrame">The keyframe to add to the animation.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member inline Animation(keyFrame: WidgetBuilder<'msg, IFabKeyFrame>, duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, MvuAnimation.Children, Animation.Duration.WithValue(duration)) {
                keyFrame
            }
