namespace Fabulous.Avalonia

open Avalonia.Input

type IFabPinchGestureRecognizer =
    inherit IFabGestureRecognizer

module PinchGestureRecognizer =
    let WidgetKey = Widgets.register<PinchGestureRecognizer>()
