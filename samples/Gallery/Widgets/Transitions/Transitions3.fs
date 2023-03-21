namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Transitions3 =
    type Model =
        { TranslateX: float; TranslateY: float }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

    let init () = { TranslateX = 0.; TranslateY = 0. }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with TranslateX = 100. }

        | OnPointerExited _ -> { model with TranslateX = 0. }

        | OnPointerEnter2 _ -> { model with TranslateY = 100. }

        | OnPointerExited2 _ -> { model with TranslateY = 0 }

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
                .background(SolidColorBrush(Colors.Navy))
                .style(borderTestStyle)
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .renderTransform(
                    TranslateTransform(model.TranslateX, 0.).transitions() { DoubleTransition(TranslateTransform.XProperty, TimeSpan.FromSeconds(0.5)) }
                )

            Border()
                .background(SolidColorBrush(Colors.Navy))
                .style(borderTestStyle)
                .onPointerEnter(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .renderTransform(
                    TranslateTransform(0., model.TranslateY).transitions() { DoubleTransition(TranslateTransform.YProperty, TimeSpan.FromSeconds(0.5)) }
                )
        })
            .clipToBounds(false)
            .clock(Clock())

    let sample =
        { Name = "Transitions 3"
          Description = "Transitions sample"
          Program = Helper.createProgram init update view }
