namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.GestureRecognizers
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabPinchGestureRecognizer =
    inherit IFabGestureRecognizer

module PinchGestureRecognizer =
    let WidgetKey = Widgets.register<PinchGestureRecognizer>()

[<AutoOpen>]
module PinchGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PinchGestureRecognizer<'msg>(gesture: PinchEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                GestureRecognizer.Pinch.WithValue(fun args -> gesture args |> box)
            )

[<Extension>]
type PinchGestureRecognizerModifiers =
    [<Extension>]
    static member inline onPinchEnded(this: WidgetBuilder<'msg, #IFabPinchGestureRecognizer>, onPinchEnded: PinchEndedEventArgs -> 'msg) =
        this.AddScalar(GestureRecognizer.PinchEnded.WithValue(fun args -> onPinchEnded args |> box))
