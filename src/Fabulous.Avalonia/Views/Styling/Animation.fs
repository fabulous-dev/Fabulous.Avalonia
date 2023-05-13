namespace Fabulous.Avalonia

open System
open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

module AnimationUpdaters =
    let keyFrameApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> Animation
        let childViewNode = node.TreeContext.GetViewNode(target.Children)
        childViewNode.ApplyDiff(&diff)

    let keyFrameUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> Animation

        match currOpt with
        | ValueNone -> target.Children.Add(Unchecked.defaultof<_>)
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.Children.Add(view :?> KeyFrame)

module Animation =

    let WidgetKey = Widgets.register<Animation>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality Animation.DurationProperty

    let IterationCount =
        Attributes.defineAvaloniaPropertyWithEquality Animation.IterationCountProperty

    let PlaybackDirection =
        Attributes.defineAvaloniaPropertyWithEquality Animation.PlaybackDirectionProperty

    let FillMode =
        Attributes.defineAvaloniaPropertyWithEquality Animation.FillModeProperty

    let Easing = Attributes.defineAvaloniaPropertyWithEquality Animation.EasingProperty

    let Delay = Attributes.defineAvaloniaPropertyWithEquality Animation.DelayProperty

    let DelayBetweenIterations =
        Attributes.defineAvaloniaPropertyWithEquality Animation.DelayBetweenIterationsProperty

    let SpeedRatio =
        Attributes.defineAvaloniaPropertyWithEquality Animation.SpeedRatioProperty

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Animation_KeyFramesProperty" (fun target -> (target :?> Animation).Children)

    let KeyFrame =
        Attributes.defineWidget "KeyFrame" AnimationUpdaters.keyFrameApplyDiff AnimationUpdaters.keyFrameUpdateNode

[<AutoOpen>]
module AnimationBuilders =

    type Fabulous.Avalonia.View with

        static member Animation<'msg>(duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children, Animation.Duration.WithValue(duration))

        static member Animation<'msg>() =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children)

        static member Animation<'msg>(keyFrame: WidgetBuilder<'msg, IFabKeyFrame>, duration: TimeSpan) =
            WidgetBuilder<'msg, IFabAnimation>(
                Animation.WidgetKey,
                AttributesBundle(
                    StackList.one(Animation.Duration.WithValue(duration)),
                    ValueSome [| Animation.KeyFrame.WithValue(keyFrame.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type AnimationModifiers =
    [<Extension>]
    static member inline repeatForever(this: WidgetBuilder<'msg, #IFabAnimation>) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount.Infinite))

    [<Extension>]
    static member inline repeatCount(this: WidgetBuilder<'msg, #IFabAnimation>, value: int) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount(uint64 value, IterationType.Many)))

    [<Extension>]
    static member inline playbackDirection(this: WidgetBuilder<'msg, #IFabAnimation>, value: PlaybackDirection) =
        this.AddScalar(Animation.PlaybackDirection.WithValue(value))

    [<Extension>]
    static member inline fillMode(this: WidgetBuilder<'msg, #IFabAnimation>, value: FillMode) =
        this.AddScalar(Animation.FillMode.WithValue(value))

    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabAnimation>, value: Easing) =
        this.AddScalar(Animation.Easing.WithValue(value))

    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.Delay.WithValue(value))

    [<Extension>]
    static member inline delayBetweenIterations(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.DelayBetweenIterations.WithValue(value))

    [<Extension>]
    static member inline speedRatio(this: WidgetBuilder<'msg, #IFabAnimation>, value: float) =
        this.AddScalar(Animation.SpeedRatio.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Animation control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAnimation>, value: ViewRef<Animation>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type AnimationCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabKeyFrame>
        (
            _: CollectionBuilder<'msg, 'marker, IFabKeyFrame>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabKeyFrame>
        (
            _: CollectionBuilder<'msg, 'marker, IFabKeyFrame>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
