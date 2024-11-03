namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Models.TreeDataGrid
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components

module ComponentTreeDataGrid =
    let RowDragStarted =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDragStarted" (fun target -> (target :?> TreeDataGrid).RowDragStarted)

    let RowDragOver =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDragOver" (fun target -> (target :?> TreeDataGrid).RowDragOver)

    let RowDrop =
        Attributes.defineEventNoDispatch "TreeDataGrid_RowDrop" (fun target -> (target :?> TreeDataGrid).RowDrop)

type ComponentTreeDataGridModifiers =
    /// <summary>Listens to the RowDragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is started.</param>
    [<Extension>]
    static member inline onRowDragStarted(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragStartedEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDragStarted.WithValue(fn))

    /// <summary>Listens to the RowDragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is over.</param>
    [<Extension>]
    static member inline onRowDragOver(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDragOver.WithValue(fn))

    /// <summary>Listens to the RowDrop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is dropped.</param>
    [<Extension>]
    static member inline onRowDrop(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> unit) =
        this.AddScalar(ComponentTreeDataGrid.RowDrop.WithValue(fn))
