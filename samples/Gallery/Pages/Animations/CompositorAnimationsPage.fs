namespace Gallery.Pages

open System
open Avalonia
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.LogicalTree
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CompositorAnimationsPage =
    type Model =
        { SlidingAnimationModel: SlidingAnimation.Model }

    type Msg = SlidingAnimationPageMsg of SlidingAnimation.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { SlidingAnimationModel = SlidingAnimation.init() }, []

    let update msg model =
        match msg with
        | SlidingAnimationPageMsg msg ->
            let slidingAnimation = SlidingAnimation.update msg model.SlidingAnimationModel

            { model with
                SlidingAnimationModel = slidingAnimation },
            []

    let view (model: Model) =
        TabControl() {
            TabItem("Sliding", (View.map SlidingAnimationPageMsg (SlidingAnimation.view model.SlidingAnimationModel)))
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)
        }
