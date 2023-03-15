namespace Gallery

open System
open Avalonia
open Avalonia.Animation
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Transform3D =
    type Model =
        { Depth: float
          CenterX: float
          CenterY: float
          CenterZ: float
          AngleX: float
          AngleY: float
          AngleZ: float }

    type Msg =
        | ValueChanged of float
        | Press
        | CenterXChanged of float
        | CenterYChanged of float
        | CenterZChanged of float
        | AngleXChanged of float
        | AngleYChanged of float
        | AngleZChanged of float


    let init () =
        { Depth = 200.
          CenterX = 0.
          CenterY = 0.
          CenterZ = 0.
          AngleX = 0.
          AngleY = 0.
          AngleZ = 0. }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Depth = value }
        | Press -> model
        | CenterXChanged value -> { model with CenterX = value }
        | CenterYChanged value -> { model with CenterY = value }
        | CenterZChanged value -> { model with CenterZ = value }
        | AngleXChanged value -> { model with AngleX = value }
        | AngleYChanged value -> { model with AngleY = value }
        | AngleZChanged value -> { model with AngleZ = value }

    let border () =
        Border(
            Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                .margin(5)
        )
            .size(200., 200.)
            .borderThickness(2.)
            .borderBrush(SolidColorBrush(Colors.Black))
            .gridColumnSpan(2)

    let view model =
        (Grid(coldefs = [ Auto; Star; Auto; Star ], rowdefs = [ Star; Auto; Auto; Auto; Auto; Auto; Auto; Auto ]) {
            border()
                .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, model.Depth))
                .background(SolidColorBrush(Colors.DarkRed))
                .styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(3.)) {
                        KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
                        KeyFrame(Visual.ZIndexProperty, 4).cue(0.)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 90.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(0.25)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 360.)
                              Setter(Visual.ZIndexProperty, 4) ]
                        )
                            .cue(1.)
                    })
                        .repeatForever()
                }
            }

            border()
                .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, model.Depth))
                .background(SolidColorBrush(Colors.DarkGreen))
                .gridRow(0)
                .gridColumn(0)
                .styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(3.)) {
                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 90.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(0.)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 180.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(0.25)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 360.)
                              Setter(Visual.ZIndexProperty, 4) ]
                        )
                            .cue(0.75)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 450.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(1.)
                    })
                        .repeatForever()
                }
            }

            border()
                .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, model.Depth))
                .background(SolidColorBrush(Colors.DarkBlue))
                .gridRow(0)
                .gridColumn(0)
                .styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(3.)) {
                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 180.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(0.)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 360.)
                              Setter(Visual.ZIndexProperty, 4) ]
                        )
                            .cue(0.5)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 450.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(0.75)

                        KeyFrames(
                            [ Setter(Rotate3DTransform.AngleXProperty, 540.)
                              Setter(Visual.ZIndexProperty, 1) ]
                        )
                            .cue(1.)
                    })
                        .repeatForever()
                }
            }

            border()
                .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, model.Depth))
                .background(SolidColorBrush(Colors.Orange))
                .gridRow(0)
                .gridColumn(0)
                .styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(3.)) {
                        KeyFrame(Rotate3DTransform.AngleXProperty, 270.).cue(0.)
                        KeyFrame(Visual.ZIndexProperty, 1).cue(0.)
                        KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(0.25)
                        KeyFrame(Visual.ZIndexProperty, 4).cue(0.25)
                        KeyFrame(Rotate3DTransform.AngleXProperty, 450.).cue(0.5)
                        KeyFrame(Visual.ZIndexProperty, 1).cue(0.5)
                        KeyFrame(Rotate3DTransform.AngleXProperty, 630.).cue(1.)
                        KeyFrame(Visual.ZIndexProperty, 1).cue(1.)
                    })
                        .repeatForever()
                }
            }

            TextBlock("Depth: ").gridRow(1).gridColumn(0)

            Slider(100., 300., model.Depth, ValueChanged).gridRow(1).gridColumn(1)

            border()
                .background(
                    LinearGradientBrush(Point(0., 0.), Point(0., 1.)) {
                        GradientStop(0., Colors.Red)
                        GradientStop(1., Colors.Blue)
                    }
                )
                .gridRow(0)
                .gridColumn(2)
                .zIndex(-2)
                .verticalAlignment(VerticalAlignment.Center)
                .renderTransform(Rotate3DTransform(model.AngleX, model.AngleY, model.AngleZ, model.CenterX, model.CenterY, model.CenterZ, model.Depth))

            TextBlock("Center X: ").gridRow(1).gridColumn(2)

            Slider(-100., 100., model.CenterX, CenterXChanged).gridRow(1).gridColumn(3)

            TextBlock("Center Y: ").gridRow(2).gridColumn(2)

            Slider(-100., 100., model.CenterY, CenterYChanged).gridRow(2).gridColumn(3)

            TextBlock("Center Z: ").gridRow(3).gridColumn(2)

            Slider(-100., 100., model.CenterZ, CenterZChanged).gridRow(3).gridColumn(3)

            TextBlock("Angle X: ").gridRow(4).gridColumn(2)

            Slider(-180., 180., model.AngleX, AngleXChanged).gridRow(4).gridColumn(3)

            TextBlock("Angle Y: ").gridRow(5).gridColumn(2)

            Slider(-180., 180., model.AngleY, AngleYChanged).gridRow(5).gridColumn(3)

            TextBlock("Angle Z: ").gridRow(6).gridColumn(2)

            Slider(-180., 180., model.AngleZ, AngleZChanged).gridRow(6).gridColumn(3)

        })
            .clock(Clock())

    let sample =
        { Name = "Transform3D"
          Description = "Transform3D sample"
          Program = Helper.createProgram init update view }
