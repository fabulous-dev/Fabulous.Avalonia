namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDrawingBrush =
    inherit IFabComponentTileBrush
    inherit IFabDrawingBrush

[<AutoOpen>]
module ComponentDrawingBrushBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DrawingBrush widget.</summary>
        /// <param name="source">The source drawing.</param>
        static member DrawingBrush(source: WidgetBuilder<unit, #IFabComponentDrawing>) =
            WidgetBuilder<unit, IFabComponentDrawingBrush>(
                DrawingBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingBrush.Drawing.WithValue(source.Compile()) |], ValueNone)
            )
