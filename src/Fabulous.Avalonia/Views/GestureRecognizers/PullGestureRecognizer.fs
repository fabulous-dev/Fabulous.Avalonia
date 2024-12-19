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

type PullGestureRecognizerModifiers =
    [<Extension>]
    static member inline pullDirection(this: WidgetBuilder<'msg, IFabPullGestureRecognizer>, value: PullDirection) =
        this.AddScalar(PullGestureRecognizer.PullDirection.WithValue(value))
