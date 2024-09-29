namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingBrush =
    inherit IFabTileBrush

module DrawingBrush =
    let WidgetKey = Widgets.register<DrawingBrush>()

    let Drawing = Attributes.defineAvaloniaPropertyWidget DrawingBrush.DrawingProperty

type DrawingBrushModifiers =
    /// <summary>Link a ViewRef to access the direct DrawingBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabDrawingBrush>, value: ViewRef<DrawingBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
