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
        static member DrawingBrush(source: WidgetBuilder<'msg, #IFabComponentDrawing>) =
            WidgetBuilder<unit, IFabComponentDrawingBrush>(
                DrawingBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| DrawingBrush.Drawing.WithValue(source.Compile()) |], ValueNone)
            )

type ComponentDrawingBrushModifiers =
    /// <summary>Link a ViewRef to access the direct DrawingBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentDrawingBrush>, value: ViewRef<DrawingBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
