namespace Fabulous.Avalonia

open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

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

[<AutoOpen>]
module GlyphRunDrawingBuilders =
    type Fabulous.Avalonia.View with

        static member GlyphRunDrawing(content: WidgetBuilder<'msg, #IFabBrush>, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GlyphRunDrawing.GlyphRun.WithValue(glyphRun)),
                    ValueSome [| GlyphRunDrawing.ForegroundWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member GlyphRunDrawing(brush: #IBrush, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                GlyphRunDrawing.GlyphRun.WithValue(glyphRun),
                GlyphRunDrawing.Foreground.WithValue(brush)
            )

        static member GlyphRunDrawing(brush: string, glyphRun: GlyphRun) =
            WidgetBuilder<'msg, IFabGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                GlyphRunDrawing.GlyphRun.WithValue(glyphRun),
                GlyphRunDrawing.Foreground.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush)

            )
