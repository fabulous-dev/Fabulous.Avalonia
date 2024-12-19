namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

[<AutoOpen>]
module ComponentScrollGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollGestureRecognizer(gesture: ScrollGestureEventArgs -> unit) =
            WidgetBuilder<'msg, IFabScrollGestureRecognizer>(
                ScrollGestureRecognizer.WidgetKey,
                ComponentGestureRecognizer.ScrollGesture.WithValue(fun args -> gesture args)
            )

type ComponentScrollGestureRecognizerModifiers =
    [<Extension>]
    static member inline onScrollGestureInertiaStarting
        (
            this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>,
            onScrollGestureInertiaStarting: ScrollGestureInertiaStartingEventArgs -> unit
        ) =
        this.AddScalar(ComponentGestureRecognizer.ScrollGestureInertiaStarting.WithValue(onScrollGestureInertiaStarting) )

    [<Extension>]
    static member inline onScrollGestureEnded
        (
            this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>,
            onScrollGestureEnded: ScrollGestureEndedEventArgs -> unit
        ) =
        this.AddScalar(ComponentGestureRecognizer.ScrollGestureEnded.WithValue(onScrollGestureEnded) )
