namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

[<AutoOpen>]
module MvuPullGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PullGestureRecognizer(gesture: PullGestureEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabPullGestureRecognizer>(
                PullGestureRecognizer.WidgetKey,
                MvuGestureRecognizer.PullGesture.WithValue(fun args -> gesture args |> box)
            )

type MvuPullGestureRecognizerModifiers =
    [<Extension>]
    static member inline onPullGestureEnded(this: WidgetBuilder<'msg, #IFabPullGestureRecognizer>, onPullGestureEnded: PullGestureEndedEventArgs -> 'msg) =
        this.AddScalar(MvuGestureRecognizer.PullGestureEnded.WithValue(fun args -> onPullGestureEnded args |> box))
