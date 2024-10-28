namespace Fabulous.Avalonia

open Avalonia.Data
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDataGridCheckBoxColumn =
    inherit IFabComponentDataGridColumn
    inherit IFabDataGridCheckBoxColumn

[<AutoOpen>]
module ComponentDataGridCheckBoxColumnBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: IBinding) =
            WidgetBuilder<unit, IFabComponentDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: string) =
            WidgetBuilder<unit, IFabComponentDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<unit, #IFabComponentControl>, binding: IBinding) =
            WidgetBuilder<unit, IFabComponentDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<unit, #IFabComponentControl>, binding: string) =
            WidgetBuilder<unit, IFabComponentDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )