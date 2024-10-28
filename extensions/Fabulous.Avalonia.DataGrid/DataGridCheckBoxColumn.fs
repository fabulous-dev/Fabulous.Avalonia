namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabDataGridCheckBoxColumn =
    inherit IFabDataGridColumn

module DataGridCheckBoxColumn =
    let WidgetKey = Widgets.register<DataGridCheckBoxColumn>()

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality DataGridCheckBoxColumn.IsThreeStateProperty

type DataGridCheckBoxColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridCheckBoxColumn control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, #IFabDataGridCheckBoxColumn>, value: ViewRef<DataGridCheckBoxColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the IsThreeState property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsThreeState property value.</param>
    [<Extension>]
    static member inline isThreeState(this: WidgetBuilder<'msg, #IFabDataGridCheckBoxColumn>, value: bool) =
        this.AddScalar(DataGridCheckBoxColumn.IsThreeState.WithValue(value))
