namespace Fabulous.Avalonia.Mvu

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuGlyphRunDrawing =
    inherit IFabMvuDrawing
    inherit IFabGlyphRunDrawing

[<AutoOpen>]
module MvuGlyphRunDrawingBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a GlyphRunDrawing widget.</summary>
        /// <param name="brush">The content of the drawing.</param>
        /// <param name="glyphRun">The glyph run to draw.</param>
        static member GlyphRunDrawing(brush: WidgetBuilder<'msg, #IFabBrush>, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabMvuGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GlyphRunDrawing.GlyphRun.WithValue(glyphRun)),
                    ValueSome [| GlyphRunDrawing.ForegroundWidget.WithValue(brush.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GlyphRunDrawing widget.</summary>
        /// <param name="brush">The content of the drawing.</param>
        /// <param name="glyphRun">The glyph run to draw.</param>
        static member GlyphRunDrawing(brush: IBrush, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabMvuGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                GlyphRunDrawing.GlyphRun.WithValue(glyphRun),
                GlyphRunDrawing.Foreground.WithValue(brush)
            )

        /// <summary>Creates a GlyphRunDrawing widget.</summary>
        /// <param name="brush">The content of the drawing.</param>
        /// <param name="glyphRun">The glyph run to draw.</param>
        static member GlyphRunDrawing(brush: Color, glyphRun: GlyphRun) =
            View.GlyphRunDrawing(View.SolidColorBrush(brush), glyphRun)

        /// <summary>Creates a GlyphRunDrawing widget.</summary>
        /// <param name="brush">The content of the drawing.</param>
        /// <param name="glyphRun">The glyph run to draw.</param>
        static member GlyphRunDrawing(brush: string, glyphRun: GlyphRun) =
            View.GlyphRunDrawing(View.SolidColorBrush(brush), glyphRun)
