namespace Gallery.Pages

open System
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View



module Transitions4 =
    type Model = { SkewX: float; SkewY: float }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs
        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

    let init () = { SkewX = 0.; SkewY = 0. }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with SkewX = 90. }

        | OnPointerExited _ -> { model with SkewX = 0. }

        | OnPointerEnter2 _ -> { model with SkewY = 90. }

        | OnPointerExited2 _ -> { model with SkewY = 0. }


    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        HStack(16.) {

            Border()
                .background(SolidColorBrush(Colors.SeaGreen))
                .style(borderTestStyle)
                .onPointerEnter(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .renderTransform(SkewTransform(model.SkewX, 0.).transitions() { DoubleTransition(SkewTransform.AngleXProperty, TimeSpan.FromSeconds(0.5)) })

            Border()
                .background(SolidColorBrush(Colors.SeaGreen))
                .style(borderTestStyle)
                .onPointerEnter(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .renderTransform(SkewTransform(0., model.SkewY).transitions() { DoubleTransition(SkewTransform.AngleYProperty, TimeSpan.FromSeconds(0.5)) })
        }
