namespace RenderDemo

open System
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Media
open Avalonia
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module RenderTransformPage =
    type Model = { Value: int }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let init () = { Value = 0 }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(
                Image(ImageSource.fromString "avares://RenderDemo/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .margin(5)
            )
            .size(200., 200.)
            .borderThickness(2.)
            .borderBrush(SolidColorBrush(Colors.Black))

    let view _ =
        Grid() {
            VStack(32.) {
                Border()
                    .width(100.0)
                    .height(100.0)
                    .background(Brushes.Red)
                    .renderTransform(TransformGroup() { TranslateTransform() })
                    .animation(
                        (Animation(TimeSpan.FromSeconds(1.)) {
                            KeyFrame(TranslateTransform.XProperty, -300.).cue(0.)
                            KeyFrame(TranslateTransform.XProperty, -200.).cue(0.25)
                            KeyFrame(TranslateTransform.XProperty, -100.).cue(0.5)
                            KeyFrame(TranslateTransform.XProperty, 0.).cue(1.)
                        })
                            .playbackDirection(PlaybackDirection.Normal)
                            .easing(SpringEasing(1., 2000., 20., 0.))
                            .repeatForever()
                    )

                Grid() {
                    Border()
                        .style(borderTestStyle)
                        .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.))
                        .background(SolidColorBrush(Colors.DarkRed))
                        .animations(
                            Animations() {
                                (Animation(TimeSpan.FromSeconds(3.)) {
                                    KeyFrame(Rotate3DTransform.AngleXProperty, 0.).cue(0.)
                                    KeyFrame(Visual.ZIndexProperty, 4).cue(0.)
                                    KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.25)
                                    KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
                                    KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(1.)
                                    KeyFrame(Visual.ZIndexProperty, 4).cue(1.)
                                })
                                    .repeatForever()
                            }
                        )

                    Border()
                        .style(borderTestStyle)
                        .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.))
                        .background(SolidColorBrush(Colors.DarkGreen))
                        .gridRow(0)
                        .gridColumn(0)
                        .animation(
                            (Animation(TimeSpan.FromSeconds(3.)) {
                                KeyFrame(Rotate3DTransform.AngleXProperty, 90.).cue(0.)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(0.)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 180.).cue(0.25)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(0.25)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(0.75)
                                KeyFrame(Visual.ZIndexProperty, 4).cue(0.75)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 450.).cue(1.)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(1.)
                            })
                                .repeatForever()
                        )

                    Border()
                        .style(borderTestStyle)
                        .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.))
                        .background(SolidColorBrush(Colors.DarkBlue))
                        .gridRow(0)
                        .gridColumn(0)
                        .animation(
                            (Animation(TimeSpan.FromSeconds(3.)) {
                                KeyFrame(Rotate3DTransform.AngleXProperty, 180.).cue(0.)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(0.)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 360.).cue(0.5)
                                KeyFrame(Visual.ZIndexProperty, 4).cue(0.5)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 450.).cue(0.75)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(0.75)
                                KeyFrame(Rotate3DTransform.AngleXProperty, 540.).cue(1.)
                                KeyFrame(Visual.ZIndexProperty, 1).cue(1.)
                            })
                                .repeatForever()
                        )

                    Border()
                        .style(borderTestStyle)
                        .renderTransform(Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.))
                        .background(SolidColorBrush(Colors.Orange))
                        .gridRow(0)
                        .gridColumn(0)
                        .animation(
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
                        )
                }
            }
        }
