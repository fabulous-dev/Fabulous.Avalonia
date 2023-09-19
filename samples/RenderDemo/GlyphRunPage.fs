namespace RenderDemo

open System
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Threading
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

type GlyphRunControl() =
    inherit Control()

    let mutable _glyphTypeface = Typeface.Default.GlyphTypeface

    let mutable _rand = Random()

    let mutable _glyphIndices = Array.zeroCreate<_> 1

    let mutable _characters = Array.zeroCreate<_> 1

    let mutable _fontSize = 20.0

    let mutable _direction = 10

    let mutable _timer = DispatcherTimer()

    override this.OnAttachedToVisualTree e =
        _timer <- DispatcherTimer(Interval = TimeSpan.FromSeconds(1.0))

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree e =
        _timer.Stop()

        _timer <- null

    override this.Render context =
        let c = char(_rand.Next(65, 90))

        if _fontSize + float _direction > 200.0 then
            _direction <- -10
        elif _fontSize + float _direction < 20.0 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices.[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters.[0] <- c

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        context.DrawGlyphRun(Brushes.Black, glyphRun)

type GlyphRunGeometryControl() =
    inherit Control()

    let mutable _glyphTypeface = Typeface.Default.GlyphTypeface

    let mutable _rand = Random()

    let mutable _glyphIndices = Array.zeroCreate<_> 1

    let mutable _characters = Array.zeroCreate<_> 1

    let mutable _fontSize = 20.0

    let mutable _direction = 10

    let mutable _timer = DispatcherTimer()

    override this.OnAttachedToVisualTree e =
        _timer <- DispatcherTimer(Interval = TimeSpan.FromSeconds(1.0))

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree e =
        _timer.Stop()

        _timer <- null

    override this.Render context =
        let c = char(_rand.Next(65, 90))

        if _fontSize + float _direction > 200.0 then
            _direction <- -10
        elif _fontSize + float _direction < 20.0 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices.[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters.[0] <- c

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        let geometry = glyphRun.BuildGeometry()

        context.DrawGeometry(Brushes.Green, null, geometry)


type IFabGlyphRunControl =
    inherit IFabControl

module GlyphRun =

    let WidgetKey = Widgets.register<GlyphRunControl>()

[<AutoOpen>]
module GlyphRunControlBuilders =

    type Fabulous.Avalonia.View with

        static member inline GlyphRun<'msg>() =
            WidgetBuilder<'msg, IFabGlyphRunControl>(GlyphRun.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type IFabGlyphRunGeometryControl =
    inherit IFabControl

module GlyphRunGeometry =
    let WidgetKey = Widgets.register<GlyphRunGeometryControl>()

[<AutoOpen>]
module GlyphRunGeometryControlBuilders =

    type Fabulous.Avalonia.View with

        static member inline GlyphRunGeometry<'msg>() =
            WidgetBuilder<'msg, IFabGlyphRunGeometryControl>(GlyphRunGeometry.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))


module GlyphRunPage =
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

    let view _ =
        (Grid(coldefs = [ Star; Star ], rowdefs = [ Auto ]) {
            View.GlyphRun().gridColumn(0)
            View.GlyphRunGeometry().gridColumn(1)
        })
            .background(Brushes.White)
