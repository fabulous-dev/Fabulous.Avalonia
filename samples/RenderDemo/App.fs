namespace RenderDemo

open System
open Avalonia.Markup.Xaml.Styling
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View


module App =
    type Model =
        { ImplicitAnimationModel: ImplicitCanvasAnimationsPage.Model
          DrawLineAnimationModel: DrawLineAnimationPage.Model
          CompositorAnimationsModel: CompositorAnimationsPage.Model
          AnimationsModel: AnimationsPage.Model
          TransitionModel: TransitionsPage.Model
          BrushesModel: BrushesPage.Model }

    type Msg =
        | ImplicitAnimationMsg of ImplicitCanvasAnimationsPage.Msg
        | DraLineAnimationMsg of DrawLineAnimationPage.Msg
        | CompositorAnimationsMsg of CompositorAnimationsPage.Msg
        | AnimationsMsg of AnimationsPage.Msg
        | TransitionMsg of TransitionsPage.Msg
        | BrushesMsg of BrushesPage.Msg

    type SubpageCmdMsg =
        | ImplicitAnimationCmdMsg of ImplicitCanvasAnimationsPage.CmdMsg list
        | DrawLineAnimationCmdMsg of DrawLineAnimationPage.CmdMsg list
        | CompositorAnimationsCmdMsg of CompositorAnimationsPage.CmdMsg list
        | AnimationsCmdMsg of AnimationsPage.CmdMsg list
        | TransitionCmdMsg of TransitionsPage.CmdMsg list
        | BrushesCmdMsg of BrushesPage.CmdMsg list

    type CmdMsg =
        | NoCmdMsg
        | SubpageCmdMsgs of SubpageCmdMsg list

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoCmdMsg -> Cmd.none
        | SubpageCmdMsgs cmdMsgs ->
            let mapSubpageCmdMsg (cmdMsgs: SubpageCmdMsg) =
                let map (mapCmdMsgFn: 'subCmdMsg -> Cmd<'subMsg>) (mapFn: 'subMsg -> 'msg) (subCmdMsgs: 'subCmdMsg list) =
                    subCmdMsgs
                    |> List.map(fun c ->
                        let cmd = mapCmdMsgFn c
                        Cmd.map mapFn cmd)

                match cmdMsgs with
                | ImplicitAnimationCmdMsg subCmdMsgs -> map ImplicitCanvasAnimationsPage.mapCmdMsgToCmd ImplicitAnimationMsg subCmdMsgs
                | DrawLineAnimationCmdMsg cmdMsgs -> map DrawLineAnimationPage.mapCmdMsgToCmd DraLineAnimationMsg cmdMsgs
                | CompositorAnimationsCmdMsg cmdMsgs -> map CompositorAnimationsPage.mapCmdMsgToCmd CompositorAnimationsMsg cmdMsgs
                | AnimationsCmdMsg cmdMsgs -> map AnimationsPage.mapCmdMsgToCmd AnimationsMsg cmdMsgs
                | TransitionCmdMsg cmdMsgs -> map TransitionsPage.mapCmdMsgToCmd TransitionMsg cmdMsgs
                | BrushesCmdMsg cmdMsgs -> map BrushesPage.mapCmdMsgToCmd BrushesMsg cmdMsgs

            cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let init () =
        let implAnimModel, implCmdMsgs = ImplicitCanvasAnimationsPage.init()
        let drawLineModel, drawLineCmdMsgs = DrawLineAnimationPage.init()
        let compositorModel, compositorCmdMsgs = CompositorAnimationsPage.init()
        let animationsModel, animationsCmdMsgs = AnimationsPage.init()
        let transitionModel, transitionCmdMsgs = TransitionsPage.init()
        let brushesModel, brushesCmdMsgs = BrushesPage.init()

        { ImplicitAnimationModel = implAnimModel
          DrawLineAnimationModel = drawLineModel
          CompositorAnimationsModel = compositorModel
          AnimationsModel = animationsModel
          TransitionModel = transitionModel
          BrushesModel = brushesModel },
        [ SubpageCmdMsgs implCmdMsgs
          SubpageCmdMsgs drawLineCmdMsgs
          SubpageCmdMsgs compositorCmdMsgs
          SubpageCmdMsgs animationsCmdMsgs
          SubpageCmdMsgs transitionCmdMsgs
          SubpageCmdMsgs brushesCmdMsgs ]

    let update msg model =
        match msg with
        | ImplicitAnimationMsg msg ->
            let implAnimModel, cmdMsgs =
                ImplicitCanvasAnimationsPage.update msg model.ImplicitAnimationModel

            { model with
                ImplicitAnimationModel = implAnimModel },
            [ SubpageCmdMsgs [ ImplicitAnimationCmdMsg cmdMsgs ] ]

        | DraLineAnimationMsg msg ->
            let drawLineModel, cmdMsgs =
                DrawLineAnimationPage.update msg model.DrawLineAnimationModel

            { model with
                DrawLineAnimationModel = drawLineModel },
            [ SubpageCmdMsgs [ DrawLineAnimationCmdMsg cmdMsgs ] ]

        | CompositorAnimationsMsg msg ->
            let compositorModel, cmdMsgs =
                CompositorAnimationsPage.update msg model.CompositorAnimationsModel

            { model with
                CompositorAnimationsModel = compositorModel },
            [ SubpageCmdMsgs [ CompositorAnimationsCmdMsg cmdMsgs ] ]

        | AnimationsMsg msg ->
            let animationsModel, cmdMsgs = AnimationsPage.update msg model.AnimationsModel

            { model with
                AnimationsModel = animationsModel },
            [ SubpageCmdMsgs [ AnimationsCmdMsg cmdMsgs ] ]

        | TransitionMsg msg ->
            let transitionModel, cmdMsgs = TransitionsPage.update msg model.TransitionModel

            { model with
                TransitionModel = transitionModel },
            [ SubpageCmdMsgs [ TransitionCmdMsg cmdMsgs ] ]

        | BrushesMsg msg ->
            let brushesModel, cmdMsgs = BrushesPage.update msg model.BrushesModel

            { model with
                BrushesModel = brushesModel },
            [ SubpageCmdMsgs [ BrushesCmdMsg cmdMsgs ] ]

    let view model =
        let theme = StyleInclude(baseUri = null)
        theme.Source <- Uri("avares://RenderDemo/App.xaml")
        FabApplication.Current.Styles.Add(theme)

        (HamburgerMenu() {
            TabItem("Implicit Animations", (View.map ImplicitAnimationMsg (ImplicitCanvasAnimationsPage.view model.ImplicitAnimationModel)))
            TabItem("Draw Line Animation", (View.map DraLineAnimationMsg (DrawLineAnimationPage.view model.DrawLineAnimationModel)))
            TabItem("Compositor Animations", (View.map CompositorAnimationsMsg (CompositorAnimationsPage.view model.CompositorAnimationsModel)))
            TabItem("Animations", (View.map AnimationsMsg (AnimationsPage.view model.AnimationsModel)))
            TabItem("Transitions", (View.map TransitionMsg (TransitionsPage.view model.TransitionModel)))
            TabItem("Brushes", (View.map BrushesMsg (BrushesPage.view model.BrushesModel)))
        })
            .expandedModeThresholdWidth(760)


#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif

    let program = Program.statefulWithCmdMsg init update app mapCmdMsgToCmd
