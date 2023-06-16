namespace Gallery.Pages

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module CompositorAnimationsPage =
    type Model =
        { SlidingAnimationModel: SlidingAnimation.Model
          Vector3KeyFrameAnimationModel: Vector3KeyFrameAnimation.Model
          ExpressionAnimationModel: ExpressionAnimation.Model
          GalaxyAnimationModel: GalaxyAnimation.Model }

    type Msg =
        | SlidingAnimationPageMsg of SlidingAnimation.Msg
        | Vector3KeyFrameAnimationMsg of Vector3KeyFrameAnimation.Msg
        | ExpressionAnimationMsg of ExpressionAnimation.Msg
        | GalaxyAnimationMsg of GalaxyAnimation.Msg

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { SlidingAnimationModel = SlidingAnimation.init()
          Vector3KeyFrameAnimationModel = Vector3KeyFrameAnimation.init()
          ExpressionAnimationModel = ExpressionAnimation.init()
          GalaxyAnimationModel = GalaxyAnimation.init() },
        []

    let update msg model =
        match msg with
        | SlidingAnimationPageMsg msg ->
            let slidingAnimation = SlidingAnimation.update msg model.SlidingAnimationModel

            { model with
                SlidingAnimationModel = slidingAnimation },
            []

        | Vector3KeyFrameAnimationMsg msg ->
            let vector3KeyFrameAnimation =
                Vector3KeyFrameAnimation.update msg model.Vector3KeyFrameAnimationModel

            { model with
                Vector3KeyFrameAnimationModel = vector3KeyFrameAnimation },
            []

        | ExpressionAnimationMsg msg ->
            let expressionAnimation =
                ExpressionAnimation.update msg model.ExpressionAnimationModel

            { model with
                ExpressionAnimationModel = expressionAnimation },
            []

        | GalaxyAnimationMsg msg ->
            let galaxyAnimation = GalaxyAnimation.update msg model.GalaxyAnimationModel

            { model with
                GalaxyAnimationModel = galaxyAnimation },
            []

    let view (model: Model) =
        TabControl() {
            TabItem("Sliding", (View.map SlidingAnimationPageMsg (SlidingAnimation.view model.SlidingAnimationModel)))
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("Vector3KeyFrameAnimation", (View.map Vector3KeyFrameAnimationMsg (Vector3KeyFrameAnimation.view model.Vector3KeyFrameAnimationModel)))
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("ExpressionAnimation", (View.map ExpressionAnimationMsg (ExpressionAnimation.view model.ExpressionAnimationModel)))
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)

            TabItem("GalaxyAnimation", (View.map GalaxyAnimationMsg (GalaxyAnimation.view model.GalaxyAnimationModel)))
                .margin(0.)
                .padding(2.)
                .minHeight(32.)
                .fontSize(12.)
        }
