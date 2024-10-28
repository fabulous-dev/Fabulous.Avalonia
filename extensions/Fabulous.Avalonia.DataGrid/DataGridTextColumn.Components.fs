namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Data
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components
open Fabulous.StackAllocatedCollections.StackList
open type Fabulous.Avalonia.Components.View

type IFabComponentDataGridTextColumn =
    inherit IFabComponentDataGridColumn

[<AutoOpen>]
module ComponentWidgetKeyDataGridTextColumnBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: IBinding) =
            WidgetBuilder<unit, IFabComponentDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: string) =
            WidgetBuilder<unit, IFabComponentDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: WidgetBuilder<unit, #IFabComponentControl>, binding: IBinding) =
            WidgetBuilder<unit, IFabComponentDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: WidgetBuilder<unit, #IFabComponentControl>, binding: string) =
            WidgetBuilder<unit, IFabComponentDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

type ComponentDataGridTextColumnExtraModifiers =
    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, IFabComponentDataGridTextColumn>, value: IBrush) =
        this.AddScalar(DataGridTextColumn.Foreground.WithValue(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, IFabComponentDataGridTextColumn>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(DataGridTextColumn.ForegroundWidget.WithValue(value.Compile()))
    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, IFabComponentDataGridTextColumn>, value: Color) =
        ComponentDataGridTextColumnExtraModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<unit, IFabComponentDataGridTextColumn>, value: string) =
        ComponentDataGridTextColumnExtraModifiers.foreground(this, View.SolidColorBrush(Color.Parse(value)))