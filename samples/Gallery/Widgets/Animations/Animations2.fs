namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Animations2 =
    type Model = { Value: int }

    type Msg = Id

    let init () = { Value = 0 }

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        Grid() {
            Border()
                .width(100.0)
                .height(100.0)
                .background(Brushes.Red)
                .renderTransform(TransformGroup() { TranslateTransform() })
                .styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(1.)) {
                        KeyFrame(TranslateTransform.XProperty, -300.).cue(0.)
                        KeyFrame(TranslateTransform.XProperty, -200.).cue(0.25)
                        KeyFrame(TranslateTransform.XProperty, -100.).cue(0.5)
                        KeyFrame(TranslateTransform.XProperty, 0.).cue(1.)
                    })
                        .playbackDirection(PlaybackDirection.Normal)
                        .easing(SpringEasing(1., 2000., 20., 0.))
                        .repeatForever()
                }
            }
        }

    let sample =
        { Name = "Spring animations"
          Description = "Spring animations"
          Program = Helper.createProgram init update view }
