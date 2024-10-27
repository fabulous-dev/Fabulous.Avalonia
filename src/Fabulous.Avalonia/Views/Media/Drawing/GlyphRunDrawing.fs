namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabGlyphRunDrawing =
    inherit IFabDrawing

module GlyphRunDrawing =
    let WidgetKey = Widgets.register<GlyphRunDrawing>()

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget GlyphRunDrawing.ForegroundProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality GlyphRunDrawing.ForegroundProperty

    let GlyphRun =
        Attributes.defineAvaloniaPropertyWithEquality GlyphRunDrawing.GlyphRunProperty

type GlyphRunDrawingModifiers =

    /// <summary>Link a ViewRef to access the direct GlyphRunDrawing control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGlyphRunDrawing>, value: ViewRef<GlyphRunDrawing>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
