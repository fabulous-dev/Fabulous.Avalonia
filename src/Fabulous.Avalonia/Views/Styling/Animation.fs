namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous
open Fabulous.StackAllocatedCollections

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

        /// <summary>Creates a new Animation widget.
        /// <param name="duration">The duration of the animation.</param>
        /// <example>
        /// <code lang="fsharp">
        /// Border()
        ///     .styles() {
        ///         Animations() {
        ///             Animation(TimeSpan.FromSeconds(1.0)) {
        ///                 ...
        ///             }
        ///        }
        ///     }
        /// </code>
        /// </example>
        /// </summary>
        static member Animation<'msg>(duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children, Animation.Duration.WithValue(duration))

        /// <summary>Creates a new Animation widget.
        /// <example>
        /// <code lang="fsharp">
        /// Border()
        ///     .styles() {
        ///         Animations() {
        ///             Animation() {
        ///                 ...
        ///             }
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// </summary>
        static member Animation<'msg>() =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children)

[<Extension>]
type AnimationModifiers =

    /// <summary>Sets the IterationCount property to IterationCount.Infinite.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline repeatForever(this: WidgetBuilder<'msg, #IFabAnimation>) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount.Infinite))

    /// <summary>Sets the IterationCount property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline repeatCount(this: WidgetBuilder<'msg, #IFabAnimation>, value: int) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount(uint64 value, IterationType.Many)))

    /// <summary>Sets the PlaybackDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type PlaybackDirection =
    /// | Normal = 0
    /// | Reverse = 1
    /// | Alternate = 2
    /// | AlternateReverse = 3
    /// </code>
    /// </example>
    [<Extension>]
    static member inline playbackDirection(this: WidgetBuilder<'msg, #IFabAnimation>, value: PlaybackDirection) =
        this.AddScalar(Animation.PlaybackDirection.WithValue(value))

    /// <summary>Sets the FillMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type FillMode =
    /// | None = 0
    /// | Forward = 1
    /// | Backward = 2
    /// | Both =
    /// </code>
    /// </example>
    [<Extension>]
    static member inline fillMode(this: WidgetBuilder<'msg, #IFabAnimation>, value: FillMode) =
        this.AddScalar(Animation.FillMode.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabAnimation>, value: Easing) =
        this.AddScalar(Animation.Easing.WithValue(value))

    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.Delay.WithValue(value))

    /// <summary>Sets the DelayBetweenIterations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline delayBetweenIterations(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.DelayBetweenIterations.WithValue(value))

    /// <summary>Sets the SpeedRatio property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline speedRatio(this: WidgetBuilder<'msg, #IFabAnimation>, value: float) =
        this.AddScalar(Animation.SpeedRatio.WithValue(value))

    /// <summary>Links a ViewRef to access the direct Animation control instance</summary>
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
