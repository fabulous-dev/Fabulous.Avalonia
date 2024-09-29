namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabVisualBrush =
    inherit IFabTileBrush

module VisualBrush =
    let WidgetKey = Widgets.register<VisualBrush>()

    let Visual = Attributes.defineAvaloniaPropertyWidget VisualBrush.VisualProperty

type VisualBrushModifiers =
    /// <summary>Link a ViewRef to access the direct VisualBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabVisualBrush>, value: ViewRef<VisualBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
