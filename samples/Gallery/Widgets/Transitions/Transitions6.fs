namespace Gallery

open System
open Avalonia
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions6 =
    type Model =
        { CornerRadius: CornerRadius
          CornerRadius1: CornerRadius }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs
        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

    let init () =
        { CornerRadius = CornerRadius(0.)
          CornerRadius1 = CornerRadius(0.) }

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { model with
                CornerRadius = CornerRadius(20.) }
        | OnPointerExited _ ->
            { model with
                CornerRadius = CornerRadius(0.) }
        | OnPointerEnter2 _ ->
            { model with
                CornerRadius1 = CornerRadius(20., 0., 20., 0.) }
        | OnPointerExited2 _ ->
            { model with
                CornerRadius1 = CornerRadius(0) }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        HStack(16.) {
            Border()
                .background(SolidColorBrush(Colors.Gold))
                .style(borderTestStyle)
                .cornerRadius(model.CornerRadius)
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .transitions() {
                CornerRadiusTransition(Border.CornerRadiusProperty, TimeSpan.FromSeconds(1.))
            }

            Border()
                .background(SolidColorBrush(Colors.Gold))
                .style(borderTestStyle)
                .cornerRadius(model.CornerRadius1)
                .onPointerEnter(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .transitions() {
                CornerRadiusTransition(Border.CornerRadiusProperty, TimeSpan.FromSeconds(1.))
            }
        }
