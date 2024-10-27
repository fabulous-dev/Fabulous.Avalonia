namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabHeaderedContentControl =
    inherit IFabContentControl

module HeaderedContentControl =
    let WidgetKey = Widgets.register<HeaderedContentControl>()

    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj> HeaderedContentControl.HeaderProperty box ScalarAttributeComparers.equalityCompare

    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget HeaderedContentControl.HeaderProperty

type HeaderedContentControlModifiers =

    /// <summary>Link a ViewRef to access the direct HeaderedContentControl control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHeaderedContentControl>, value: ViewRef<HeaderedContentControl>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
