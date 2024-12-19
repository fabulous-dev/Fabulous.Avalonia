namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

[<AutoOpen>]
module ComponentPullGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PullGestureRecognizer(gesture: PullGestureEventArgs -> unit) =
            WidgetBuilder<'msg, IFabPullGestureRecognizer>(PullGestureRecognizer.WidgetKey, ComponentGestureRecognizer.PullGesture.WithValue(gesture))

type ComponentPullGestureRecognizerModifiers =
    [<Extension>]
    static member inline onPullGestureEnded(this: WidgetBuilder<'msg, #IFabPullGestureRecognizer>, onPullGestureEnded: PullGestureEndedEventArgs -> unit) =
        this.AddScalar(ComponentGestureRecognizer.PullGestureEnded.WithValue(onPullGestureEnded))
