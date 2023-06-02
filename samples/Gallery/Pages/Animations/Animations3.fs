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
    inherit CustomAnimatorBase<string>()

    override this.Interpolate(progress, _oldValue, newValue) =

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
        // FIXME: RegisterAnimator is not internal.
        //Animation.RegisterAnimator<CustomStringAnimator>(fun prop -> prop.PropertyType = typeof<string> && prop.Name = "Text")
        { Value = 0 }

    let update msg model =
        match msg with
        | Loaded _ ->
            Animation.SetAnimator(Setter(TextBlock.TextProperty, ""), CustomStringAnimator())
            model

    let view _ =
        Grid() {
            TextBlock("")
                .centerHorizontal()
                .onLoaded(Loaded)
                .animation(
                    Animation(KeyFrame(TextBlock.TextProperty, "0123456789").cue(1.), TimeSpan.FromSeconds(3.))
                        .repeatForever()
                )
        }
