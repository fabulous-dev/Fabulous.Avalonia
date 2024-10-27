namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Models.TreeDataGrid
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu

type IFabTreeDataGrid =
    inherit IFabMvuTemplatedControl

module TreeDataGrid =
    let WidgetKey = Widgets.register<TreeDataGrid>()

    let AutoDragDropRows =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.AutoDragDropRowsProperty

    let CanUserResizeColumns =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.CanUserResizeColumnsProperty

    let CanUserSortColumns =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.CanUserSortColumnsProperty

    let ElementFactory =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.ElementFactoryProperty

    let Rows = Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.RowsProperty

    let Scroll =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.ScrollProperty

    let ShowColumnHeaders =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.ShowColumnHeadersProperty

    let Source =
        Attributes.defineAvaloniaPropertyWithEquality TreeDataGrid.SourceProperty

    let RowDragStarted =
        Attributes.defineEvent "TreeDataGrid_RowDragStarted" (fun target -> (target :?> TreeDataGrid).RowDragStarted)

    let RowDragOver =
        Attributes.defineEvent "TreeDataGrid_RowDragOver" (fun target -> (target :?> TreeDataGrid).RowDragOver)

    let RowDrop =
        Attributes.defineEvent "TreeDataGrid_RowDrop" (fun target -> (target :?> TreeDataGrid).RowDrop)

[<AutoOpen>]
module TreeDataGridBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource) =
            WidgetBuilder<'msg, IFabTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source))

        /// <summary>Creates a TreeDataGrid widget.</summary>
        /// <param name="source">The items to display.</param>
        /// <param name="rows">The rows to display.</param>
        static member TreeDataGrid(source: #ITreeDataGridSource, rows: IRows) =
            WidgetBuilder<'msg, IFabTreeDataGrid>(TreeDataGrid.WidgetKey, TreeDataGrid.Source.WithValue(source), TreeDataGrid.Rows.WithValue(rows))

type TreeDataGridModifiers =
    /// <summary>Link a ViewRef to access the direct TreeDataGrid control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: ViewRef<TreeDataGrid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the AutoDragDropRows property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoDragDropRows value.</param>
    [<Extension>]
    static member inline autoDragDropRows(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: bool) =
        this.AddScalar(TreeDataGrid.AutoDragDropRows.WithValue(value))

    /// <summary>Sets the CanUserResizeColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanUserResizeColumns value.</param>
    [<Extension>]
    static member inline canUserResizeColumns(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: bool) =
        this.AddScalar(TreeDataGrid.CanUserResizeColumns.WithValue(value))

    /// <summary>Sets the CanUserSortColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanUserSortColumns value.</param>
    [<Extension>]
    static member inline canUserSortColumns(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: bool) =
        this.AddScalar(TreeDataGrid.CanUserSortColumns.WithValue(value))

    /// <summary>Sets the ElementFactory property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ElementFactory value.</param>
    [<Extension>]
    static member inline elementFactory(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: TreeDataGridElementFactory) =
        this.AddScalar(TreeDataGrid.ElementFactory.WithValue(value))

    /// <summary>Sets the Scroll property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Scroll value.</param>
    [<Extension>]
    static member inline scroll(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: IScrollable) =
        this.AddScalar(TreeDataGrid.Scroll.WithValue(value))

    /// <summary>Sets the ShowColumnHeaders property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowColumnHeaders value.</param>
    [<Extension>]
    static member inline showColumnHeaders(this: WidgetBuilder<'msg, IFabTreeDataGrid>, value: bool) =
        this.AddScalar(TreeDataGrid.ShowColumnHeaders.WithValue(value))

    /// <summary>Listens to the RowDragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is started.</param>
    [<Extension>]
    static member inline onRowDragStarted(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragStartedEventArgs -> 'msg) =
        this.AddScalar(TreeDataGrid.RowDragStarted.WithValue(fn))

    /// <summary>Listens to the RowDragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row drag is over.</param>
    [<Extension>]
    static member inline onRowDragOver(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(TreeDataGrid.RowDragOver.WithValue(fn))

    /// <summary>Listens to the RowDrop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is dropped.</param>
    [<Extension>]
    static member inline onRowDrop(this: WidgetBuilder<'msg, IFabTreeDataGrid>, fn: TreeDataGridRowDragEventArgs -> 'msg) =
        this.AddScalar(TreeDataGrid.RowDrop.WithValue(fn))
