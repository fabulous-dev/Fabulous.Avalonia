namespace Gallery.Pages

open System
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Avalonia.Animation.Animators

open type Fabulous.Avalonia.View

type CustomStringAnimator() =
    inherit Animator<string>()

    override this.Interpolate(progress, oldValue, newValue) =

        if newValue.Length = 0 then
            ""
        else
            let step = 1.0 / float newValue.Length
            let length = int(progress / step)
            let result = newValue.Substring(0, length + 1)
            result

module Animations3 =
    type Model = { Value: int }

    type Msg = Loaded of bool

    let init () =
        Animation.RegisterAnimator<CustomStringAnimator>(fun prop -> prop.PropertyType = typeof<string> && prop.Name = "Text")
        { Value = 0 }

    let update msg model =
        match msg with
        | Loaded _ ->
            Animation.SetAnimator(Setter(TextBlock.TextProperty, ""), CustomStringAnimator().GetType())
            model

    let view _ =
        Grid() {
            TextBlock("").centerHorizontal().onLoaded(Loaded).styles() {
                Animations() {
                    (Animation(TimeSpan.FromSeconds(3.)) {
                        KeyFrame(TextBlock.TextProperty, "").cue(0.)
                        KeyFrame(TextBlock.TextProperty, "0123456789").cue(1.)
                    })
                        .repeatForever()
                }
            }
        }
