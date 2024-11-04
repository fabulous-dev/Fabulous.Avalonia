namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open System.Runtime.CompilerServices

type IFabReversibleStackPanel =
    inherit IFabStackPanel

module ReversibleStackPanel =
    let WidgetKey = Widgets.register<ReversibleStackPanel>()

    let ReverseOrder =
        Attributes.defineAvaloniaPropertyWithEquality ReversibleStackPanel.ReverseOrderProperty

type ReversibleStackPanelModifiers =
    /// <summary>Link a ViewRef to access the direct ReversibleStackPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabReversibleStackPanel>, value: ViewRef<ReversibleStackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
