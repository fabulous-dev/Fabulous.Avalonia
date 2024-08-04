namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentVisualBrush =
    inherit IFabComponentTileBrush
    inherit IFabVisualBrush

[<AutoOpen>]
module ComponentVisualBrushBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a VisualBrush widget.</summary>
        /// <param name="content">The content of the VisualBrush.</param>
        static member VisualBrush(content: WidgetBuilder<'msg, #IFabComponentVisual>) =
            WidgetBuilder<unit, IFabComponentVisualBrush>(
                VisualBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| VisualBrush.Visual.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentVisualBrushModifiers =
    /// <summary>Link a ViewRef to access the direct VisualBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentVisualBrush>, value: ViewRef<VisualBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
