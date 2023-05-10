namespace Gallery.Pages

open System
open Avalonia
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls
open Gallery

open type Fabulous.Avalonia.View


module Transitions10 =
    type Model =
        { Background2: Color
          Background3: Color }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

    let init () =
        { Background2 = Colors.Transparent
          Background3 = Colors.Transparent }

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { model with
                Background2 = Colors.Red
                Background3 = Colors.Blue }

        | OnPointerExited _ ->
            { model with
                Background2 = Colors.Transparent
                Background3 = Colors.Transparent }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(Path(Paths.Path1).fill(SolidColorBrush(Colors.White)).stretch(Stretch.Uniform))
            .margin(15.)
            .size(100., 100.)

    let view model =
        Border()
            .style(borderTestStyle)
            .background(
                ImmutableLinearGradientBrush(
                    [ ImmutableGradientStop(0., model.Background2)
                      ImmutableGradientStop(1., model.Background3) ],
                    startPoint = RelativePoint.Parse("0%, 0%"),
                    endPoint = RelativePoint.Parse("100%, 100%")
                )
            )
            .onPointerEnter(OnPointerEnter)
            .onPointerExited(OnPointerExited)
            .transition(BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(0.5)))
