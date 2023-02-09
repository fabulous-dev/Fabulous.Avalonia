namespace Fabulous.Avalonia

open System
open Avalonia.Animation
open Avalonia.Animation.Easings

type PageTransition =
    static member CrossFade(duration: TimeSpan, ?fadeEasyIn: Easing, ?fadeEasyOut: Easing) =
        let transition = CrossFade()
        transition.Duration <- duration
        transition.FadeInEasing <- fadeEasyIn |> Option.defaultValue(LinearEasing())
        transition.FadeOutEasing <- fadeEasyOut |> Option.defaultValue(LinearEasing())
        transition

    static member PageSlide(duration: TimeSpan, ?orientation: PageSlide.SlideAxis, ?slideEasyIn: Easing, ?slideEasyOut: Easing) =
        let transition = PageSlide()
        transition.Duration <- duration
        transition.Orientation <- orientation |> Option.defaultValue PageSlide.SlideAxis.Horizontal
        transition.SlideInEasing <- slideEasyIn |> Option.defaultValue(LinearEasing())
        transition.SlideOutEasing <- slideEasyOut |> Option.defaultValue(LinearEasing())
        transition

    static member CompositePageTransition(transitions: IPageTransition seq) =
        let transition = CompositePageTransition()
        transition.PageTransitions.AddRange(transitions)
        transition
