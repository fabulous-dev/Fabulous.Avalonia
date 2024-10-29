namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Models.TreeDataGrid
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu

type IFabMvuTreeDataGrid =
    inherit IFabMvuTemplatedControl
    inherit IFabTreeDataGrid

module MvuTreeDataGrid =
    let RowDragStarted =
        Attributes.defineEvent "TreeDataGrid_RowDragStarted" (fun target -> (target :?> TreeDataGrid).RowDragStarted)

    let RowDragOver =
        Attributes.defineEvent "TreeDataGrid_RowDragOver" (fun target -> (target :?> TreeDataGrid).RowDragOver)

    let RowDrop =
        Attributes.defineEvent "TreeDataGrid_RowDrop" (fun target -> (target :?> TreeDataGrid).RowDrop)

[<AutoOpen>]
module MvuTreeDataGridBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource) =
            WidgetBuilder<'msg, IFabMvuTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source))

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        /// <param name="rows">The rows to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource, rows: IRows) =
            WidgetBuilder<'msg, IFabMvuTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source), TreeDataGrid.Rows.WithValue(rows))

type MvuTreeDataGridModifiers =
    /// <summary>Listens to the RowDragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is started.</param>
    [<Extension>]
    static member inline onRowDragStarted(this: WidgetBuilder<'msg, IFabMvuTreeDataGrid>, fn: TreeDataGridRowDragStartedEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDragStarted.WithValue(fn))

    /// <summary>Listens to the RowDragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is over.</param>
    [<Extension>]
    static member inline onRowDragOver(this: WidgetBuilder<'msg, IFabMvuTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDragOver.WithValue(fn))

    /// <summary>Listens to the RowDrop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is dropped.</param>
    [<Extension>]
    static member inline onRowDrop(this: WidgetBuilder<'msg, IFabMvuTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(MvuTreeDataGrid.RowDrop.WithValue(fn))
