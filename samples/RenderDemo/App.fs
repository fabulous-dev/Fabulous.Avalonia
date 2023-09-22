namespace RenderDemo

open System
open System.Diagnostics
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
          BrushesModel: BrushesPage.Model
          ClippingModel: ClippingPage.Model
          DrawingModel: DrawingPage.Model
          LineBoundsModel: LineBoundsPage.Model
          TransformModel: Transform3DPage.Model
          WritableBitmapModel: WriteableBitmapPage.Model
          CustomAnimatorModel: CustomAnimatorPage.Model
          CustomSkiaControlModel: CustomSkiaPage.Model
          GlyphRunModel: GlyphRunPage.Model
          FormattedTextModel: FormattedTextPage.Model
          TextFormatterModel: TextFormatterPage.Model
          RenderTransformModel: RenderTransformPage.Model
          RenderTargetBitmapModel: RenderTargetBitmapPage.Model }

    type Msg =
        | ImplicitAnimationMsg of ImplicitCanvasAnimationsPage.Msg
        | DraLineAnimationMsg of DrawLineAnimationPage.Msg
        | CompositorAnimationsMsg of CompositorAnimationsPage.Msg
        | AnimationsMsg of AnimationsPage.Msg
        | TransitionMsg of TransitionsPage.Msg
        | BrushesMsg of BrushesPage.Msg
        | ClippingMsg of ClippingPage.Msg
        | DrawingMsg of DrawingPage.Msg
        | LineBoundsMsg of LineBoundsPage.Msg
        | TransformMsg of Transform3DPage.Msg
        | WritableBitmapMsg of WriteableBitmapPage.Msg
        | CustomAnimatorMsg of CustomAnimatorPage.Msg
        | CustomSkiaControlMsg of CustomSkiaPage.Msg
        | GlyphRunMsg of GlyphRunPage.Msg
        | FormattedTextMsg of FormattedTextPage.Msg
        | TextFormatterMsg of TextFormatterPage.Msg
        | RenderTransformMsg of RenderTransformPage.Msg
        | RenderTargetBitmapMsg of RenderTargetBitmapPage.Msg

    type SubpageCmdMsg =
        | ImplicitAnimationCmdMsg of ImplicitCanvasAnimationsPage.CmdMsg list
        | DrawLineAnimationCmdMsg of DrawLineAnimationPage.CmdMsg list
        | CompositorAnimationsCmdMsg of CompositorAnimationsPage.CmdMsg list
        | AnimationsCmdMsg of AnimationsPage.CmdMsg list
        | TransitionCmdMsg of TransitionsPage.CmdMsg list
        | BrushesCmdMsg of BrushesPage.CmdMsg list
        | ClippingCmdMsg of ClippingPage.CmdMsg list
        | DrawingCmdMsg of DrawingPage.CmdMsg list
        | LineBoundsCmdMsg of LineBoundsPage.CmdMsg list
        | TransformCmdMsg of Transform3DPage.CmdMsg list
        | WritableBitmapCmdMsg of WriteableBitmapPage.CmdMsg list
        | CustomAnimatorCmdMsg of CustomAnimatorPage.CmdMsg list
        | CustomSkiaControlCmdMsg of CustomSkiaPage.CmdMsg list
        | GlyphRunCmdMsg of GlyphRunPage.CmdMsg list
        | FormattedTextCmdMsg of FormattedTextPage.CmdMsg list
        | TextFormatterCmdMsg of TextFormatterPage.CmdMsg list
        | RenderTransformCmdMsg of RenderTransformPage.CmdMsg list
        | RenderTargetBitmapCmdMsg of RenderTargetBitmapPage.CmdMsg list

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
                | ClippingCmdMsg cmdMsgs -> map ClippingPage.mapCmdMsgToCmd ClippingMsg cmdMsgs
                | DrawingCmdMsg cmdMsgs -> map DrawingPage.mapCmdMsgToCmd DrawingMsg cmdMsgs
                | LineBoundsCmdMsg cmdMsgs -> map LineBoundsPage.mapCmdMsgToCmd LineBoundsMsg cmdMsgs
                | TransformCmdMsg cmdMsgs -> map Transform3DPage.mapCmdMsgToCmd TransformMsg cmdMsgs
                | WritableBitmapCmdMsg cmdMsgs -> map WriteableBitmapPage.mapCmdMsgToCmd WritableBitmapMsg cmdMsgs
                | CustomAnimatorCmdMsg cmdMsgs -> map CustomAnimatorPage.mapCmdMsgToCmd CustomAnimatorMsg cmdMsgs
                | CustomSkiaControlCmdMsg cmdMsgs -> map CustomSkiaPage.mapCmdMsgToCmd CustomSkiaControlMsg cmdMsgs
                | GlyphRunCmdMsg cmdMsgs -> map GlyphRunPage.mapCmdMsgToCmd GlyphRunMsg cmdMsgs
                | FormattedTextCmdMsg cmdMsgs -> map FormattedTextPage.mapCmdMsgToCmd FormattedTextMsg cmdMsgs
                | TextFormatterCmdMsg cmdMsgs -> map TextFormatterPage.mapCmdMsgToCmd TextFormatterMsg cmdMsgs
                | RenderTransformCmdMsg cmdMsgs -> map RenderTransformPage.mapCmdMsgToCmd RenderTransformMsg cmdMsgs
                | RenderTargetBitmapCmdMsg cmdMsgs -> map RenderTargetBitmapPage.mapCmdMsgToCmd RenderTargetBitmapMsg cmdMsgs

            cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let init () =
        let implAnimModel, implCmdMsgs = ImplicitCanvasAnimationsPage.init()
        let drawLineModel, drawLineCmdMsgs = DrawLineAnimationPage.init()
        let compositorModel, compositorCmdMsgs = CompositorAnimationsPage.init()
        let animationsModel, animationsCmdMsgs = AnimationsPage.init()
        let transitionModel, transitionCmdMsgs = TransitionsPage.init()
        let brushesModel, brushesCmdMsgs = BrushesPage.init()
        let clippingModel, clippingCmdMsgs = ClippingPage.init()
        let drawingModel, drawingCmdMsgs = DrawingPage.init()
        let lineBoundsModel, lineBoundsCmdMsgs = LineBoundsPage.init()
        let transformModel, transformCmdMsgs = Transform3DPage.init()
        let writableBitmapModel, writableBitmapCmdMsgs = WriteableBitmapPage.init()
        let customAnimatorModel, customAnimatorCmdMsgs = CustomAnimatorPage.init()
        let customSkiaControlModel, customSkiaControlCmdMsgs = CustomSkiaPage.init()
        let glyphRunModel, glyphRunCmdMsgs = GlyphRunPage.init()
        let formattedTextModel, formattedTextCmdMsgs = FormattedTextPage.init()
        let textFormatterModel, textFormatterCmdMsgs = TextFormatterPage.init()
        let renderTransformModel, renderTransformCmdMsgs = RenderTransformPage.init()

        let renderTargetBitmapModel, renderTargetBitmapCmdMsgs =
            RenderTargetBitmapPage.init()

        { ImplicitAnimationModel = implAnimModel
          DrawLineAnimationModel = drawLineModel
          CompositorAnimationsModel = compositorModel
          AnimationsModel = animationsModel
          TransitionModel = transitionModel
          BrushesModel = brushesModel
          ClippingModel = clippingModel
          DrawingModel = drawingModel
          LineBoundsModel = lineBoundsModel
          TransformModel = transformModel
          WritableBitmapModel = writableBitmapModel
          CustomAnimatorModel = customAnimatorModel
          CustomSkiaControlModel = customSkiaControlModel
          GlyphRunModel = glyphRunModel
          FormattedTextModel = formattedTextModel
          TextFormatterModel = textFormatterModel
          RenderTransformModel = renderTransformModel
          RenderTargetBitmapModel = renderTargetBitmapModel },
        [ SubpageCmdMsgs implCmdMsgs
          SubpageCmdMsgs drawLineCmdMsgs
          SubpageCmdMsgs compositorCmdMsgs
          SubpageCmdMsgs animationsCmdMsgs
          SubpageCmdMsgs transitionCmdMsgs
          SubpageCmdMsgs brushesCmdMsgs
          SubpageCmdMsgs clippingCmdMsgs
          SubpageCmdMsgs drawingCmdMsgs
          SubpageCmdMsgs lineBoundsCmdMsgs
          SubpageCmdMsgs transformCmdMsgs
          SubpageCmdMsgs writableBitmapCmdMsgs
          SubpageCmdMsgs customAnimatorCmdMsgs
          SubpageCmdMsgs customSkiaControlCmdMsgs
          SubpageCmdMsgs glyphRunCmdMsgs
          SubpageCmdMsgs formattedTextCmdMsgs
          SubpageCmdMsgs textFormatterCmdMsgs
          SubpageCmdMsgs renderTransformCmdMsgs
          SubpageCmdMsgs renderTargetBitmapCmdMsgs ]

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

        | ClippingMsg msg ->
            let clippingModel, cmdMsgs = ClippingPage.update msg model.ClippingModel

            { model with
                ClippingModel = clippingModel },
            [ SubpageCmdMsgs [ ClippingCmdMsg cmdMsgs ] ]

        | DrawingMsg msg ->
            let drawingModel, cmdMsgs = DrawingPage.update msg model.DrawingModel

            { model with
                DrawingModel = drawingModel },
            [ SubpageCmdMsgs [ DrawingCmdMsg cmdMsgs ] ]

        | LineBoundsMsg msg ->
            let lineBoundsModel, cmdMsgs = LineBoundsPage.update msg model.LineBoundsModel

            { model with
                LineBoundsModel = lineBoundsModel },
            [ SubpageCmdMsgs [ LineBoundsCmdMsg cmdMsgs ] ]

        | TransformMsg msg ->
            let transformModel, cmdMsgs = Transform3DPage.update msg model.TransformModel

            { model with
                TransformModel = transformModel },
            [ SubpageCmdMsgs [ TransformCmdMsg cmdMsgs ] ]

        | WritableBitmapMsg msg ->
            let writableBitmapModel, cmdMsgs =
                WriteableBitmapPage.update msg model.WritableBitmapModel

            { model with
                WritableBitmapModel = writableBitmapModel },
            [ SubpageCmdMsgs [ WritableBitmapCmdMsg cmdMsgs ] ]

        | CustomAnimatorMsg msg ->
            let customAnimatorModel, cmdMsgs =
                CustomAnimatorPage.update msg model.CustomAnimatorModel

            { model with
                CustomAnimatorModel = customAnimatorModel },
            [ SubpageCmdMsgs [ CustomAnimatorCmdMsg cmdMsgs ] ]

        | CustomSkiaControlMsg msg ->
            let customSkiaControlModel, cmdMsgs =
                CustomSkiaPage.update msg model.CustomSkiaControlModel

            { model with
                CustomSkiaControlModel = customSkiaControlModel },
            [ SubpageCmdMsgs [ CustomSkiaControlCmdMsg cmdMsgs ] ]

        | GlyphRunMsg msg ->
            let glyphRunModel, cmdMsgs = GlyphRunPage.update msg model.GlyphRunModel

            { model with
                GlyphRunModel = glyphRunModel },
            [ SubpageCmdMsgs [ GlyphRunCmdMsg cmdMsgs ] ]

        | FormattedTextMsg msg ->
            let formattedTextModel, cmdMsgs =
                FormattedTextPage.update msg model.FormattedTextModel

            { model with
                FormattedTextModel = formattedTextModel },
            [ SubpageCmdMsgs [ FormattedTextCmdMsg cmdMsgs ] ]

        | TextFormatterMsg msg ->
            let textFormatterModel, cmdMsgs =
                TextFormatterPage.update msg model.TextFormatterModel

            { model with
                TextFormatterModel = textFormatterModel },
            [ SubpageCmdMsgs [ TextFormatterCmdMsg cmdMsgs ] ]

        | RenderTransformMsg msg ->
            let renderTransformModel, cmdMsgs =
                RenderTransformPage.update msg model.RenderTransformModel

            { model with
                RenderTransformModel = renderTransformModel },
            [ SubpageCmdMsgs [ RenderTransformCmdMsg cmdMsgs ] ]

        | RenderTargetBitmapMsg msg ->
            let renderTargetBitmapModel, cmdMsgs =
                RenderTargetBitmapPage.update msg model.RenderTargetBitmapModel

            { model with
                RenderTargetBitmapModel = renderTargetBitmapModel },
            [ SubpageCmdMsgs [ RenderTargetBitmapCmdMsg cmdMsgs ] ]

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
            TabItem("Render Transform", (View.map RenderTransformMsg (RenderTransformPage.view model.RenderTransformModel)))
            TabItem("Brushes", (View.map BrushesMsg (BrushesPage.view model.BrushesModel)))
            TabItem("Clipping", (View.map ClippingMsg (ClippingPage.view model.ClippingModel)))
            TabItem("Drawing", (View.map DrawingMsg (DrawingPage.view model.DrawingModel)))
            TabItem("Line Bounds", (View.map LineBoundsMsg (LineBoundsPage.view model.LineBoundsModel)))
            TabItem("Transform3D", (View.map TransformMsg (Transform3DPage.view model.TransformModel)))
            TabItem("Writable Bitmap", (View.map WritableBitmapMsg (WriteableBitmapPage.view model.WritableBitmapModel)))
            TabItem("Render Target Bitmap", (View.map RenderTargetBitmapMsg (RenderTargetBitmapPage.view model.RenderTargetBitmapModel)))
            TabItem("Custom Animator", (View.map CustomAnimatorMsg (CustomAnimatorPage.view model.CustomAnimatorModel)))
            TabItem("SkCanvas", (View.map CustomSkiaControlMsg (CustomSkiaPage.view model.CustomSkiaControlModel)))
            TabItem("GlyphRun", (View.map GlyphRunMsg (GlyphRunPage.view model.GlyphRunModel)))
            TabItem("FormattedText", (View.map FormattedTextMsg (FormattedTextPage.view model.FormattedTextModel)))
            TabItem("TextFormatter", (View.map TextFormatterMsg (TextFormatterPage.view model.TextFormatterModel)))
        })
            .expandedModeThresholdWidth(760)


#if MOBILE
    let app model = SingleViewApplication(view model)
#else
    let app model = DesktopApplication(Window(view model))
#endif
    let program =
        Program.statefulWithCmdMsg init update app mapCmdMsgToCmd
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )
