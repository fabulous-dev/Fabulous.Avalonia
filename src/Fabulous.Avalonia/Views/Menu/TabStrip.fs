namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabTabStrip =
    inherit IFabSelectingItemsControl

module TabStrip =
    let WidgetKey = Widgets.register<TabStrip>()

type TabStripModifiers =
    /// <summary>Link a ViewRef to access the direct TabStrip control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTabStrip>, value: ViewRef<TabStrip>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
