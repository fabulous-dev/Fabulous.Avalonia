namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabUserControl =
    inherit IFabContentControl

module UserControl =
    let WidgetKey = Widgets.register<UserControl>()

type UserControlModifiers =
    /// <summary>Link a ViewRef to access the direct UserControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabUserControl>, value: ViewRef<UserControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
