namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabAdornerLayer =
    inherit IFabCanvas

module AdornerLayer =
    let WidgetKey = Widgets.register<AdornerLayer>()

    let Adorner = Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornerProperty

[<Extension>]
type AdornerLayerModifiers =
    [<Extension>]
    static member inline adorner(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(AdornerLayer.Adorner.WithValue(widget.Compile()))

    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
