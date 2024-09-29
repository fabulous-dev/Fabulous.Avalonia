namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabBold =
    inherit IFabSpan

module Bold =
    let WidgetKey = Widgets.register<Bold>()

type BoldModifiers =
    /// <summary>Link a ViewRef to access the direct Bold control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBold>, value: ViewRef<Bold>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
