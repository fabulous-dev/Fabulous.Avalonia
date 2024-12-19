namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

[<AutoOpen>]
module MvuPinchGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PinchGestureRecognizer(gesture: PinchEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                MvuGestureRecognizer.Pinch.WithValue(fun args -> gesture args |> box)
            )

type MvuPinchGestureRecognizerModifiers =
    [<Extension>]
    static member inline onPinchEnded(this: WidgetBuilder<'msg, #IFabPinchGestureRecognizer>, onPinchEnded: PinchEndedEventArgs -> 'msg) =
        this.AddScalar(MvuGestureRecognizer.PinchEnded.WithValue(fun args -> onPinchEnded args |> box))
