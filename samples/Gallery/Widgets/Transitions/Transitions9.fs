namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions9 =
    type Model = { Background: IBrush }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

    let init () = { Background = Brushes.Red }

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { model with
                Background = Brushes.Green }
        | OnPointerExited _ -> { model with Background = Brushes.Red }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        (UniformGrid() {
            Border()
                .style(borderTestStyle)
                .background(model.Background)
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .transitions() {
                BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(0.5))
            }
        })
            .clock(Clock())

    let sample =
        { Name = "Transitions 9"
          Description = "Transitions sample"
          Program = Helper.createProgram init update view }
