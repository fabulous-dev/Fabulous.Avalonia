namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
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

        static member GlyphRunDrawing(content: WidgetBuilder<'msg, #IFabBrush>) =
            WidgetBuilder<'msg, IFabGlyphRunDrawing>(
                GlyphRunDrawing.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| GlyphRunDrawing.Foreground.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type GlyphRunDrawingModifiers =
    [<Extension>]
    static member inline glyphRun(this: WidgetBuilder<'msg, #IFabGlyphRunDrawing>, value: GlyphRun) =
        this.AddScalar(GlyphRunDrawing.GlyphRun.WithValue(value))
