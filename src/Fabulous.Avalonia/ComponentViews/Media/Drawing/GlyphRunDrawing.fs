namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentGlyphRunDrawing =
    inherit IFabComponentDrawing
    inherit IFabGlyphRunDrawing

[<AutoOpen>]
module ComponentGlyphRunDrawingBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a GlyphRunDrawing widget.</summary>
        /// <param name="brush">The content of the drawing.</param>
        /// <param name="glyphRun">The glyph run to draw.</param>
        static member GlyphRunDrawing(brush: WidgetBuilder<'msg, #IFabBrush>, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabComponentGlyphRunDrawing>(
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
            WidgetBuilder<'msg, IFabComponentGlyphRunDrawing>(
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

type ComponentGlyphRunDrawingModifiers =

    /// <summary>Link a ViewRef to access the direct GlyphRunDrawing control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentGlyphRunDrawing>, value: ViewRef<GlyphRunDrawing>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
