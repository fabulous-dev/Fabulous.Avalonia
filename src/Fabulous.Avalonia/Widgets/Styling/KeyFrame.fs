namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Fabulous

type IFabKeyFrame =
    inherit IFabElement

module KeyFrame =

    let WidgetKey = Widgets.register<KeyFrame>()

    let Setters =
        Attributes.definePropertyWithGetSet<IAnimationSetter seq> "KeyFrame_Setters" (fun target -> (target :?> KeyFrame).Setters) (fun target value ->
            let target = (target :?> KeyFrame)
            target.Setters.Clear()

            for an in value do
                target.Setters.Add(an))

    let Cue =
        Attributes.defineProperty "KeyFrame_Cue" (Cue(0.)) (fun target value -> (target :?> KeyFrame).Cue <- value)

    let KeySpline =
        Attributes.defineProperty "KeyFrame_KeySpline" (KeySpline(0., 0., 1., 1.)) (fun target value -> (target :?> KeyFrame).KeySpline <- value)

    let KeyTime =
        Attributes.defineProperty "KeyFrame_KeyTime" TimeSpan.Zero (fun target value -> (target :?> KeyFrame).KeyTime <- value)

[<AutoOpen>]
module KeyFrameBuilders =

    type Fabulous.Avalonia.View with

        static member KeyFrame(setters: IAnimationSetter seq) =
            WidgetBuilder<'msg, IFabKeyFrame>(KeyFrame.WidgetKey, KeyFrame.Setters.WithValue(setters))

[<Extension>]
type KeyFrameModifiers =
    [<Extension>]
    static member inline cue(this: WidgetBuilder<'msg, #IFabKeyFrame>, clock: Cue) =
        this.AddScalar(KeyFrame.Cue.WithValue(clock))

    [<Extension>]
    static member inline keySpline(this: WidgetBuilder<'msg, #IFabKeyFrame>, spline: KeySpline) =
        this.AddScalar(KeyFrame.KeySpline.WithValue(spline))

    [<Extension>]
    static member inline keyTime(this: WidgetBuilder<'msg, #IFabKeyFrame>, time: TimeSpan) =
        this.AddScalar(KeyFrame.KeyTime.WithValue(time))
