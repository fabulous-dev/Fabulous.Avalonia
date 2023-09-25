namespace RenderDemo

open System
open System.Threading
open Avalonia
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

type CanvasItem() as this =
    inherit Border()
    let mutable _timer: DispatcherTimer = null
    let mutable _textBlock: TextBlock = null

    do
        this.Setup()
        _textBlock <- this.CreateTextBlock()
        this.Child <- _textBlock

    override this.OnPointerPressed(_: PointerPressedEventArgs) =
        this.Background <- Brushes.Green
        _textBlock.Text <- "Stop"
        _timer.Stop()

    override this.OnAttachedToVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer <- DispatcherTimer()
        _timer.Interval <- TimeSpan.FromMilliseconds(1000.0)

        _timer.Tick.Add(fun _ -> Dispatcher.UIThread.Post(fun _ -> this.Move()))

        _timer.Start()

    override this.OnDetachedFromVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer.Stop()
        _timer <- null

    member this.Setup() =
        this.CornerRadius <- CornerRadius(6.)
        this.Width <- 60.
        this.Height <- 60.
        this.Background <- Brushes.Gray

    member this.CreateTextBlock() =
        let textBlock = TextBlock()
        textBlock.HorizontalAlignment <- HorizontalAlignment.Center
        textBlock.VerticalAlignment <- VerticalAlignment.Center
        textBlock.Text <- "Run"
        textBlock.Foreground <- Brushes.White
        textBlock

    member this.Move() =
        match this.Parent with
        | :? Canvas as canvas ->
            let left = Random.Shared.NextDouble() * canvas.Bounds.Width
            let top = Random.Shared.NextDouble() * canvas.Bounds.Height
            Canvas.SetLeft(this, left)
            Canvas.SetTop(this, top)
        | _ -> ()

open type Fabulous.Avalonia.View

module ImplicitCanvasAnimationsPage =
    type Model =
        { ChildrenCount: int
          BenchmarkRunning: bool }

    type Msg =
        | ButtonClear
        | ButtonBenchmark
        | ButtonAdd
        | ButtonFps
        | ChildAdded
        | ChildrenCleared

    type CmdMsg =
        | AddChild
        | ToggleBenchmark
        | StopBenchmarkAndClearChildren
    
    let canvasRef = ViewRef<Canvas>()
    let mutable implicitAnimations: ImplicitAnimationCollection = null

    let ensureImplicitAnimations (implicitAnimations: ImplicitAnimationCollection) =
        let mutable implicitAnimations = implicitAnimations

        if implicitAnimations <> null then
            implicitAnimations
        else
            let compositor =
                ElementComposition
                    .GetElementVisual(canvasRef.Value)
                    .Compositor

            let sprintEasing1 = SpringEasing(1.5, 2000., 20.)
            let sprintEasing2 = SpringEasing(1., 1000., 20.)

            let offsetAnimation = compositor.CreateVector3KeyFrameAnimation()
            offsetAnimation.Target <- "Offset"
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", sprintEasing1)
            offsetAnimation.Duration <- TimeSpan.FromMilliseconds(400)

            let rotationAnimation = compositor.CreateScalarKeyFrameAnimation()
            rotationAnimation.Target <- "RotationAngle"
            rotationAnimation.InsertKeyFrame(0.0f, 0.0f, sprintEasing2)
            rotationAnimation.InsertKeyFrame(1.0f, float32(Math.PI * 2.0), sprintEasing2)
            rotationAnimation.Duration <- TimeSpan.FromMilliseconds(400)

            let animationGroup = compositor.CreateAnimationGroup()
            animationGroup.Add(offsetAnimation)
            animationGroup.Add(rotationAnimation)

            implicitAnimations <- compositor.CreateImplicitAnimationCollection()
            implicitAnimations["Offset"] <- animationGroup
            implicitAnimations

    let add () =
        let canvasItem = CanvasItem()

        let left = Random.Shared.NextDouble() * canvasRef.Value.Bounds.Width
        let top = Random.Shared.NextDouble() * canvasRef.Value.Bounds.Height

        Canvas.SetLeft(canvasItem, left)
        Canvas.SetTop(canvasItem, top)

        canvasItem.AttachedToVisualTree.AddHandler(fun x y ->
            implicitAnimations <- ensureImplicitAnimations implicitAnimations
            let compositionVisual = ElementComposition.GetElementVisual(canvasItem)

            if (compositionVisual <> null) then
                compositionVisual.ImplicitAnimations <- implicitAnimations)

        canvasRef.Value.Children.Add(canvasItem)


    let mutable cts: CancellationTokenSource = null
    
    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | AddChild ->
            Cmd.ofSub(fun dispatch ->
                add ()
                dispatch ChildAdded
            )
            
        | ToggleBenchmark ->
            Cmd.ofSub(fun dispatch ->
                if cts = null then
                    cts <- new CancellationTokenSource()
                    let renderDemo =
                        async {
                            let! ct = Async.CancellationToken
                            while not ct.IsCancellationRequested do
                                do! Async.Sleep 50
                                Dispatcher.UIThread.Post(fun _ ->
                                    add ()
                                    // TODO: Investigate performance of the MVU loop on Fabulous
                                    //dispatch ChildAdded
                                )
                        }
                    
                    Async.Start(renderDemo, cts.Token)
                else
                    cts.Cancel()
                    cts.Dispose()
                    cts <- null
            )
            
        | StopBenchmarkAndClearChildren ->
            if cts <> null then
                cts.Cancel()
                cts.Dispose()
                cts <- null
            
            canvasRef.Value.Children.Clear()
            Cmd.ofMsg ChildrenCleared

    let init () =
        { ChildrenCount = 0
          BenchmarkRunning = false },
        []

    let update msg model =
        match msg with
        | ChildAdded ->
            { model with ChildrenCount = model.ChildrenCount + 1 }, []
            
        | ChildrenCleared ->
            { model with ChildrenCount = 0 }, []
        
        | ButtonClear ->
            model, [StopBenchmarkAndClearChildren]
            
        | ButtonBenchmark ->
            { model with BenchmarkRunning = not model.BenchmarkRunning }, [ToggleBenchmark]
            
        | ButtonAdd ->
            model, [AddChild]
            
        | ButtonFps -> model, []


    let view model =
        Grid(coldefs = [], rowdefs = [ Star; Auto ]) {
            Canvas(canvasRef)
                .clipToBounds(true)
                .background(Brushes.WhiteSmoke)
                .gridRow(0)

            (HStack(6.) {
                Button("Clear", ButtonClear)
                    .horizontalAlignment(HorizontalAlignment.Center)

                Button((if model.BenchmarkRunning then "Stop" else "Benchmark"), ButtonBenchmark)
                    .horizontalAlignment(HorizontalAlignment.Center)

                Button("Add", ButtonAdd)
                    .horizontalAlignment(HorizontalAlignment.Center)

            })
                .margin(0., 6)
                .horizontalAlignment(HorizontalAlignment.Center)
                .gridRow(1)

            TextBlock($"Items: {model.ChildrenCount}")
                .margin(6.)
                .verticalAlignment(VerticalAlignment.Center)
                .horizontalAlignment(HorizontalAlignment.Left)
                .gridRow(1)

        }
