namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Layout
open Fabulous

type IFabLayoutable =
    inherit IFabVisual

module Layoutable =
    let DesiredSize =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.DesiredSizeProperty

    let Width = Attributes.defineAvaloniaPropertyWithEquality Layoutable.WidthProperty

    let Height = Attributes.defineAvaloniaPropertyWithEquality Layoutable.HeightProperty

    let MinWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinWidthProperty

    let MinHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinHeightProperty

    let MaxWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxWidthProperty

    let MaxHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxHeightProperty

    let Margin = Attributes.defineAvaloniaPropertyWithEquality Layoutable.MarginProperty

    let HorizontalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.HorizontalAlignmentProperty

    let VerticalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.VerticalAlignmentProperty

    let UseLayoutRounding =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.UseLayoutRoundingProperty

    let EffectiveViewportChanged =
        Attributes.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        Attributes.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

[<Extension>]
type LayoutableModifiers =
    [<Extension>]
    static member inline desiredSize(this: WidgetBuilder<'msg, #IFabLayoutable>, value: Size) =
        this.AddScalar(Layoutable.DesiredSize.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Width.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Height.WithValue(value))

    [<Extension>]
    static member inline minWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinWidth.WithValue(value))

    [<Extension>]
    static member inline minHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinHeight.WithValue(value))

    [<Extension>]
    static member inline maxWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxWidth.WithValue(value))

    [<Extension>]
    static member inline maxHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxHeight.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, value: Thickness) =
        this.AddScalar(Layoutable.Margin.WithValue(value))

    [<Extension>]
    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: HorizontalAlignment) =
        this.AddScalar(Layoutable.HorizontalAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: VerticalAlignment) =
        this.AddScalar(Layoutable.VerticalAlignment.WithValue(value))

    [<Extension>]
    static member inline useLayoutRounding(this: WidgetBuilder<'msg, #IFabLayoutable>, value: bool) =
        this.AddScalar(Layoutable.UseLayoutRounding.WithValue(value))

    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<'msg, #IFabLayoutable>, onEffectiveViewportChanged: Rect -> 'msg) =
        this.AddScalar(Layoutable.EffectiveViewportChanged.WithValue(fun args -> onEffectiveViewportChanged args.EffectiveViewport |> box))

    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<'msg, #IFabLayoutable>, onLayoutUpdated: 'msg) =
        this.AddScalar(Layoutable.LayoutUpdated.WithValue(onLayoutUpdated))

[<Extension>]
type LayoutableExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.horizontalAlignment(HorizontalAlignment.Center)

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.verticalAlignment(VerticalAlignment.Center)

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.centerHorizontal().centerVertical()

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, uniformValue: float) = this.margin(Thickness(uniformValue))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, horizontal: float, vertical: float) =
        this.margin(Thickness(horizontal, vertical))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, left: float, top: float, right: float, bottom: float) =
        this.margin(Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabLayoutable>, width: float, height: float) = this.width(width).height(height)
