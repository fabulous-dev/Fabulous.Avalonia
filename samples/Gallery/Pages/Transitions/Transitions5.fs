namespace Gallery.Pages

open System
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Layout

open type Fabulous.Avalonia.View



module Transitions5 =
    type Model = { Height: float; Width: float }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

    let init () = { Height = 100.; Width = 100. }

    let update msg model =
        match msg with
        | OnPointerEnter _ -> { model with Width = 50. }
        | OnPointerExited _ -> { model with Width = 100. }
        | OnPointerEnter2 _ -> { model with Height = 50. }
        | OnPointerExited2 _ -> { model with Height = 100. }

    let view model =
        HStack(16.) {
            Border()
                .background(SolidColorBrush(Colors.Orange))
                .onPointerEntered(OnPointerEnter)
                .onPointerExited(OnPointerExited)
                .width(model.Width)
                .height(100.)
                .transition(DoubleTransition(Layoutable.WidthProperty, TimeSpan.FromSeconds(0.5)))


            Border()
                .background(SolidColorBrush(Colors.Orange))
                .onPointerEntered(OnPointerEnter2)
                .onPointerExited(OnPointerExited2)
                .height(model.Height)
                .width(100.)
                .transition(DoubleTransition(Layoutable.HeightProperty, TimeSpan.FromSeconds(0.5)))
        }
