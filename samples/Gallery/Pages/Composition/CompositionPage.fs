namespace Gallery.Pages

open Avalonia.Rendering.Composition
open Fabulous.Avalonia

open Fabulous

open type Fabulous.Avalonia.View
open Gallery


module CompositionPage =

    type Model =
        { ImplicitAnimation: ImplicitAnimations.Model
          Animation: Animations.Model
          CustomVisual: CustomVisual.Model }

    type Msg =
        | ImplicitAnimationsMsg of ImplicitAnimations.Msg
        | AnimationsMsg of Animations.Msg
        | CustomVisualMsg of CustomVisual.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { ImplicitAnimation = ImplicitAnimations.init()
          Animation = Animations.init()
          CustomVisual = CustomVisual.init() },
        []

    let update msg model =
        match msg with
        | ImplicitAnimationsMsg msg ->
            let m = ImplicitAnimations.update msg model.ImplicitAnimation
            { model with ImplicitAnimation = m }, []
        | AnimationsMsg msg ->
            let m = Animations.update msg model.Animation
            { model with Animation = m }, []

        | CustomVisualMsg msg ->
            let m = CustomVisual.update msg model.CustomVisual
            { model with CustomVisual = m }, []

    let rec view model =
        UserControl(
            TabControl() {
                View.map ImplicitAnimationsMsg (ImplicitAnimations.view model.ImplicitAnimation)
                View.map AnimationsMsg (Animations.view model.Animation)
                View.map CustomVisualMsg (CustomVisual.view model.CustomVisual)
            }
        )
