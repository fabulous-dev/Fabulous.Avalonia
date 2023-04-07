namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToolTip =
    inherit IFabContentControl

module ToolTip =
    let WidgetKey = Widgets.register<ToolTip>()

    let TipString =
        Attributes.defineAvaloniaProperty<string, obj> ToolTip.TipProperty box ScalarAttributeComparers.equalityCompare

    let TipWidget = Attributes.defineAvaloniaPropertyWidget ToolTip.TipProperty

    let IsOpen = Attributes.defineAvaloniaPropertyWithEquality ToolTip.IsOpenProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.PlacementProperty

    let HorizontalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.HorizontalOffsetProperty

    let VerticalOffset =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.VerticalOffsetProperty

    let ShowDelay =
        Attributes.defineAvaloniaPropertyWithEquality ToolTip.ShowDelayProperty

[<Extension>]
type ToolTipModifiers =
    [<Extension>]
    static member inline tooltip(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(ToolTip.TipString.WithValue(value))

    [<Extension>]
    static member inline tooltip(this: WidgetBuilder<'msg, #IFabControl>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ToolTip.TipWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline tooltipIsOpen(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(ToolTip.IsOpen.WithValue(value))

    [<Extension>]
    static member inline tooltipPlacement(this: WidgetBuilder<'msg, #IFabControl>, value: PlacementMode) =
        this.AddScalar(ToolTip.Placement.WithValue(value))

    [<Extension>]
    static member inline tooltipHorizontalOffset(this: WidgetBuilder<'msg, #IFabControl>, value: double) =
        this.AddScalar(ToolTip.HorizontalOffset.WithValue(value))

    [<Extension>]
    static member inline tooltipVerticalOffset(this: WidgetBuilder<'msg, #IFabControl>, value: double) =
        this.AddScalar(ToolTip.VerticalOffset.WithValue(value))

    [<Extension>]
    static member inline tooltipShowDelay(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(ToolTip.ShowDelay.WithValue(value))
