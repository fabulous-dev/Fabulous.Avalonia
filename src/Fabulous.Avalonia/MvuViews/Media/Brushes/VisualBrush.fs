namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuVisualBrush =
    inherit IFabMvuTileBrush
    inherit IFabVisualBrush

[<AutoOpen>]
module MvuVisualBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a VisualBrush widget.</summary>
        /// <param name="content">The content of the VisualBrush.</param>
        static member VisualBrush(content: WidgetBuilder<'msg, #IFabMvuVisual>) =
            WidgetBuilder<unit, IFabMvuVisualBrush>(
                VisualBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| VisualBrush.Visual.WithValue(content.Compile()) |], ValueNone)
            )

type MvuVisualBrushModifiers =
    /// <summary>Link a ViewRef to access the direct VisualBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuVisualBrush>, value: ViewRef<VisualBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
