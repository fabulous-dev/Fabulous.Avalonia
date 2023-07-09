namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous

type IFabRangeBase =
    inherit IFabTemplatedControl

module RangeBaseUpdaters =
    let updateSliderMinMax _ (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let slider = node.Target :?> RangeBase

        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(RangeBase.MinimumProperty)
            slider.ClearValue(RangeBase.MaximumProperty)
        | ValueSome(min, max) ->
            let currMax = slider.GetValue(RangeBase.MaximumProperty)

            if min > currMax then
                slider.SetValue(RangeBase.MaximumProperty, max) |> ignore
                slider.SetValue(RangeBase.MinimumProperty, min) |> ignore
            else
                slider.SetValue(RangeBase.MinimumProperty, min) |> ignore
                slider.SetValue(RangeBase.MaximumProperty, max) |> ignore

module RangeBase =
    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "RangeBase_MinimumMaximum" RangeBaseUpdaters.updateSliderMinMax

    let Minimum =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.MinimumProperty

    let Maximum =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.MaximumProperty

    let SmallChange =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.SmallChangeProperty

    let LargeChange =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.LargeChangeProperty

    let ValueChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "RangeBase_ValueChanged" RangeBase.ValueProperty

[<Extension>]
type RangeBaserModifiers =
    [<Extension>]
    static member inline smallChange(this: WidgetBuilder<'msg, #IFabRangeBase>, value: float) =
        this.AddScalar(RangeBase.SmallChange.WithValue(value))

    [<Extension>]
    static member inline largeChange(this: WidgetBuilder<'msg, #IFabRangeBase>, value: float) =
        this.AddScalar(RangeBase.LargeChange.WithValue(value))

    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<'msg, #IFabRangeBase>, onDragStarted: VectorEventArgs -> 'msg) =
        this.AddScalar(Thumb.DragStarted.WithValue(fun args -> onDragStarted args |> box))

    [<Extension>]
    static member inline onDragDelta(this: WidgetBuilder<'msg, #IFabRangeBase>, onDragDelta: VectorEventArgs -> 'msg) =
        this.AddScalar(Thumb.DragDelta.WithValue(fun args -> onDragDelta args |> box))

    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<'msg, #IFabRangeBase>, onDragCompleted: VectorEventArgs -> 'msg) =
        this.AddScalar(Thumb.DragCompleted.WithValue(fun args -> onDragCompleted args |> box))
