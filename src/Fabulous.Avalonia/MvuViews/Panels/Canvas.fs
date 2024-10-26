namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuCanvas =
    inherit IFabMvuPanel
    inherit IFabCanvas

[<AutoOpen>]
module MvuCanvasBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Canvas widget.</summary>
        static member Canvas() =
            CollectionBuilder<unit, IFabMvuCanvas, IFabMvuControl>(Canvas.WidgetKey, MvuPanel.Children)

        /// <summary>Creates a Canvas widget.</summary>
        /// <param name="viewRef">The ViewRef instance that will receive access to the underlying control.</param>
        static member Canvas(viewRef: ViewRef<Canvas>) =
            WidgetBuilder<unit, IFabMvuCanvas>(Canvas.WidgetKey, ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox))
