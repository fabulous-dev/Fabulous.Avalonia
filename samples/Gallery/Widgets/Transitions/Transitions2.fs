namespace Gallery

open System
open Avalonia
open Avalonia.Animation
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Transformation
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions2 =

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

        | OnPointerEnter1 of PointerEventArgs
        | OnPointerExited1 of PointerEventArgs

    type Model = { ScaleX: float; ScaleY: float }

    let init () = { ScaleX = 1.; ScaleY = 1. }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with ScaleX = 2.0 }
        | OnPointerExited _ -> { model with ScaleX = 1. }
        | OnPointerEnter1 _ -> { model with ScaleY = 2.0 }
        | OnPointerExited1 _ -> { model with ScaleY = 1. }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let borderTestStyle1 (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path2).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        (UniformGrid() {
            Border()
                .style(borderTestStyle)
                .background(SolidColorBrush(Colors.Magenta))
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .renderTransform(ScaleTransform(model.ScaleX).transitions() { DoubleTransition(ScaleTransform.ScaleXProperty, TimeSpan.FromSeconds(0.5)) })

            Border()
                .style(borderTestStyle)
                .background(SolidColorBrush(Colors.Magenta))
                .onPointerEnter(OnPointerEnter1)
                .onPointerExited(OnPointerExited1)
                .renderTransform(ScaleTransform(1., model.ScaleY).transitions() { DoubleTransition(ScaleTransform.ScaleYProperty, TimeSpan.FromSeconds(0.5)) })
        })
            .clipToBounds(false)
            .clock(Clock())

    let sample =
        { Name = "Transition 2"
          Description = "Transitions sample"
          Program = Helper.createProgram init update view }
