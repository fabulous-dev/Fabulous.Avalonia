namespace Gallery

open System
open Avalonia
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View


module Transitions7 =
    type Model =
        { Padding: Thickness
          Padding1: Thickness }

    type Msg =


        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

    let init () =
        { Padding = Thickness(0.)
          Padding1 = Thickness(0.) }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with Padding = Thickness(10.) }
        | OnPointerExited _ -> { model with Padding = Thickness(0.) }

        | OnPointerEnter2 _ ->
            { model with
                Padding1 = Thickness(20., 20.) }

        | OnPointerExited2 _ -> { model with Padding1 = Thickness(0.) }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        HStack(16.) {
            Border()
                .background(SolidColorBrush(Colors.Gray))
                .style(borderTestStyle)
                .padding(model.Padding)
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .transitions() {
                ThicknessTransition(Decorator.PaddingProperty, TimeSpan.FromSeconds(0.5))
            }

            Border()
                .background(SolidColorBrush(Colors.Gray))
                .style(borderTestStyle)
                .padding(model.Padding1)
                .onPointerEnter(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .transitions() {
                ThicknessTransition(Decorator.PaddingProperty, TimeSpan.FromSeconds(0.5))
            }
        }
