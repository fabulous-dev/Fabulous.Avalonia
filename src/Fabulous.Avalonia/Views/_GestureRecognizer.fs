namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGestureRecognizer =
    inherit IFabStyledElement

module GestureRecognizer =
    let IsHoldingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Gestures.IsHoldingEnabledProperty

    let IsHoldWithMouseEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Gestures.IsHoldWithMouseEnabledProperty

    let RightTapped =
        Attributes.defineRoutedEvent<TappedEventArgs> "GestureRecognizer_RightTapped" Gestures.RightTappedEvent

    let ScrollGesture =
        Attributes.defineRoutedEvent<ScrollGestureEventArgs> "GestureRecognizer_ScrollGesture" Gestures.ScrollGestureEvent

    let ScrollGestureInertiaStarting =
        Attributes.defineRoutedEvent<ScrollGestureInertiaStartingEventArgs>
            "GestureRecognizer_ScrollGestureInertiaStarting"
            Gestures.ScrollGestureInertiaStartingEvent

    let ScrollGestureEnded =
        Attributes.defineRoutedEvent<ScrollGestureEndedEventArgs> "GestureRecognizer_ScrollGestureEnded" Gestures.ScrollGestureEndedEvent

    let PointerTouchPadGestureMagnify =
        Attributes.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerMagnifyGesture" Gestures.PointerTouchPadGestureMagnifyEvent

    let PointerTouchPadGestureRotate =
        Attributes.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerRotateGesture" Gestures.PointerTouchPadGestureRotateEvent

    let PointerTouchPadGestureSwipe =
        Attributes.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerSwipeGesture" Gestures.PointerTouchPadGestureSwipeEvent

    let Pinch =
        Attributes.defineRoutedEvent<PinchEventArgs> "GestureRecognizer_Pinch" Gestures.PinchEvent

    let PinchEnded =
        Attributes.defineRoutedEvent<PinchEndedEventArgs> "GestureRecognizer_PinchEnded" Gestures.PinchEndedEvent

    let PullGesture =
        Attributes.defineRoutedEvent<PullGestureEventArgs> "GestureRecognizer_PullGesture" Gestures.PullGestureEvent

    let PullGestureEnded =
        Attributes.defineRoutedEvent<PullGestureEndedEventArgs> "GestureRecognizer_PullGestureEnded" Gestures.PullGestureEndedEvent

[<Extension>]
type GestureRecognizerModifiers =
    [<Extension>]
    static member inline isHoldingEnabled(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(GestureRecognizer.IsHoldingEnabled.WithValue(value))

    [<Extension>]
    static member inline isHoldWithMouseEnabled(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(GestureRecognizer.IsHoldWithMouseEnabled.WithValue(value))

    [<Extension>]
    static member inline onRightTapped(this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onRightTapped: TappedEventArgs -> 'msg) =
        this.AddScalar(GestureRecognizer.RightTapped.WithValue(fun args -> onRightTapped args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureMagnify
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureMagnify: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(GestureRecognizer.PointerTouchPadGestureMagnify.WithValue(fun args -> onPointerTouchPadGestureMagnify args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureRotate
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureRotate: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(GestureRecognizer.PointerTouchPadGestureRotate.WithValue(fun args -> onPointerTouchPadGestureRotate args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureSwipe
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureSwipe: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(GestureRecognizer.PointerTouchPadGestureSwipe.WithValue(fun args -> onPointerTouchPadGestureSwipe args |> box))

[<Extension>]
type GestureRecognizerBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGestureRecognizer>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGestureRecognizer>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
