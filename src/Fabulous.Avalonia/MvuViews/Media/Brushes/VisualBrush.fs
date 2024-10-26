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
            WidgetBuilder<'msg, IFabMvuVisualBrush>(
                VisualBrush.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| VisualBrush.Visual.WithValue(content.Compile()) |], ValueNone)
            )
