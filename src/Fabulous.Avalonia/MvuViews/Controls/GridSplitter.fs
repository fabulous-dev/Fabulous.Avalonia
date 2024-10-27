namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuGridSplitter =
    inherit IFabMvuTemplatedControl
    inherit IFabGridSplitter

[<AutoOpen>]
module MvuGridSplitterBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a GridSplitter widget.</summary>
        static member GridSplitter() =
            WidgetBuilder<'msg, IFabMvuGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(GridResizeDirection.Auto))

        /// <summary>Creates a GridSplitter widget.</summary>
        /// <param name="resizeDirection">The direction in which the GridSplitter can be resized.</param>
        static member GridSplitter(resizeDirection: GridResizeDirection) =
            WidgetBuilder<'msg, IFabMvuGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(resizeDirection))
