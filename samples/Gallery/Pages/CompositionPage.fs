namespace Gallery.Pages

open System
open System.Numerics
open System.Threading
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Controls.Templates
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous.Avalonia

open Fabulous

open type Fabulous.Avalonia.View
open Gallery

[<Struct>]
type CompositionPageColorItem =
    { Color: Color }

    member this.ColorBrush = Avalonia.Media.SolidColorBrush(this.Color)
    member this.ColorHexValue = this.Color.ToString().Substring(3).ToUpperInvariant()

module CompositionPage =

    type Model =
        { Items: CompositionPageColorItem list }

    type Msg =
        | ButtonThreadSleep
        | ButtonStartCustomVisual
        | ButtonStopCustomVisual
        | CustomVisualHostVisualTreeAttached of VisualTreeAttachmentEventArgs
        | AttachAnimatedSolidVisual of VisualTreeAttachmentEventArgs
        | AttachedToVisualTree of VisualTreeAttachmentEventArgs

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let mutable _customVisual: CompositionCustomVisual = null
    let mutable _solidVisual: CompositionSolidColorVisual = null
    let mutable _implicitAnimations: ImplicitAnimationCollection = null
    let borderRef = ViewRef<Border>()

    let createColorItems () =
        [ { Color = Color.FromArgb(byte 255, byte 255, byte 185, byte 0) }
          { Color = Color.FromArgb(byte 255, byte 231, byte 72, byte 86) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 120, byte 215) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 153, byte 188) }
          { Color = Color.FromArgb(byte 255, byte 122, byte 117, byte 116) }
          { Color = Color.FromArgb(byte 255, byte 118, byte 118, byte 118) }
          { Color = Color.FromArgb(byte 255, byte 255, byte 141, byte 0) }
          { Color = Color.FromArgb(byte 255, byte 232, byte 17, byte 35) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 99, byte 177) }
          { Color = Color.FromArgb(byte 255, byte 45, byte 125, byte 154) }
          { Color = Color.FromArgb(byte 255, byte 93, byte 90, byte 88) }
          { Color = Color.FromArgb(byte 255, byte 76, byte 74, byte 72) }
          { Color = Color.FromArgb(byte 255, byte 247, byte 99, byte 12) }
          { Color = Color.FromArgb(byte 255, byte 234, byte 0, byte 94) }
          { Color = Color.FromArgb(byte 255, byte 142, byte 140, byte 216) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 183, byte 195) }
          { Color = Color.FromArgb(byte 255, byte 104, byte 118, byte 138) }
          { Color = Color.FromArgb(byte 255, byte 105, byte 121, byte 126) }
          { Color = Color.FromArgb(byte 255, byte 202, byte 80, byte 16) }
          { Color = Color.FromArgb(byte 255, byte 195, byte 0, byte 82) }
          { Color = Color.FromArgb(byte 255, byte 107, byte 105, byte 214) }
          { Color = Color.FromArgb(byte 255, byte 3, byte 131, byte 135) }
          { Color = Color.FromArgb(byte 255, byte 81, byte 92, byte 107) }
          { Color = Color.FromArgb(byte 255, byte 74, byte 84, byte 89) }
          { Color = Color.FromArgb(byte 255, byte 218, byte 59, byte 1) }
          { Color = Color.FromArgb(byte 255, byte 227, byte 0, byte 140) }
          { Color = Color.FromArgb(byte 255, byte 135, byte 100, byte 184) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 178, byte 148) }
          { Color = Color.FromArgb(byte 255, byte 86, byte 124, byte 115) }
          { Color = Color.FromArgb(byte 255, byte 100, byte 124, byte 100) }
          { Color = Color.FromArgb(byte 255, byte 239, byte 105, byte 80) }
          { Color = Color.FromArgb(byte 255, byte 191, byte 0, byte 119) }
          { Color = Color.FromArgb(byte 255, byte 116, byte 77, byte 169) }
          { Color = Color.FromArgb(byte 255, byte 1, byte 133, byte 116) }
          { Color = Color.FromArgb(byte 255, byte 72, byte 104, byte 96) }
          { Color = Color.FromArgb(byte 255, byte 82, byte 94, byte 84) }
          { Color = Color.FromArgb(byte 255, byte 209, byte 52, byte 56) }
          { Color = Color.FromArgb(byte 255, byte 194, byte 57, byte 179) }
          { Color = Color.FromArgb(byte 255, byte 177, byte 70, byte 194) }
          { Color = Color.FromArgb(byte 255, byte 0, byte 204, byte 106) }
          { Color = Color.FromArgb(byte 255, byte 73, byte 130, byte 5) }
          { Color = Color.FromArgb(byte 255, byte 132, byte 117, byte 69) }
          { Color = Color.FromArgb(byte 255, byte 255, byte 67, byte 67) }
          { Color = Color.FromArgb(byte 255, byte 154, byte 0, byte 137) }
          { Color = Color.FromArgb(byte 255, byte 136, byte 23, byte 152) }
          { Color = Color.FromArgb(byte 255, byte 16, byte 137, byte 62) }
          { Color = Color.FromArgb(byte 255, byte 16, byte 124, byte 16) }
          { Color = Color.FromArgb(byte 255, byte 126, byte 115, byte 95) } ]

    let init () = { Items = createColorItems() }, []

    let updateVisual (v: Visual) =
        if _customVisual = null then
            ()
        else
            let h = min v.Bounds.Height (v.Bounds.Width / 3.0)
            _customVisual.Size <- Vector(v.Bounds.Width, h)
            _customVisual.Offset <- Vector3D(0.0, (v.Bounds.Height - h) / 2.0, 0.0)
            ()

    let updateSolidVisual (v: Visual) =

        if (_solidVisual = null) then
            ()
        else
            _solidVisual.Size <- Vector(v.Bounds.Width / float 3, v.Bounds.Height / float 3)
            _solidVisual.Offset <- Vector3D(v.Bounds.Width / float 3, v.Bounds.Height / float 3, 0)

    let EnsureImplicitAnimations (visual: Visual) =
        if (_implicitAnimations = null) then
            let compositor = ElementComposition.GetElementVisual(visual).Compositor

            let offsetAnimation = compositor.CreateVector3KeyFrameAnimation()
            offsetAnimation.Target <- "Offset"
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue")
            offsetAnimation.Duration <- TimeSpan.FromMilliseconds(400)

            let rotationAnimation = compositor.CreateScalarKeyFrameAnimation()
            rotationAnimation.Target <- "RotationAngle"
            rotationAnimation.InsertKeyFrame(0.5f, 0.160f)
            rotationAnimation.InsertKeyFrame(1f, 0f)
            rotationAnimation.Duration <- TimeSpan.FromMilliseconds(400)

            let animationGroup = compositor.CreateAnimationGroup()
            animationGroup.Add(offsetAnimation)
            animationGroup.Add(rotationAnimation)

            _implicitAnimations <- compositor.CreateImplicitAnimationCollection()
            _implicitAnimations["Offset"] <- animationGroup


    let rec SetEnableAnimations (border: Border, enabled: bool) =
        let page =
            Avalonia.VisualTree.VisualExtensions.FindAncestorOfType<UserControl>(border)

        if page = null then
            border.AttachedToVisualTree.AddHandler(fun s t -> SetEnableAnimations(border, enabled))
        else if ElementComposition.GetElementVisual(page) = null then
            ()
        else
            EnsureImplicitAnimations(page)
            let visualParent = Avalonia.VisualTree.VisualExtensions.GetVisualParent(border)
            let compositionVisual = ElementComposition.GetElementVisual(visualParent)

            if compositionVisual <> null then
                compositionVisual.ImplicitAnimations <- _implicitAnimations


    let update msg model =
        match msg with
        | ButtonThreadSleep ->
            Thread.Sleep(10000)
            model, []
        | ButtonStartCustomVisual ->
            _customVisual.SendHandlerMessage(CustomVisualHandler.StartMessage)
            model, []
        | ButtonStopCustomVisual ->
            _customVisual.SendHandlerMessage(CustomVisualHandler.StopMessage)
            model, []
        | CustomVisualHostVisualTreeAttached args ->
            let v = args.Parent :?> Control
            let compositor = ElementComposition.GetElementVisual(v).Compositor

            if
                compositor = null
                || (_customVisual <> null && _customVisual.Compositor = compositor)
            then
                ()
            else
                _customVisual <- compositor.CreateCustomVisual(CustomVisualHandler())
                ElementComposition.SetElementChildVisual(v, _customVisual)
                updateVisual v

            v.PropertyChanged.AddHandler(fun _ a ->
                if a.Property = Visual.BoundsProperty then
                    updateVisual v)

            model, []
        | AttachAnimatedSolidVisual args ->
            let v = args.Parent :?> Control
            let compositor = ElementComposition.GetElementVisual(v).Compositor

            if
                compositor = null
                || (_solidVisual <> null && _solidVisual.Compositor = compositor)
            then
                ()
            else
                _solidVisual <- compositor.CreateSolidColorVisual()
                ElementComposition.SetElementChildVisual(v, _solidVisual)
                _solidVisual.Color <- Colors.Red
                let animation = _solidVisual.Compositor.CreateColorKeyFrameAnimation()
                animation.InsertKeyFrame(float32 0, Colors.Red)
                animation.InsertKeyFrame(0.5f, Colors.Blue)
                animation.InsertKeyFrame(float32 1, Colors.Green)
                animation.Duration <- TimeSpan.FromSeconds(5)
                animation.IterationBehavior <- AnimationIterationBehavior.Forever
                animation.Direction <- PlaybackDirection.Alternate
                _solidVisual.StartAnimation("Color", animation)
                _solidVisual.AnchorPoint <- Vector2(float32 0.0, float32 0.0)
                let scale = _solidVisual.Compositor.CreateVector3KeyFrameAnimation()
                scale.Duration <- TimeSpan.FromSeconds(5)
                scale.IterationBehavior <- AnimationIterationBehavior.Forever
                scale.InsertKeyFrame(float32 0, Vector3(float32 1.0, float32 1.0, float32 0.0))
                scale.InsertKeyFrame(0.5f, Vector3(1.5f, 1.5f, float32 0.0))
                scale.InsertKeyFrame(float32 1, Vector3(float32 1.0, float32 1.0, float32 0.0))
                _solidVisual.StartAnimation("Scale", scale)

                let center =
                    _solidVisual.Compositor.CreateExpressionAnimation("Vector3(this.Target.Size.X * 0.5, this.Target.Size.Y * 0.5, 1)")

                _solidVisual.StartAnimation("CenterPoint", center)
                updateSolidVisual v

            v.PropertyChanged.AddHandler(fun _ a ->
                if a.Property = Visual.BoundsProperty then
                    updateSolidVisual v)

            model, []
        | AttachedToVisualTree _ ->
            match borderRef.TryValue with
            | None -> ()
            | Some value -> SetEnableAnimations(value, true)

            model, []

    let view model =
        UserControl(
            TabControl() {
                TabItem(
                    "Implicit animations",
                    VStack() {
                        (Grid(coldefs = [ Auto; Pixel(10); Pixel(40) ], rowdefs = [ Auto ]) {
                            ItemsControl(
                                model.Items,
                                fun x ->
                                    Border(TextBlock(x.ColorHexValue))
                                        .padding(10.)
                                        .borderBrush(SolidColorBrush(Colors.Gray))
                                        .borderThickness(2.)
                                        .background(x.ColorBrush)
                                        .width(100.)
                                        .height(100.)
                                        .margin(10.)
                                        .reference(borderRef)
                                        .onAttachedToVisualTree(AttachedToVisualTree)
                            )
                                .itemsPanel(HWrapPanel())

                            GridSplitter(GridResizeDirection.Columns)
                                .resizeBehavior(GridResizeBehavior.PreviousAndNext)
                                .margin(2.)
                                .borderThickness(1.)
                                .borderBrush(SolidColorBrush(Colors.Gray))
                                .background(SolidColorBrush(Color.Parse("#e0e0e0")))
                                .gridColumn(1)

                            Border(
                                LayoutTransformControl(TextBlock("Resize me"))
                                    .layoutTransform(RotateTransform(90.))
                                    .minWidth(30.)
                                    .horizontalAlignment(HorizontalAlignment.Center)
                            )
                                .gridColumn(2)
                        })
                            .margin(0., 0., 40, 0.)
                    }
                )

                TabItem(
                    "Animation",
                    Dock() {
                        Button("Thread.Sleep(10000);", ButtonThreadSleep)
                            .dock(Dock.Top)

                        Border().onAttachedToVisualTree(AttachAnimatedSolidVisual)
                    }
                )

                TabItem(
                    "Custom",
                    Dock() {
                        (HStack() {
                            Button("Thread.Sleep(10000);", ButtonThreadSleep)
                            Button("Start", ButtonStartCustomVisual)
                            Button("Stop", ButtonStopCustomVisual)
                        })
                            .dock(Dock.Top)

                        Border()
                            .onAttachedToVisualTree(CustomVisualHostVisualTreeAttached)
                    }
                )
            }
        )
