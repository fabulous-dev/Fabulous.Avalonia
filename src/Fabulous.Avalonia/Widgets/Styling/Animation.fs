namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabAnimation =
    inherit IFabElement

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

[<AutoOpen>]
module AnimationBuilders =

    type Fabulous.Avalonia.View with

        static member Animation<'msg>(duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children, Animation.Duration.WithValue(duration))

        static member Animation<'msg>() =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children)

[<Extension>]
type AnimationModifiers =
    [<Extension>]
    static member inline iterationCount(this: WidgetBuilder<'msg, #IFabAnimation>, value: IterationCount) =
        this.AddScalar(Animation.IterationCount.WithValue(value))

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
