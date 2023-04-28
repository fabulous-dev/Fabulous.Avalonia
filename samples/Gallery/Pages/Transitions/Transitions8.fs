namespace Gallery

open System
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions8 =
    type Model =
        { BoxShadow: string
          BoxShadows: string list }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

    let init () =
        { BoxShadow = "inset 0 0 0 2 Red"
          BoxShadows = [ "-15 -15 Green" ] }

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { BoxShadow = "inset 30 30 20 30 Green"
              BoxShadows = [ "20 40 20 10 Red" ] }

        | OnPointerExited _ ->
            { model with
                BoxShadow = "inset 0 0 0 2 Red"
                BoxShadows = [ "-15 -15 Green" ] }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        Border()
            .style(borderTestStyle)
            .boxShadow(model.BoxShadow, model.BoxShadows)
            .cornerRadius(10.)
            .onPointerEnter(OnPointerEnter)
            .onPointerExited(OnPointerExited)
            .transitions() {
            BoxShadowsTransition(Border.BoxShadowProperty, TimeSpan.FromSeconds(0.5))
        }
