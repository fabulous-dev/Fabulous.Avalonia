namespace Gallery.Pages

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Gallery

type GlyphRunControl() =
    inherit Control()
    let _glyphTypeface: IGlyphTypeface = Typeface.Default.GlyphTypeface
    let _rand: Random = Random()
    let _glyphIndices: uint16 array = [| uint16 1 |]
    let _characters: char array = [| char 1 |]
    let mutable _fontSize: float = 20.
    let mutable _direction: int = 10
    let mutable _timer: DispatcherTimer = null

    override this.OnAttachedToVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer <- DispatcherTimer()
        _timer.Interval <- TimeSpan.FromMilliseconds(1000.0)

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer.Stop()
        _timer <- null

    override this.Render(context: DrawingContext) =
        let c = char(_rand.Next(65, 90))

        if (_fontSize + float _direction) > 200 then
            _direction <- -10

        if (_fontSize + float _direction) < 20 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters[0] <- c

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        context.DrawGlyphRun(Brushes.Black, glyphRun)

type GlyphRunGeometryControl() =
    inherit Control()
    let _glyphTypeface: IGlyphTypeface = Typeface.Default.GlyphTypeface
    let _rand: Random = Random()
    let _glyphIndices: uint16 array = [| uint16 1 |]
    let _characters: char array = [| char 1 |]
    let mutable _fontSize: float = 20.
    let mutable _direction: int = 10
    let mutable _timer: DispatcherTimer = null

    override this.OnAttachedToVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer <- DispatcherTimer()
        _timer.Interval <- TimeSpan.FromMilliseconds(1000.0)

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer.Stop()
        _timer <- null

    override this.Render(context: DrawingContext) =
        let c = char(_rand.Next(65, 90))

        if (_fontSize + float _direction) > 200 then
            _direction <- -10

        if (_fontSize + float _direction) < 20 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters[0] <- c

        let gradient = LinearGradientBrush()
        gradient.GradientStops.Add(GradientStop(Colors.Orange, 0))
        gradient.GradientStops.Add(GradientStop(Colors.Teal, 1))
        gradient.StartPoint <- RelativePoint(0, 0, RelativeUnit.Relative)
        gradient.EndPoint <- RelativePoint(0, 1, RelativeUnit.Relative)

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        let geometry = glyphRun.BuildGeometry()

        context.DrawGeometry(Brushes.Green, ImmutablePen(gradient.ToImmutable(), 2), geometry)

type IFabGlyphRunControl =
    inherit IFabControl

module FabGlyphRunControl =
    let WidgetKey = Widgets.register<GlyphRunControl>()

[<AutoOpen>]
module FabGlyphRunControlBuilders =
    type Fabulous.Avalonia.View with

        static member GlyphRunControl() =
            WidgetBuilder<'msg, IFabGlyphRunControl>(FabGlyphRunControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type IFabGlyphRunGeometryControl =
    inherit IFabControl

module FabGlyphRunGeometryControl =
    let WidgetKey = Widgets.register<GlyphRunGeometryControl>()

[<AutoOpen>]
module FabGlyphRunGeometryControlBuilders =
    type Fabulous.Avalonia.View with

        static member GlyphRunGeometryControl() =
            WidgetBuilder<'msg, IFabGlyphRunGeometryControl>(FabGlyphRunGeometryControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module GlyphRunControlPage =
    open type Fabulous.Avalonia.View
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
        VStack(spacing = 15.) {
            GlyphRunControl().centerHorizontal().centerVertical()

            GlyphRunGeometryControl()
                .centerHorizontal()
                .centerVertical()
        }
