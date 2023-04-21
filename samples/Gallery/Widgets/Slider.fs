namespace Gallery


open System
open Avalonia.Controls
open Avalonia.Layout
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module Slider =
    type Model =
        { SliderValue1: float
          SliderValue2: float
          SliderValue3: float
          SliderValue4: float
          SliderValue5: float
          SliderValue6: float
          SliderValue7: float }

    type Msg =
        | ValueChanged1 of float
        | ValueChanged2 of float
        | ValueChanged3 of float
        | ValueChanged4 of float
        | ValueChanged5 of float
        | ValueChanged6 of float
        | ValueChanged7 of float

    let init () =
        { SliderValue1 = 0.0
          SliderValue2 = 0.0
          SliderValue3 = 0.0
          SliderValue4 = 0.0
          SliderValue5 = 0.0
          SliderValue6 = 0.0
          SliderValue7 = 0.0 }

    let update msg model =
        match msg with
        | ValueChanged1 value -> { model with SliderValue1 = value }
        | ValueChanged2 value -> { model with SliderValue2 = value }
        | ValueChanged3 value -> { model with SliderValue3 = value }
        | ValueChanged4 value -> { model with SliderValue4 = value }
        | ValueChanged5 value -> { model with SliderValue5 = value }
        | ValueChanged6 value -> { model with SliderValue6 = value }
        | ValueChanged7 value -> { model with SliderValue7 = value }

    let sliderStyle (this: WidgetBuilder<'msg, IFabSlider>) =
        this.tickFrequency(10.).width(300.).largeChange(0.2).smallChange(0.1)

    let view model =
        VStack(spacing = 15.) {
            Slider(model.SliderValue1, ValueChanged1)

            Slider(0., 100., model.SliderValue2, ValueChanged2)
                .tickPlacement(TickPlacement.BottomRight)
                .isSnapToTickEnabled(true)
                .ticks([ 0.; 20.; 25.; 40.; 75.; 100. ])
                .style(sliderStyle)

            Slider(0., 100., model.SliderValue3, ValueChanged3)
                .tickPlacement(TickPlacement.BottomRight)
                .isSnapToTickEnabled(true)
                .ticks([ 0.; 20.; 25.; 40.; 75.; 100. ])
                .tooltip(TextBlock(model.SliderValue3.ToString()))
                .tooltipPlacement(PlacementMode.Top)
                .style(sliderStyle)

            Slider(0., 100., model.SliderValue4, ValueChanged4)
                .dataValidationErrors([ Exception() ])
                .style(sliderStyle)

            Slider(0., 100., model.SliderValue5, ValueChanged5)
                .isDirectionReversed(true)
                .style(sliderStyle)

            Slider(0., 100., model.SliderValue6, ValueChanged6)
                .height(300.)
                .orientation(Orientation.Vertical)
                .tickPlacement(TickPlacement.Outside)
                .isSnapToTickEnabled(true)
                .style(sliderStyle)

            Slider(0., 100., model.SliderValue7, ValueChanged7)
                .height(300.)
                .orientation(Orientation.Vertical)
                .tickPlacement(TickPlacement.Outside)
                .isSnapToTickEnabled(true)
                .isDirectionReversed(true)
                .style(sliderStyle)
        }

    let sample =
        { Name = "Slider"
          Description = "Control for selecting a value from a range"
          Program = Helper.createProgram init update view }
