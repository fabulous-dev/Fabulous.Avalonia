namespace Fabulous.Avalonia

open Fabulous

[<AutoOpen>]
module MvuUniformGridBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a UniformGrid widget.</summary>
        /// <param name="cols">The number of columns in the grid.</param>
        /// <param name="rows">The number of rows in the grid.</param>
        static member UniformGrid(?cols: int, ?rows: int) =
            match cols, rows with
            | Some cols, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    MvuPanel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(rows)
                )
            | Some cols, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    MvuPanel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(0)
                )

            | None, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    MvuPanel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(rows)
                )

            | None, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    MvuPanel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(0)
                )