namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Fabulous

type IFabShape =
    inherit IFabControl

module Shape =

    let Fill = Attributes.defineAvaloniaPropertyWidget Shape.FillProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Shape.StretchProperty

    let Stroke = Attributes.defineAvaloniaPropertyWidget Shape.StrokeProperty

    let StrokeDashCap =
        Attributes.defineSimpleScalarWithEquality<float list> "Shape_StrokeDashCap" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Shape.StrokeDashArrayProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(Shape.StrokeDashArrayProperty, coll) |> ignore)

    let StrokeDashOffset =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeDashOffsetProperty

    let StrokeThickness =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeThicknessProperty

    let StrokeLineCap =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeLineCapProperty

    let StrokeJoin =
        Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeJoinProperty

[<Extension>]
type ShapeModifiers =
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, brush: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.Fill.WithValue(brush.Compile()))

    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabShape>, stretch: Stretch) =
        this.AddScalar(Shape.Stretch.WithValue(stretch))

    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, brush: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.Stroke.WithValue(brush.Compile()))

    [<Extension>]
    static member inline strokeDashCap(this: WidgetBuilder<'msg, #IFabShape>, points: float list) =
        this.AddScalar(Shape.StrokeDashCap.WithValue(points))

    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabShape>, offset: float) =
        this.AddScalar(Shape.StrokeDashOffset.WithValue(offset))

    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabShape>, thickness: float) =
        this.AddScalar(Shape.StrokeThickness.WithValue(thickness))

    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabShape>, cap: PenLineCap) =
        this.AddScalar(Shape.StrokeLineCap.WithValue(cap))

    [<Extension>]
    static member inline strokeJoin(this: WidgetBuilder<'msg, #IFabShape>, join: PenLineJoin) =
        this.AddScalar(Shape.StrokeJoin.WithValue(join))
