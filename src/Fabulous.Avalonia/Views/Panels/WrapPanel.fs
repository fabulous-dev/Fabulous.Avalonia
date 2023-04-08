namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabWrapPanel =
    inherit IFabPanel

module WrapPanel =
    let WidgetKey = Widgets.register<WrapPanel>()

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.OrientationProperty

    let ItemWidth =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemWidthProperty

    let ItemHeight =
        Attributes.defineAvaloniaPropertyWithEquality WrapPanel.ItemHeightProperty

[<AutoOpen>]
module WrapPanelBuilders =
    type Fabulous.Avalonia.View with

        static member VWrap<'msg>() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, Panel.Children, WrapPanel.Orientation.WithValue(Orientation.Vertical))

        static member HWrap<'msg>() =
            CollectionBuilder<'msg, IFabWrapPanel, IFabControl>(WrapPanel.WidgetKey, Panel.Children, WrapPanel.Orientation.WithValue(Orientation.Horizontal))

[<Extension>]
type WrapPanelModifiers =
    [<Extension>]
    static member inline itemWidth(this: WidgetBuilder<'msg, #IFabWrapPanel>, itemWidth: float) =
        this.AddScalar(WrapPanel.ItemWidth.WithValue(itemWidth))

    [<Extension>]
    static member inline itemHeight(this: WidgetBuilder<'msg, #IFabWrapPanel>, itemHeight: float) =
        this.AddScalar(WrapPanel.ItemHeight.WithValue(itemHeight))

    /// <summary>Link a ViewRef to access the direct WrapPanel control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabWrapPanel>, value: ViewRef<WrapPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
