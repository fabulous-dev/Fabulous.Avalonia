namespace RenderDemo

open System
open Avalonia
open Avalonia.Input
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View


module Transitions11 =
    type Model =
        { Background4: Color
          Background5: Color }

    type Msg =
        | OnPointerEnter of PointerEventArgs
        | OnPointerExited of PointerEventArgs

    let init () =
        { Background4 = Colors.Blue
          Background5 = Colors.Red }

    let update msg model =
        match msg with
        | OnPointerEnter _ ->
            { model with
                Background4 = Colors.Green
                Background5 = Colors.Yellow }

        | OnPointerExited _ ->
            { model with
                Background4 = Colors.Red
                Background5 = Colors.Blue }

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
        Border()
            .style(borderTestStyle)
            .background(
                ImmutableConicGradientBrush(
                    [ ImmutableGradientStop(0., model.Background4)
                      ImmutableGradientStop(1., model.Background5) ],
                    center = RelativePoint.Parse("50%, 50%")
                )
            )
            .onPointerEntered(OnPointerEnter)
            .onPointerExited(OnPointerExited)
            .transition(BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(0.5)))
