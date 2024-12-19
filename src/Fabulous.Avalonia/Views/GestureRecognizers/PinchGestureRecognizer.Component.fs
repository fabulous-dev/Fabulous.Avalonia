namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

[<AutoOpen>]
module ComponentPinchGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PinchGestureRecognizer(gesture: PinchEventArgs -> unit) =
            WidgetBuilder<'msg, IFabPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                ComponentGestureRecognizer.Pinch.WithValue(fun args -> gesture args)
            )

type ComponentPinchGestureRecognizerModifiers =
    [<Extension>]
    static member inline onPinchEnded(this: WidgetBuilder<'msg, #IFabPinchGestureRecognizer>, onPinchEnded: PinchEndedEventArgs -> unit) =
        this.AddScalar(ComponentGestureRecognizer.PinchEnded.WithValue(onPinchEnded))
