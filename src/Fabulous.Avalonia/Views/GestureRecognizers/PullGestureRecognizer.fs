namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

type IFabPullGestureRecognizer =
    inherit IFabGestureRecognizer

module PullGestureRecognizer =
    let WidgetKey = Widgets.register<PullGestureRecognizer>()

    let PullDirection =
        Attributes.defineAvaloniaPropertyWithEquality PullGestureRecognizer.PullDirectionProperty

[<AutoOpen>]
module PullGestureRecognizerBuilders =
    type Fabulous.Avalonia.View with

        static member inline PullGestureRecognizer<'msg>(gesture: PullGestureEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabPullGestureRecognizer>(
                PullGestureRecognizer.WidgetKey,
                GestureRecognizer.PullGesture.WithValue(fun args -> gesture args |> box)
            )

[<Extension>]
type PullGestureRecognizerModifiers =
    [<Extension>]
    static member inline pullDirection(this: WidgetBuilder<'msg, IFabPullGestureRecognizer>, value: PullDirection) =
        this.AddScalar(PullGestureRecognizer.PullDirection.WithValue(value))

    [<Extension>]
    static member inline onPullGestureEnded(this: WidgetBuilder<'msg, #IFabPullGestureRecognizer>, onPullGestureEnded: PullGestureEndedEventArgs -> 'msg) =
        this.AddScalar(GestureRecognizer.PullGestureEnded.WithValue(fun args -> onPullGestureEnded args |> box))
