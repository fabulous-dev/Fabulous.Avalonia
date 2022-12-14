namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabPen =
    inherit IFabElement

module Pen =
    let WidgetKey = Widgets.register<Pen> ()

    let Brush = Attributes.defineAvaloniaPropertyWidget Pen.BrushProperty

    let Thickness = Attributes.defineAvaloniaPropertyWithEquality Pen.ThicknessProperty

    let DashStyle = Attributes.defineAvaloniaPropertyWidget Pen.DashStyleProperty

    let LineCap = Attributes.defineAvaloniaPropertyWithEquality Pen.LineCapProperty

    let LineJoin = Attributes.defineAvaloniaPropertyWithEquality Pen.LineJoinProperty

    let MiterLimit =
        Attributes.defineAvaloniaPropertyWithEquality Pen.MiterLimitProperty

[<AutoOpen>]
module PenBuilders =
    type Fabulous.Avalonia.View with

        static member Pen(brush: WidgetBuilder<'msg, #IFabBrush>, thickness: float) =
            WidgetBuilder<'msg, IFabPen>(
                Pen.WidgetKey,
                AttributesBundle(
                    StackList.one (Pen.Thickness.WithValue(thickness)),
                    ValueSome [| Pen.Brush.WithValue(brush.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type PenModifiers =
    [<Extension>]
    static member inline dashStyle(this: WidgetBuilder<'msg, #IFabPen>, content: WidgetBuilder<'msg, IFaDashStyle>) =
        this.AddWidget(Pen.DashStyle.WithValue(content.Compile()))

    [<Extension>]
    static member inline lineCap(this: WidgetBuilder<'msg, #IFabPen>, value: PenLineCap) =
        this.AddScalar(Pen.LineCap.WithValue(value))

    [<Extension>]
    static member inline lineJoin(this: WidgetBuilder<'msg, #IFabPen>, value: PenLineJoin) =
        this.AddScalar(Pen.LineJoin.WithValue(value))

    [<Extension>]
    static member inline miterLimit(this: WidgetBuilder<'msg, #IFabPen>, value: float) =
        this.AddScalar(Pen.MiterLimit.WithValue(value))
