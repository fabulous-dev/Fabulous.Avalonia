namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections

module ComponentGestureRecognizer =
    let RightTapped =
        Attributes.Component.defineRoutedEvent<TappedEventArgs> "GestureRecognizer_RightTapped" Gestures.RightTappedEvent

    let ScrollGesture =
        Attributes.Component.defineRoutedEvent<ScrollGestureEventArgs> "GestureRecognizer_ScrollGesture" Gestures.ScrollGestureEvent

    let ScrollGestureInertiaStarting =
        Attributes.Component.defineRoutedEvent<ScrollGestureInertiaStartingEventArgs>
            "GestureRecognizer_ScrollGestureInertiaStarting"
            Gestures.ScrollGestureInertiaStartingEvent

    let ScrollGestureEnded =
        Attributes.Component.defineRoutedEvent<ScrollGestureEndedEventArgs> "GestureRecognizer_ScrollGestureEnded" Gestures.ScrollGestureEndedEvent

    let PointerTouchPadGestureMagnify =
        Attributes.Component.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerMagnifyGesture" Gestures.PointerTouchPadGestureMagnifyEvent

    let PointerTouchPadGestureRotate =
        Attributes.Component.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerRotateGesture" Gestures.PointerTouchPadGestureRotateEvent

    let PointerTouchPadGestureSwipe =
        Attributes.Component.defineRoutedEvent<PointerDeltaEventArgs> "GestureRecognizer_PointerSwipeGesture" Gestures.PointerTouchPadGestureSwipeEvent

    let Pinch =
        Attributes.Component.defineRoutedEvent<PinchEventArgs> "GestureRecognizer_Pinch" Gestures.PinchEvent

    let PinchEnded =
        Attributes.Component.defineRoutedEvent<PinchEndedEventArgs> "GestureRecognizer_PinchEnded" Gestures.PinchEndedEvent

    let PullGesture =
        Attributes.Component.defineRoutedEvent<PullGestureEventArgs> "GestureRecognizer_PullGesture" Gestures.PullGestureEvent

    let PullGestureEnded =
        Attributes.Component.defineRoutedEvent<PullGestureEndedEventArgs> "GestureRecognizer_PullGestureEnded" Gestures.PullGestureEndedEvent

type ComponentGestureRecognizerModifiers =
    [<Extension>]
    static member inline onRightTapped(this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onRightTapped: TappedEventArgs -> unit) =
        this.AddScalar(ComponentGestureRecognizer.RightTapped.WithValue(onRightTapped))

    [<Extension>]
    static member inline onPointerTouchPadGestureMagnify
        (this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onPointerTouchPadGestureMagnify: PointerDeltaEventArgs -> unit)
        =
        this.AddScalar(ComponentGestureRecognizer.PointerTouchPadGestureMagnify.WithValue(onPointerTouchPadGestureMagnify))

    [<Extension>]
    static member inline onPointerTouchPadGestureRotate
        (this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onPointerTouchPadGestureRotate: PointerDeltaEventArgs -> unit)
        =
        this.AddScalar(ComponentGestureRecognizer.PointerTouchPadGestureRotate.WithValue(onPointerTouchPadGestureRotate))

    [<Extension>]
    static member inline onPointerTouchPadGestureSwipe
        (this: WidgetBuilder<'msg, #IFabGestureRecognizer>, onPointerTouchPadGestureSwipe: PointerDeltaEventArgs -> unit)
        =
        this.AddScalar(ComponentGestureRecognizer.PointerTouchPadGestureSwipe.WithValue(onPointerTouchPadGestureSwipe))
