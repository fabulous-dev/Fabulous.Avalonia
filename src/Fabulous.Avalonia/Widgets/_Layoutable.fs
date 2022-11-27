namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Layout
open Fabulous

type IFabLayoutable =
    inherit IFabVisual

module Layoutable =
    let HorizontalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.HorizontalAlignmentProperty

    let VerticalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.VerticalAlignmentProperty

    let Margin = Attributes.defineAvaloniaPropertyWithEquality Layoutable.MarginProperty
    let Height = Attributes.defineAvaloniaPropertyWithEquality Layoutable.HeightProperty
    let Width = Attributes.defineAvaloniaPropertyWithEquality Layoutable.WidthProperty

[<Extension>]
type LayoutableModifiers =
    [<Extension>]
    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: HorizontalAlignment) =
        this.AddScalar(Layoutable.HorizontalAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: VerticalAlignment) =
        this.AddScalar(Layoutable.VerticalAlignment.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, value: Thickness) =
        this.AddScalar(Layoutable.Margin.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Height.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Width.WithValue(value))

    // size
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabLayoutable>, width: float, height: float) =
        this.width(width).height (height)

[<Extension>]
type LayoutableExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.horizontalAlignment (HorizontalAlignment.Center)

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.verticalAlignment (VerticalAlignment.Center)

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.centerHorizontal().centerVertical ()

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, uniformValue: float) =
        this.margin (Thickness(uniformValue))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, horizontal: float, vertical: float) =
        this.margin (Thickness(horizontal, vertical))

    [<Extension>]
    static member inline margin
        (
            this: WidgetBuilder<'msg, #IFabLayoutable>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        this.margin (Thickness(left, top, right, bottom))
