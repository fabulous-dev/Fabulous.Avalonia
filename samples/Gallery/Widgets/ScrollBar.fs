namespace Gallery

open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ScrollBar =
    type Model = { ScrollValue: float }

    type Msg =
        | ValueChanged of float
        | ScrollBarChanged of ScrollEventArgs

    let init () = { ScrollValue = 0.0 }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with ScrollValue = value }
        | ScrollBarChanged _ -> model

    let view model =
        VStack(spacing = 15.) {

            TextBlock($"Value: {model.ScrollValue}")

            ScrollBar(1., 240., model.ScrollValue, ValueChanged)
                .orientation(Orientation.Horizontal)
                .allowAutoHide(false)
                .background(SolidColorBrush(Colors.LightSalmon))
                .margin(10., 10., 0., 0.)
                .onScroll(ScrollBarChanged)
        }

    let sample =
        { Name = "ScrollBar"
          Description = "A ScrollBar control is a control that allows the user to select a value from a range of values by moving a slider along a track."
          Program = Helper.createProgram init update view }
