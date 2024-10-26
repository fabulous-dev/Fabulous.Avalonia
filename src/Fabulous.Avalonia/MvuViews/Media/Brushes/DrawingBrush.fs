namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDrawingBrush =
    inherit IFabMvuTileBrush
    inherit IFabDrawingBrush

[<AutoOpen>]
module MvuDrawingBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DrawingBrush widget.</summary>
        /// <param name="source">The source drawing.</param>
        static member DrawingBrush(source: WidgetBuilder<'msg, #IFabMvuDrawing>) =
            WidgetBuilder<'msg, IFabMvuDrawingBrush>(
                DrawingBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingBrush.Drawing.WithValue(source.Compile()) |], ValueNone)
            )
