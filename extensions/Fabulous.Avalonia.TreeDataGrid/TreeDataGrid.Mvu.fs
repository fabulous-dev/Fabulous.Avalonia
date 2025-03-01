﻿namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuTreeDataGrid =
    let RowDragStarted =
        Attributes.Mvu.defineEvent "TreeDataGrid_RowDragStarted" (fun target -> (target :?> TreeDataGrid).RowDragStarted)

    let RowDragOver =
        Attributes.Mvu.defineEvent "TreeDataGrid_RowDragOver" (fun target -> (target :?> TreeDataGrid).RowDragOver)

    let RowDrop =
        Attributes.Mvu.defineEvent "TreeDataGrid_RowDrop" (fun target -> (target :?> TreeDataGrid).RowDrop)

type MvuTreeDataGridModifiers =
    /// <summary>Listens to the RowDragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is started.</param>
    [<Extension>]
    static member inline onRowDragStarted(this: WidgetBuilder<'msg, #IFabTreeDataGrid>, fn: TreeDataGridRowDragStartedEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDragStarted.WithValue(fn))

    /// <summary>Listens to the RowDragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is over.</param>
    [<Extension>]
    static member inline onRowDragOver(this: WidgetBuilder<'msg, #IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDragOver.WithValue(fn))

    /// <summary>Listens to the RowDrop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is dropped.</param>
    [<Extension>]
    static member inline onRowDrop(this: WidgetBuilder<'msg, #IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDrop.WithValue(fn))
