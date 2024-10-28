namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Data
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

type IFabMvuDataGridTextColumn =
    inherit IFabMvuDataGridColumn

[<AutoOpen>]
module MvuDataGridTextColumnBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabMvuDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: string, binding: string) =
            WidgetBuilder<'msg, IFabMvuDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(Binding(binding))
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        /// <param name="header">The column header.</param>
        /// <param name="binding">The column binding.</param>
        static member DataGridTextColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabMvuDataGridTextColumn>(
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
        static member DataGridTextColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: string) =
            WidgetBuilder<'msg, IFabMvuDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(Binding(binding))),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

type MvuDataGridTextColumnExtraModifiers =
    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabMvuDataGridTextColumn>, value: IBrush) =
        this.AddScalar(DataGridTextColumn.Foreground.WithValue(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabMvuDataGridTextColumn>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(DataGridTextColumn.ForegroundWidget.WithValue(value.Compile()))
    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabMvuDataGridTextColumn>, value: Color) =
        MvuDataGridTextColumnExtraModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Set the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground property value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabMvuDataGridTextColumn>, value: string) =
        MvuDataGridTextColumnExtraModifiers.foreground(this, View.SolidColorBrush(Color.Parse(value)))
