namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentGridSplitter =
    inherit IFabComponentTemplatedControl
    inherit IFabGridSplitter

[<AutoOpen>]
module ComponentGridSplitterBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a GridSplitter widget.</summary>
        static member GridSplitter() =
            WidgetBuilder<unit, IFabComponentGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(GridResizeDirection.Auto))

        /// <summary>Creates a GridSplitter widget.</summary>
        /// <param name="resizeDirection">The direction in which the GridSplitter can be resized.</param>
        static member GridSplitter(resizeDirection: GridResizeDirection) =
            WidgetBuilder<unit, IFabComponentGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(resizeDirection))
