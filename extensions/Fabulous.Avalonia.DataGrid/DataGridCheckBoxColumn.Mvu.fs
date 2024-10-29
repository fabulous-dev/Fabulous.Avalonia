namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDataGridCheckBoxColumn =
    inherit IFabMvuDataGridColumn
    inherit IFabDataGridCheckBoxColumn

[<AutoOpen>]
module MvuDataGridCheckBoxColumnBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabMvuDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: string, binding: string) =
            WidgetBuilder<'msg, IFabMvuDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<'msg, #IFabMvuControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabMvuDataGridCheckBoxColumn>(
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
        static member DataGridCheckBoxColumn(header: WidgetBuilder<'msg, #IFabMvuControl>, binding: string) =
            WidgetBuilder<'msg, IFabMvuDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )
