namespace Fabulous.Avalonia

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous

type IFabSlider = inherit IFabRangeBase

type FabSlider() =
    inherit Slider()
    
    let _valueChanged =  Event<EventHandler<RangeBaseValueChangedEventArgs>, _>()
    
    [<CLIEvent>]
    member this.ValueChanged = _valueChanged.Publish
    
    override this.OnPropertyChanged(args: AvaloniaPropertyChangedEventArgs) =
        if args.Property = RangeBase.ValueProperty then
            _valueChanged.Trigger(this, RangeBaseValueChangedEventArgs(args.OldValue :?> float, args.NewValue :?> float))

module Slider =
    let WidgetKey = Widgets.register<FabSlider>()
    let ValueChanged = Attributes.defineEvent "Slider_ValueChanged" (fun target -> (target :?> FabSlider).ValueChanged)
    
[<AutoOpen>]
module SliderBuilders =
    type Fabulous.Avalonia.View with
        static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabSlider>(
                Slider.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(min, max),
                RangeBase.Value.WithValue(value),
                Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)
            )
