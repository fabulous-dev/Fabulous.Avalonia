namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabGlyphRunDrawing =
    inherit IFabDrawing

module GlyphRunDrawing =
    let WidgetKey = Widgets.register<GlyphRunDrawing> ()

    let Foreground =
        Attributes.defineAvaloniaPropertyWidget GlyphRunDrawing.ForegroundProperty

    let GlyphRun =
        Attributes.defineAvaloniaPropertyWithEquality GlyphRunDrawing.GlyphRunProperty

[<AutoOpen>]
module GlyphRunDrawingBuilders =
    type Fabulous.Avalonia.View with

        static member GlyphRunDrawing(content: WidgetBuilder<'msg, #IFabBrush>, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one (GlyphRunDrawing.GlyphRun.WithValue(glyphRun)),
                    ValueSome [| GlyphRunDrawing.Foreground.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
