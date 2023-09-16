namespace RenderDemo

open System
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
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
            .child(
                Path(Paths.Path1)
                    .fill(SolidColorBrush(Colors.White))
                    .stretch(Stretch.Uniform)
            )
            .margin(15.)
            .size(100., 100.)

    let view model =
        HStack(16.) {
            Border()
                .style(borderTestStyle)
                .background(SolidColorBrush(Colors.Magenta))
                .onPointerEntered(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .renderTransform(
                    ScaleTransform(model.ScaleX)
                        .transition(DoubleTransition(ScaleTransform.ScaleXProperty, TimeSpan.FromSeconds(0.5)))
                )

            Border()
                .style(borderTestStyle)
                .background(SolidColorBrush(Colors.Magenta))
                .onPointerEntered(OnPointerEnter1)
                .onPointerExited(OnPointerExited1)
                .renderTransform(
                    ScaleTransform(1., model.ScaleY)
                        .transition(DoubleTransition(ScaleTransform.ScaleYProperty, TimeSpan.FromSeconds(0.5)))
                )
        }
