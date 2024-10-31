namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentUniformGrid =
    inherit IFabComponentPanel
    inherit IFabUniformGrid

[<AutoOpen>]
module ComponentUniformGridBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a UniformGrid widget.</summary>
        /// <param name="cols">The number of columns in the grid.</param>
        /// <param name="rows">The number of rows in the grid.</param>
        static member UniformGrid(?cols: int, ?rows: int) =
            match cols, rows with
            | Some cols, Some rows ->
                CollectionBuilder<unit, IFabComponentUniformGrid, IFabComponentControl>(
                    UniformGrid.WidgetKey,
                    ComponentPanel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(rows)
                )
            | Some cols, None ->
                CollectionBuilder<unit, IFabComponentUniformGrid, IFabComponentControl>(
                    UniformGrid.WidgetKey,
                    ComponentPanel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(0)
                )

            | None, Some rows ->
                CollectionBuilder<unit, IFabComponentUniformGrid, IFabComponentControl>(
                    UniformGrid.WidgetKey,
                    ComponentPanel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(rows)
                )

            | None, None ->
                CollectionBuilder<unit, IFabComponentUniformGrid, IFabComponentControl>(
                    UniformGrid.WidgetKey,
                    ComponentPanel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(0)
                )
