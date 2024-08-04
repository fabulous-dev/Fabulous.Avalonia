namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentCanvas =
    inherit IFabComponentPanel
    inherit IFabCanvas

[<AutoOpen>]
module ComponentCanvasBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Canvas widget.</summary>
        static member Canvas() =
            CollectionBuilder<unit, IFabComponentCanvas, IFabComponentControl>(Canvas.WidgetKey, ComponentPanel.Children)

        /// <summary>Creates a Canvas widget.</summary>
        /// <param name="viewRef">The ViewRef instance that will receive access to the underlying control.</param>
        static member Canvas(viewRef: ViewRef<Canvas>) =
            WidgetBuilder<unit, IFabComponentCanvas>(Canvas.WidgetKey, ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox))

type ComponentCanvasModifiers =
    /// <summary>Link a ViewRef to access the direct Canvas control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentCanvas>, value: ViewRef<Canvas>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
