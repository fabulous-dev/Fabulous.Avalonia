namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.GestureRecognizers
open Fabulous

type IFabScrollGestureRecognizer =
    inherit IFabGestureRecognizer

module ScrollGestureRecognizer =
    let WidgetKey = Widgets.register<ScrollGestureRecognizer>()

    let CanHorizontallyScroll =
        Attributes.defineAvaloniaPropertyWithEquality ScrollGestureRecognizer.CanHorizontallyScrollProperty

    let CanVerticallyScroll =
        Attributes.defineAvaloniaPropertyWithEquality ScrollGestureRecognizer.CanVerticallyScrollProperty

    let IsScrollInertiaEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ScrollGestureRecognizer.IsScrollInertiaEnabledProperty

    let ScrollStartDistance =
        Attributes.defineAvaloniaPropertyWithEquality ScrollGestureRecognizer.ScrollStartDistanceProperty

[<AutoOpen>]
module ScrollGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollGestureRecognizer<'msg>(gesture: ScrollGestureEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabScrollGestureRecognizer>(
                ScrollGestureRecognizer.WidgetKey,
                GestureRecognizer.ScrollGesture.WithValue(fun args -> gesture args |> box)
            )

[<Extension>]
type ScrollGestureRecognizerModifiers =
    [<Extension>]
    static member inline canHorizontallyScroll(this: WidgetBuilder<'msg, IFabScrollGestureRecognizer>, value: bool) =
        this.AddScalar(ScrollGestureRecognizer.CanHorizontallyScroll.WithValue(value))

    [<Extension>]
    static member inline canVerticallyScroll(this: WidgetBuilder<'msg, IFabScrollGestureRecognizer>, value: bool) =
        this.AddScalar(ScrollGestureRecognizer.CanVerticallyScroll.WithValue(value))

    [<Extension>]
    static member inline isScrollInertiaEnabled(this: WidgetBuilder<'msg, IFabScrollGestureRecognizer>, value: bool) =
        this.AddScalar(ScrollGestureRecognizer.IsScrollInertiaEnabled.WithValue(value))

    [<Extension>]
    static member inline scrollStartDistance(this: WidgetBuilder<'msg, IFabScrollGestureRecognizer>, value: int) =
        this.AddScalar(ScrollGestureRecognizer.ScrollStartDistance.WithValue(value))

    [<Extension>]
    static member inline onScrollGestureInertiaStarting
        (
            this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>,
            onScrollGestureInertiaStarting: ScrollGestureInertiaStartingEventArgs -> 'msg
        ) =
        this.AddScalar(GestureRecognizer.ScrollGestureInertiaStarting.WithValue(fun args -> onScrollGestureInertiaStarting args |> box))

    [<Extension>]
    static member inline onScrollGestureEnded
        (
            this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>,
            onScrollGestureEnded: ScrollGestureEndedEventArgs -> 'msg
        ) =
        this.AddScalar(GestureRecognizer.ScrollGestureEnded.WithValue(fun args -> onScrollGestureEnded args |> box))
