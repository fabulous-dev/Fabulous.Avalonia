namespace RenderDemo

open System
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Styling
open Fabulous.Avalonia


open type Fabulous.Avalonia.View

type CustomStringAnimator() =
    inherit InterpolatingAnimator<string>()

    override this.Interpolate(progress, _oldValue, newValue) =

        if newValue.Length = 0 then
            ""
        else
            let step = 1.0 / float newValue.Length
            let length = int(progress / step)
            let result = newValue.Substring(0, length + 1)
            result

module CustomAnimatorPage =
    let view () =
        Component("CustomAnimatorPage") {
            Animation.RegisterCustomAnimator<string, CustomStringAnimator>()
            Animation.SetAnimator(Setter(TextBlock.TextProperty, ""), CustomStringAnimator())
            
            Grid() {
                TextBlock("")
                    .centerHorizontal()
                    .animation(
                        Animation(KeyFrame(TextBlock.TextProperty, "0123456789").cue(1.), TimeSpan.FromSeconds(3.))
                            .repeatForever()
                    )
            }
        }
