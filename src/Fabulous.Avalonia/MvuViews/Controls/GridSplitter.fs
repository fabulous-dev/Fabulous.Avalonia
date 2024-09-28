namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuGridSplitter =
    inherit IFabMvuTemplatedControl
    inherit IFabGridSplitter

[<AutoOpen>]
module MvuGridSplitterBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a GridSplitter widget.</summary>
        static member GridSplitter() =
            WidgetBuilder<unit, IFabMvuGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(GridResizeDirection.Auto))

        /// <summary>Creates a GridSplitter widget.</summary>
        /// <param name="resizeDirection">The direction in which the GridSplitter can be resized.</param>
        static member GridSplitter(resizeDirection: GridResizeDirection) =
            WidgetBuilder<unit, IFabMvuGridSplitter>(GridSplitter.WidgetKey, GridSplitter.ResizeDirection.WithValue(resizeDirection))

type MvuGridSplitterModifiers =
    /// <summary>Link a ViewRef to access the direct GridSplitter control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuGridSplitter>, value: ViewRef<GridSplitter>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
