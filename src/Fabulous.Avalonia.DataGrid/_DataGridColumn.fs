namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia

type IFabDataGridColumn =
    inherit IFabObject

module DataGridColumn =
    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget DataGridColumn.HeaderProperty

    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj> DataGridColumn.HeaderProperty box ScalarAttributeComparers.equalityCompare

    let CellTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.CellThemeProperty

    let Width =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.WidthProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality DataGridColumn.IsVisibleProperty

[<Extension>]
type DataGridColumnModifiers =

    [<Extension>]
    static member inline cellTheme(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: ControlTheme) =
        this.AddScalar(DataGridColumn.CellTheme.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: DataGridLength) =
        this.AddScalar(DataGridColumn.Width.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: float) =
        this.AddScalar(DataGridColumn.Width.WithValue(DataGridLength(value)))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabDataGridColumn>, value: bool) =
        this.AddScalar(DataGridColumn.IsVisible.WithValue(value))
