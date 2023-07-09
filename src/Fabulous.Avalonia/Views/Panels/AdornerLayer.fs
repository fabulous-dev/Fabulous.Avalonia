namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabAdornerLayer =
    inherit IFabCanvas

module AdornerLayer =
    let WidgetKey = Widgets.register<AdornerLayer>()

    let AdornedElement =
        Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornedElementProperty

    let Adorner = Attributes.defineAvaloniaPropertyWidget AdornerLayer.AdornerProperty

    let IsIsClipEnabled =
        Attributes.defineAvaloniaPropertyWithEquality AdornerLayer.IsClipEnabledProperty

[<Extension>]
type AdornerLayerAttachedModifiers =
    [<Extension>]
    static member inline adorner(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(AdornerLayer.Adorner.WithValue(widget.Compile()))

    [<Extension>]
    static member inline adornedElement(this: WidgetBuilder<'msg, #IFabVisual>, widget: WidgetBuilder<'msg, #IFabVisual>) =
        this.AddWidget(AdornerLayer.AdornedElement.WithValue(widget.Compile()))

    [<Extension>]
    static member inline isClipEnabled(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(AdornerLayer.IsIsClipEnabled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct AdornerLayer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAdornerLayer>, value: ViewRef<AdornerLayer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
