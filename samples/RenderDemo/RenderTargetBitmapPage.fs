namespace RenderDemo

open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Fabulous.StackAllocatedCollections.StackList
open Avalonia.Media.Imaging
open Avalonia.Threading
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

type RenderTargetBitmapControl() =
    inherit Control()

    let mutable _bitmap: RenderTargetBitmap = null

    let mutable _st = Stopwatch.StartNew()

    override this.OnAttachedToLogicalTree(e) =
        _bitmap <- new RenderTargetBitmap(PixelSize(200, 200), Vector(96, 96))
        base.OnAttachedToLogicalTree(e)

    override this.OnDetachedFromLogicalTree(e) =
        _bitmap.Dispose()
        _bitmap <- null

        base.OnDetachedFromLogicalTree(e)

    override this.Render(context) =
        using (_bitmap.CreateDrawingContext()) (fun ctx ->
            using
                (ctx.PushTransform(
                    Matrix.CreateTranslation(-100, -100)
                    * Matrix.CreateRotation(_st.Elapsed.TotalSeconds)
                    * Matrix.CreateTranslation(100, 100)
                ))
                (fun _ -> ctx.FillRectangle(Brushes.Fuchsia, Rect(50, 50, 100, 100))))

        context.DrawImage(_bitmap, Rect(0, 0, 200, 200), Rect(0, 0, 200, 200))

        Dispatcher.UIThread.Post(this.InvalidateVisual, DispatcherPriority.Background)

        base.Render(context)

type IFabRenderTargetBitmap =
    inherit IFabControl

module RenderTargetBitmap =

    let WidgetKey = Widgets.register<RenderTargetBitmapControl>()

[<AutoOpen>]
module RenderTargetBitmapBuilders =

    type Fabulous.Avalonia.View with

        static member inline RenderTargetBitmap<'msg>() =
            WidgetBuilder<'msg, IFabRenderTargetBitmap>(RenderTargetBitmap.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module RenderTargetBitmapPage =
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model, []

    let view _ = Grid() { View.RenderTargetBitmap() }
