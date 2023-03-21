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

module Transitions =
    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

        | OnPointerEnter1 of PointerEventArgs
        | OnPointerExited1 of PointerEventArgs

        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs


    type Model =
        { Angle: float
          Angle1: float
          Scale: float
          Turn: int }

    let init () =
        { Angle = 0.
          Angle1 = 0.
          Scale = 1.
          Turn = 0 }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with Angle = 120.; Scale = 2.5 }
        | OnPointerExited _ -> { model with Angle = 0.; Scale = 1. }

        | OnPointerEnter1 _ -> { model with Angle1 = 120. }

        | OnPointerExited1 _ -> { model with Angle1 = 0. }

        | OnPointerEnter2 _ -> { model with Turn = 1 }

        | OnPointerExited2 _ -> { model with Turn = 0 }

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
                .background(SolidColorBrush(Colors.DarkRed))
                .renderTransform(TransformOperations.Parse($"rotate({model.Angle}deg) scale({model.Scale})"))
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .transitions() {
                TransformOperationsTransition(Border.RenderTransformProperty, TimeSpan.FromSeconds(0.5))
            }

            Border()
                .style(borderTestStyle)
                .background(SolidColorBrush(Colors.DarkRed))
                .renderTransform(RotateTransform(model.Angle1).transitions() { DoubleTransition(RotateTransform.AngleProperty, TimeSpan.FromSeconds(0.5)) })
                .onPointerEnter(OnPointerEnter1)
                .onPointerExited(OnPointerExited1)

            Border()
                .style(borderTestStyle1)
                .background(SolidColorBrush(Colors.Brown))
                .onPointerEnter(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .renderTransform(TransformOperations.Parse($"rotate({model.Turn}turn)"))
                .transitions() {
                TransformOperationsTransition(Border.RenderTransformProperty, TimeSpan.FromSeconds(0.5))
            }

        })
            .clipToBounds(false)
            .centerVertical()
            .centerHorizontal()
            .clock(Clock())

    let sample =
        { Name = "Transitions"
          Description = "Transitions sample"
          Program = Helper.createProgram init update view }
