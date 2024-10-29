namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Models.TreeDataGrid
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components

type IFabComponentTreeDataGrid =
    inherit IFabComponentTemplatedControl
    inherit IFabTreeDataGrid

module ComponentTreeDataGrid =
    let RowDragStarted =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDragStarted" (fun target -> (target :?> TreeDataGrid).RowDragStarted)

    let RowDragOver =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDragOver" (fun target -> (target :?> TreeDataGrid).RowDragOver)

    let RowDrop =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDrop" (fun target -> (target :?> TreeDataGrid).RowDrop)

[<AutoOpen>]
module TreeDataGridBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource) =
            WidgetBuilder<unit, IFabComponentTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source))

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        /// <param name="rows">The rows to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource, rows: IRows) =
            WidgetBuilder<unit, IFabComponentTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source), TreeDataGrid.Rows.WithValue(rows))

type ComponentTreeDataGridModifiers =
    /// <summary>Listens to the RowDragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is started.</param>
    [<Extension>]
    static member inline onRowDragStarted(this: WidgetBuilder<unit, IFabComponentTreeDataGrid>, fn: TreeDataGridRowDragStartedEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDragStarted.WithValue(fn))

    /// <summary>Listens to the RowDragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is over.</param>
    [<Extension>]
    static member inline onRowDragOver(this: WidgetBuilder<unit, IFabComponentTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDragOver.WithValue(fn))

    /// <summary>Listens to the RowDrop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is dropped.</param>
    [<Extension>]
    static member inline onRowDrop(this: WidgetBuilder<unit, IFabComponentTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDrop.WithValue(fn))
