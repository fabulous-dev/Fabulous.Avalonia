namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabUniformGrid =
    inherit IFabPanel

module UniformGrid =
    let WidgetKey = Widgets.register<UniformGrid>()

    let Rows = Attributes.defineAvaloniaPropertyWithEquality UniformGrid.RowsProperty

    let Columns =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.ColumnsProperty

    let FirstColumn =
        Attributes.defineAvaloniaPropertyWithEquality UniformGrid.FirstColumnProperty

type UniformGridModifiers =
    /// <summary>Sets the FirstColumn property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FirstColumn value.</param>
    [<Extension>]
    static member inline firstColumn(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: int) =
        this.AddScalar(UniformGrid.FirstColumn.WithValue(value))

    /// <summary>Link a ViewRef to access the direct UniformGrid control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabUniformGrid>, value: ViewRef<UniformGrid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
