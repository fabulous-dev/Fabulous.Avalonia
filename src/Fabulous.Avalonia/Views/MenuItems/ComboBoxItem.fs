namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous

type IFabComboBoxItem =
    inherit IFabListBoxItem

module ComboBoxItem =
    let WidgetKey = Widgets.register<ComboBoxItem>()

type ComboBoxItemModifiers =
    /// <summary>Link a ViewRef to access the direct MenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComboBoxItem>, value: ViewRef<ComboBoxItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
