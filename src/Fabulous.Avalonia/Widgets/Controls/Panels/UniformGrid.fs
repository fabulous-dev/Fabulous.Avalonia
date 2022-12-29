namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabUniformGrid =
    inherit IFabPanel

module UniformGrid =
    let WidgetKey = Widgets.register<UniformGrid> ()

    let Rows = Attributes.defineAvaloniaPropertyWithEquality UniformGrid.RowsProperty

    let Columns =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.ColumnsProperty

    let FirstColumn =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.FirstColumnProperty

[<AutoOpen>]
module UniformGridBuilders =
    type Fabulous.Avalonia.View with

        static member UniformGrid<'msg>(?cols: int, ?rows: int) =
            match cols, rows with
            | Some cols, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(rows)
                )
            | Some cols, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(cols),
                    UniformGrid.Rows.WithValue(0)
                )

            | None, Some rows ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(rows)
                )

            | None, None ->
                CollectionBuilder<'msg, IFabUniformGrid, IFabControl>(
                    UniformGrid.WidgetKey,
                    Panel.Children,
                    UniformGrid.Columns.WithValue(0),
                    UniformGrid.Rows.WithValue(0)
                )

[<Extension>]
type UniformGridModifiers =
    [<Extension>]
    static member inline firstColumn(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: int) =
        this.AddScalar(UniformGrid.FirstColumn.WithValue(value))
