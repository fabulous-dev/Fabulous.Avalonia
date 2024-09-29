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

type MvuCanvasModifiers =
    /// <summary>Link a ViewRef to access the direct Canvas control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuCanvas>, value: ViewRef<Canvas>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
