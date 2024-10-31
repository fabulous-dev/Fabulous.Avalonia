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
