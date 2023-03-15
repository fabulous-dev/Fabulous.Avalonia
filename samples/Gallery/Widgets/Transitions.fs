namespace Gallery

open System
open Avalonia
open Avalonia.Animation
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Controls

open type Fabulous.Avalonia.View

module Transitions =
    type Model =
        { Acorn: string
          Heart: string
          IsPlaying: bool
          Angle: float
          AngleX: float
          ScaleX: float
          SkewX: float
          Translate: float
          Height: float
          CornerRadius: float
          Padding: Thickness
          BoxShadow: BoxShadows
          Background: Color
          Background2: Color
          Background3: Color
          PlayStateText: string }

    type Msg =
        | TogglePlayState
        | OnPointerEnter1 of PointerEventArgs
        | OnPointerExited1 of PointerEventArgs

        | OnPointerEnter2 of PointerEventArgs
        | OnPointerExited2 of PointerEventArgs

        | OnPointerEnter3 of PointerEventArgs
        | OnPointerExited3 of PointerEventArgs

        | OnPointerEnter4 of PointerEventArgs
        | OnPointerExited4 of PointerEventArgs


        | OnPointerEnter5 of PointerEventArgs
        | OnPointerExited5 of PointerEventArgs

        | OnPointerEnter6 of PointerEventArgs
        | OnPointerExited6 of PointerEventArgs

        | OnPointerEnter7 of PointerEventArgs
        | OnPointerExited7 of PointerEventArgs

        | OnPointerEnter8 of PointerEventArgs
        | OnPointerExited8 of PointerEventArgs

        | OnPointerEnter9 of PointerEventArgs
        | OnPointerExited9 of PointerEventArgs

        | OnPointerEnter10 of PointerEventArgs
        | OnPointerExited10 of PointerEventArgs
        
        | OnPointerEnter11 of PointerEventArgs
        | OnPointerExited11 of PointerEventArgs
        
        | OnPointerEnter12 of PointerEventArgs
        | OnPointerExited12 of PointerEventArgs
        
        | OnPointerEnter13 of PointerEventArgs
        | OnPointerExited13 of PointerEventArgs
        
        | OnPointerEnter14 of PointerEventArgs
        | OnPointerExited14 of PointerEventArgs
        
        | OnPointerEnter15 of PointerEventArgs
        
        | OnPointerExited15 of PointerEventArgs

    let init () =
        { Acorn =
            "F1 M 16.6309,18.6563C 17.1309,8.15625 29.8809,14.1563 29.8809,14.1563C 30.8809,11.1563 34.1308,11.4063 34.1308,11.4063C 33.5,12 34.6309,13.1563 34.6309,13.1563C 32.1309,13.1562 31.1309,14.9062 31.1309,14.9062C 41.1309,23.9062 32.6309,27.9063 32.6309,27.9062C 24.6309,24.9063 21.1309,22.1562 16.6309,18.6563 Z M 16.6309,19.9063C 21.6309,24.1563 25.1309,26.1562 31.6309,28.6562C 31.6309,28.6562 26.3809,39.1562 18.3809,36.1563C 18.3809,36.1563 18,38 16.3809,36.9063C 15,36 16.3809,34.9063 16.3809,34.9063C 16.3809,34.9063 10.1309,30.9062 16.6309,19.9063 Z"
          IsPlaying = true
          PlayStateText = "Pause animations on this page"
          AngleX = 0.
          Angle = 0.
          ScaleX = 1.
          SkewX = 0.
          Translate = 0.
          Height = 100.
          CornerRadius = 0.
          Padding = Thickness(0.)
          BoxShadow = BoxShadows.Parse("2 2 2 2 Blue")
          Background = Colors.Red
          Background2 = Colors.Transparent
          Background3 = Colors.Transparent
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
        | OnPointerEnter1 _ -> { model with AngleX = 90. }

        | OnPointerExited1 _ -> { model with AngleX = 0. }

        | OnPointerEnter2 _ -> { model with ScaleX = 0.4 }

        | OnPointerExited2 _ ->

            { model with ScaleX = 1. }

        | OnPointerEnter3 _ -> { model with Angle = 90. }

        | OnPointerExited3 _ -> { model with Angle = 0. }

        | OnPointerEnter4 _ -> { model with Translate = 90. }

        | OnPointerExited4 _ -> { model with Translate = 0. }

        | OnPointerEnter5 _ -> { model with SkewX = 90. }

        | OnPointerExited5 _ -> { model with SkewX = 0. }

        | OnPointerEnter6 _ -> { model with Height = 50. }

        | OnPointerExited6 _ -> { model with Height = 100. }

        | OnPointerEnter7 _ -> { model with CornerRadius = 50. }

        | OnPointerExited7 _ -> { model with CornerRadius = 0. }


        | OnPointerEnter8 _ -> { model with Padding = Thickness(50.) }

        | OnPointerExited8 _ -> { model with Padding = Thickness(0.) }

        | OnPointerEnter9 _ ->
            { model with
                BoxShadow = BoxShadows.Parse("5 5 10 2 Green") }

        | OnPointerExited9 _ ->
            { model with
                BoxShadow = BoxShadows.Parse("2 2 2 2 Blue") }

        | OnPointerEnter10 _ -> { model with Background = Colors.Green }

        | OnPointerExited10 _ -> { model with Background = Colors.Red }
        
        | OnPointerEnter11 _ -> { model with Background2 = Colors.Red; Background3 = Colors.Blue }
        
        | OnPointerExited11 _ -> { model with Background2 = Colors.Transparent; Background3 = Colors.Transparent }
        
        | OnPointerEnter12 _ -> { model with Background2 = Colors.Blue; Background3 = Colors.Red }
        
        | OnPointerExited12 _ -> { model with Background2 = Colors.Transparent; Background3 = Colors.Transparent }
        
        | OnPointerEnter13 _ -> { model with Background2 = Colors.Red; Background3 = Colors.Blue }
        
        | OnPointerExited13 _ -> { model with Background2 = Colors.Transparent; Background3 = Colors.Transparent }
        
        | OnPointerEnter14 _ -> { model with Background2 = Colors.Blue; Background3 = Colors.Red }
        
        | OnPointerExited14 _ -> { model with Background2 = Colors.Transparent; Background3 = Colors.Transparent }
        
        | OnPointerEnter15 _ -> { model with Background2 = Colors.Red; Background3 = Colors.Blue }
        
        | OnPointerExited15 _ -> { model with Background2 = Colors.Transparent; Background3 = Colors.Transparent }

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) = this.margin(15.).size(100., 100.)

    let borderShadowStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .margin(15.)
            .size(100., 100.)
            .background(SolidColorBrush(Colors.Transparent))
            .borderBrush(SolidColorBrush(Colors.Black))
            .borderThickness(1.)


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
                        .onPointerEnter(OnPointerEnter1)
                        .onPointerExited(OnPointerExited1)
                        .renderTransform(
                            Rotate3DTransform(model.AngleX, 0., 0., 0., 0., -100., 200.).transitions() {
                                DoubleTransition(Rotate3DTransform.AngleXProperty, TimeSpan.FromSeconds(1.))
                            }
                        )

                    Border(acorn model.Acorn)
                        .style(borderTestStyle)
                        .background(SolidColorBrush(Colors.Magenta))
                        .onPointerEnter(OnPointerEnter2)
                        .onPointerExited(OnPointerExited2)
                        .renderTransform(
                            ScaleTransform(model.ScaleX, 1.).transitions() { DoubleTransition(ScaleTransform.ScaleXProperty, TimeSpan.FromSeconds(1.)) }
                        )

                    Border(acorn model.Acorn)
                        .style(borderTestStyle)
                        .background(SolidColorBrush(Colors.Brown))
                        .onPointerEnter(OnPointerEnter3)
                        .onPointerExited(OnPointerExited3)
                        .renderTransform(
                            RotateTransform(model.Angle, 0., 0.).transitions() { DoubleTransition(RotateTransform.AngleProperty, TimeSpan.FromSeconds(1.)) }
                        )

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Navy))
                        .style(borderTestStyle)
                        .onPointerEnter(OnPointerEnter4)
                        .onPointerExited(OnPointerExited4)
                        .renderTransform(
                            TranslateTransform(model.Translate, 0.).transitions() { DoubleTransition(TranslateTransform.XProperty, TimeSpan.FromSeconds(1.)) }
                        )

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.SeaGreen))
                        .style(borderTestStyle)
                        .onPointerEnter(OnPointerEnter5)
                        .onPointerExited(OnPointerExited5)
                        .renderTransform(
                            SkewTransform(model.SkewX, 0.).transitions() { DoubleTransition(SkewTransform.AngleXProperty, TimeSpan.FromSeconds(1.)) }
                        )

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Orange))
                        .onPointerEnter(OnPointerEnter6)
                        .onPointerExited(OnPointerExited6)
                        .margin(15.)
                        .height(model.Height)
                        .width(100.)
                        .transitions() {
                        DoubleTransition(Layoutable.HeightProperty, TimeSpan.FromSeconds(1.))
                    }


                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Gold))
                        .style(borderTestStyle)
                        .cornerRadius(CornerRadius(model.CornerRadius))
                        .onPointerEnter(OnPointerEnter7)
                        .onPointerExited(OnPointerExited7)
                        .transitions() {
                        CornerRadiusTransition(Avalonia.Controls.Border.CornerRadiusProperty, TimeSpan.FromSeconds(1.))
                    }

                    Border(acorn model.Acorn)
                        .background(SolidColorBrush(Colors.Gray))
                        .style(borderTestStyle)
                        .padding(model.Padding)
                        .onPointerEnter(OnPointerEnter8)
                        .onPointerExited(OnPointerExited8)
                        .transitions() {
                        ThicknessTransition(Decorator.PaddingProperty, TimeSpan.FromSeconds(1.))
                    }

                    Border(heart model.Heart)
                        .style(borderShadowStyle)
                        .boxShadows(model.BoxShadow)
                        .onPointerEnter(OnPointerEnter9)
                        .onPointerExited(OnPointerExited9)
                        .transitions() {
                        BoxShadowsTransition(Border.BoxShadowProperty, TimeSpan.FromSeconds(1.))
                    }

                    Border(heart model.Heart)
                        .cornerRadius(0., 30., 60., 0.)
                        .margin(15.)
                        .size(100., 100.)
                        .background(
                            SolidColorBrush(model.Background).transitions() { ColorTransition(SolidColorBrush.ColorProperty, TimeSpan.FromSeconds(1.)) }
                        )
                        .onPointerEnter(OnPointerEnter10)
                        .onPointerExited(OnPointerExited10)
                    
                    Border(heart model.Heart)
                        .style(borderTestStyle)
                        .background(
                            (LinearGradientBrush(RelativePoint.Parse("0%, 0%"), RelativePoint.Parse("100%, 100%")) {
                                GradientStop(0., model.Background2)
                                GradientStop(1., model.Background3)
                            }).transitions() {
                                BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(3.))
                            }
                        )
                        .onPointerEnter(OnPointerEnter11)
                        .onPointerExited(OnPointerExited11)
                    Border(heart model.Heart)
                        .style(borderTestStyle)
                        .background(
                            (ConicGradientBrush(RelativePoint.Parse("50%, 50%"), 0.) {
                                GradientStop(0., model.Background2)
                                GradientStop(1., model.Background3)
                            }).transitions() {
                                BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(3.))
                            }
                        )
                        .onPointerEnter(OnPointerEnter12)
                        .onPointerExited(OnPointerExited12)
          
                    Border(heart model.Heart)
                        .style(borderTestStyle)
                        .background(
                            (ConicGradientBrush(RelativePoint.Parse("70%, 70%"), 90.) {
                                GradientStop(0., model.Background2)
                                GradientStop(1., model.Background3)
                            }).transitions() {
                                BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(3.))
                            }
                        )
                        .onPointerEnter(OnPointerEnter13)
                        .onPointerExited(OnPointerExited13)

                    Border(heart model.Heart)
                        .style(borderTestStyle)
                        .background(
                            (RadialGradientBrush(RelativePoint.Parse("50%"), RelativePoint.Parse("50%")) {
                                GradientStop(0., model.Background2)
                                GradientStop(1., model.Background3)
                            })
                                .radius(0.5)
                                .transitions() {
                                    BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(3.))
                                }
                        )
                        .onPointerEnter(OnPointerEnter14)
                        .onPointerExited(OnPointerExited14)
                    
                    Border(heart model.Heart)
                        .style(borderTestStyle)
                        .background(
                            (RadialGradientBrush(RelativePoint.Parse("30%"), RelativePoint.Parse("30%")) {
                                GradientStop(0., model.Background2)
                                GradientStop(1., model.Background3)
                            })
                                .radius(0.2)
                                .transitions() {
                                    BrushTransition(Border.BackgroundProperty, TimeSpan.FromSeconds(3.))
                                }
                        )
                        .onPointerEnter(OnPointerEnter15)
                        .onPointerExited(OnPointerExited15)
                        
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
