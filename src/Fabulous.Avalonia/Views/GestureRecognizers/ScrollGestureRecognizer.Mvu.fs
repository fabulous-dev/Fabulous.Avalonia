namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.GestureRecognizers
open Fabulous

[<AutoOpen>]
module MvuScrollGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollGestureRecognizer(gesture: ScrollGestureEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabScrollGestureRecognizer>(
                ScrollGestureRecognizer.WidgetKey,
                MvuGestureRecognizer.ScrollGesture.WithValue(fun args -> gesture args |> box)
            )

type MvuScrollGestureRecognizerModifiers =
    [<Extension>]
    static member inline onScrollGestureInertiaStarting
        (this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>, onScrollGestureInertiaStarting: ScrollGestureInertiaStartingEventArgs -> 'msg)
        =
        this.AddScalar(MvuGestureRecognizer.ScrollGestureInertiaStarting.WithValue(fun args -> onScrollGestureInertiaStarting args |> box))

    [<Extension>]
    static member inline onScrollGestureEnded
        (this: WidgetBuilder<'msg, #IFabScrollGestureRecognizer>, onScrollGestureEnded: ScrollGestureEndedEventArgs -> 'msg)
        =
        this.AddScalar(MvuGestureRecognizer.ScrollGestureEnded.WithValue(fun args -> onScrollGestureEnded args |> box))
