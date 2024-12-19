namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections

module MvuGestureRecognizer =
    let RightTapped =
        Attributes.Mvu.defineRoutedEvent<TappedEventArgs> "GestureRecognizer_RightTapped" Gestures.RightTappedEvent

    let ScrollGesture =
        Attributes.Mvu.defineRoutedEvent<ScrollGestureEventArgs> "GestureRecognizer_ScrollGesture" Gestures.ScrollGestureEvent

    let ScrollGestureInertiaStarting =
        Attributes.Mvu.defineRoutedEvent<ScrollGestureInertiaStartingEventArgs>
            "GestureRecognizer_ScrollGestureInertiaStarting"
            Gestures.ScrollGestureInertiaStartingEvent

    let ScrollGestureEnded =
        Attributes.Mvu.defineRoutedEvent<ScrollGestureEndedEventArgs> "GestureRecognizer_ScrollGestureEnded" Gestures.ScrollGestureEndedEvent

    let PointerTouchPadGestureMagnify =
        Attributes.Mvu.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerMagnifyGesture" Gestures.PointerTouchPadGestureMagnifyEvent

    let PointerTouchPadGestureRotate =
        Attributes.Mvu.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerRotateGesture" Gestures.PointerTouchPadGestureRotateEvent

    let PointerTouchPadGestureSwipe =
        Attributes.Mvu.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerSwipeGesture" Gestures.PointerTouchPadGestureSwipeEvent

    let Pinch =
        Attributes.Mvu.defineRoutedEvent<PinchEventArgs> "GestureRecognizer_Pinch" Gestures.PinchEvent

    let PinchEnded =
        Attributes.Mvu.defineRoutedEvent<PinchEndedEventArgs> "GestureRecognizer_PinchEnded" Gestures.PinchEndedEvent

    let PullGesture =
        Attributes.Mvu.defineRoutedEvent<PullGestureEventArgs> "GestureRecognizer_PullGesture" Gestures.PullGestureEvent

    let PullGestureEnded =
        Attributes.Mvu.defineRoutedEvent<PullGestureEndedEventArgs> "GestureRecognizer_PullGestureEnded" Gestures.PullGestureEndedEvent


type MvuGestureRecognizerModifiers =
    [<Extension>]
    static member inline onRightTapped(this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onRightTapped: TappedEventArgs -> 'msg) =
        this.AddScalar(MvuGestureRecognizer.RightTapped.WithValue(fun args -> onRightTapped args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureMagnify
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureMagnify: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(MvuGestureRecognizer.PointerTouchPadGestureMagnify.WithValue(fun args -> onPointerTouchPadGestureMagnify args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureRotate
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureRotate: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(MvuGestureRecognizer.PointerTouchPadGestureRotate.WithValue(fun args -> onPointerTouchPadGestureRotate args |> box))

    [<Extension>]
    static member inline onPointerTouchPadGestureSwipe
        (
            this: WidgetBuilder<'msg, #IFabGestureRecognizer>,
            onPointerTouchPadGestureSwipe: PointerDeltaEventArgs -> 'msg
        ) =
        this.AddScalar(MvuGestureRecognizer.PointerTouchPadGestureSwipe.WithValue(fun args -> onPointerTouchPadGestureSwipe args |> box))
