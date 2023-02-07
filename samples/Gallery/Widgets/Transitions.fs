namespace Gallery

open System
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Media.Transformation
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions =
    type Model =
        { Acorn: string
          Heart: string
          IsPlaying: bool
          AngleX: float
          PlayStateText: string }

    type Msg =
        | TogglePlayState
        | OnPointerEnter of PointerEventArgs

    let init () =
        { Acorn =
            "F1 M 16.6309,18.6563C 17.1309,8.15625 29.8809,14.1563 29.8809,14.1563C 30.8809,11.1563 34.1308,11.4063 34.1308,11.4063C 33.5,12 34.6309,13.1563 34.6309,13.1563C 32.1309,13.1562 31.1309,14.9062 31.1309,14.9062C 41.1309,23.9062 32.6309,27.9063 32.6309,27.9062C 24.6309,24.9063 21.1309,22.1562 16.6309,18.6563 Z M 16.6309,19.9063C 21.6309,24.1563 25.1309,26.1562 31.6309,28.6562C 31.6309,28.6562 26.3809,39.1562 18.3809,36.1563C 18.3809,36.1563 18,38 16.3809,36.9063C 15,36 16.3809,34.9063 16.3809,34.9063C 16.3809,34.9063 10.1309,30.9062 16.6309,19.9063 Z"
          IsPlaying = true
          PlayStateText = "Pause animations on this page"
          AngleX = 0.
          Heart =
            "M 272.70141,238.71731 C 206.46141,238.71731 152.70146,292.4773 152.70146,358.71731 C 152.70146,493.47282 288.63461,528.80461 381.26391,662.02535 C 468.83815,529.62199 609.82641,489.17075 609.82641,358.71731 C 609.82641,292.47731 556.06651,238.7173 489.82641,238.71731 C 441.77851,238.71731 400.42481,267.08774 381.26391,307.90481 C 362.10311,267.08773 320.74941,238.7173 272.70141,238.71731 z" }

    let update msg model =
        match msg with
        | TogglePlayState ->
            { model with
                IsPlaying = not model.IsPlaying
                PlayStateText =
                    if model.IsPlaying then
                        "Resume animations on this page"
                    else
                        "Pause animations on this page" }
        | OnPointerEnter _ -> { model with AngleX = 90. }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) = this.margin(15.).size(100., 100.)

    let borderShadowStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .margin(15.)
            .size(100., 100.)
            .background(SolidColorBrush(Colors.Transparent))
            .borderBrush(SolidColorBrush(Colors.Black))
            .borderThickness(1.)
            .boxShadow("5 5 10 2 Blue")

    let acorn (path: string) =
        Path(path)
            .name("Rect1")
            .fill(SolidColorBrush(Colors.White))
            .stretch(Stretch.Uniform)

    let heart (path: string) =
        Path(path).fill(SolidColorBrush(Colors.Red)).stretch(Stretch.Uniform)

    let view model =
        (Grid(coldefs = [ Auto ], rowdefs = [ Auto ]) {
            (VStack() {
                (HStack(20.) {
                    TextBlock("Hover to activate Transitions.")
                        .verticalAlignment(VerticalAlignment.Center)

                    Button("Toggle", TogglePlayState)
                })
                    .centerVertical()

                (UniformGrid() {
                    Border(acorn model.Acorn)
                        .style(borderTestStyle)
                        .background(SolidColorBrush(Colors.DarkRed))
                        .onPointerEnter(OnPointerEnter)
                        .renderTransform(
                            Rotate3DTransform(model.AngleX, 0., 0., 0., 0., -100., 200.).transitions() {
                                DoubleTransition(Rotate3DTransform.AngleXProperty, TimeSpan.FromSeconds(1.))
                                    .delay(TimeSpan.FromMilliseconds(0.5))
                                    .easing(BounceEaseIn())
                            }
                        )

                    Border(acorn model.Acorn)
                        .style(borderTestStyle)
                        .background(SolidColorBrush(Colors.Magenta))

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Navy))
                        .style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.SeaGreen))
                        .style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Orange))
                        .style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Gold))
                        .style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Gray))
                        .style(borderTestStyle)

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Red))
                        .style(borderTestStyle)

                    Border(heart model.Heart).cornerRadius(10.).style(borderShadowStyle)

                    Border(heart model.Heart)
                        .cornerRadius(0., 30., 60., 0.)
                        .style(borderShadowStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                    Border(acorn model.Acorn).style(borderTestStyle)

                })
                    .clipToBounds(false)
            })
                .centerVertical()
                .centerHorizontal()
                .clock(Clock())
                .clipToBounds(false)
        })

    let sample =
        { Name = "Transitions"
          Description = "Transitions sample"
          Program = Helper.createProgram init update view }
