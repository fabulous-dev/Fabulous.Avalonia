namespace Fabulous.Avalonia

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

        static member inline PullGestureRecognizer<'msg>(value: PullDirection) =
            WidgetBuilder<'msg, IFabPullGestureRecognizer>(PullGestureRecognizer.WidgetKey, PullGestureRecognizer.PullDirection.WithValue(value))
