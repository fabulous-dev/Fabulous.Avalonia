namespace Gallery.Pages

open System
open Avalonia
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Avalonia.Rendering.Composition

type CustomVisualHandler() =
    inherit CompositionCustomVisualHandler()

    let mutable _animationElapsed: TimeSpan = TimeSpan.Zero
    let mutable _lastServerTime: TimeSpan option = None
    let mutable _running = false

    static let stopMessage = obj()

    static let startMessage = obj()

    static member StartMessage = startMessage

    static member StopMessage = stopMessage

    override this.OnRender(drawingContext: ImmediateDrawingContext) =
        if _running then
            if _lastServerTime.IsSome then
                _animationElapsed <- _animationElapsed + (base.CompositionNow - _lastServerTime.Value)

            _lastServerTime <- Some base.CompositionNow

            let cnt = 20
            let maxPointSizeX = base.EffectiveSize.X / (float cnt * 1.6)
            let maxPointSizeY = base.EffectiveSize.Y / 4.0
            let pointSize = Math.Min(maxPointSizeX, maxPointSizeY)
            let animationLength = TimeSpan.FromSeconds(4.0)
            let animationStage = _animationElapsed.TotalSeconds / animationLength.TotalSeconds
            let sinOffset = Math.Cos(_animationElapsed.TotalSeconds) * 1.5

            for c in 0 .. cnt - 1 do
                let stage = (animationStage + (float c / float cnt)) % 1.0

                let colorStage =
                    (animationStage
                     + (Math.Sin(_animationElapsed.TotalSeconds * 2.0) + 1.0) / 2.0
                     + (float c / float cnt)) % 1.0

                let posX = (base.EffectiveSize.X + pointSize * 3.0) * stage - pointSize

                let posY =
                    (base.EffectiveSize.Y - pointSize)
                    * (1.0 + Math.Sin(stage * 3.14 * 3.0 + sinOffset))
                    / 2.0
                    + pointSize / 2.0

                let opacity = Math.Sin(stage * 3.14)

                drawingContext.DrawEllipse(
                    ImmutableSolidColorBrush(
                        Color.FromArgb(
                            byte 255,
                            byte(255 - 255 * int colorStage),
                            byte(255 * int(Math.Abs(0.5 - colorStage)) * int 2.0),
                            byte(255 * int colorStage)
                        ),
                        opacity
                    ),
                    null,
                    Point(posX, posY),
                    pointSize / 2.0,
                    pointSize / 2.0
                )

    override this.OnMessage(message: obj) =
        if message = startMessage then
            _running <- true
            _lastServerTime <- None
            base.RegisterForNextAnimationFrameUpdate()
        elif message = stopMessage then
            _running <- false

    override this.OnAnimationFrameUpdate() =
        if _running then
            base.Invalidate()
            base.RegisterForNextAnimationFrameUpdate()
