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
            WidgetBuilder<unit, IFabMvuDrawingBrush>(
                DrawingBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingBrush.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type MvuDrawingBrushModifiers =
    /// <summary>Link a ViewRef to access the direct DrawingBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuDrawingBrush>, value: ViewRef<DrawingBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
