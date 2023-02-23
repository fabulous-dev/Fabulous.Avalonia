namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabShape =
    inherit IFabControl

module Shape =

    let FillWidget = Attributes.defineAvaloniaPropertyWidget Shape.FillProperty
    
    let Fill = Attributes.defineAvaloniaPropertyWithEquality Shape.FillProperty

    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Shape.StretchProperty

    let StrokeWidget = Attributes.defineAvaloniaPropertyWidget Shape.StrokeProperty
    
    let Stroke = Attributes.defineAvaloniaPropertyWithEquality Shape.StrokeProperty

    let StrokeDashArray =
        Attributes.defineSimpleScalarWithEquality<float list> "Shape_StrokeDashArray" (fun _ newValueOpt node ->
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
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.FillWidget.WithValue(content.Compile()))
        
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabShape>, brush: string) =
        this.AddScalar(Shape.Fill.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabShape>, value: Stretch) =
        this.AddScalar(Shape.Stretch.WithValue(value))

    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Shape.StrokeWidget.WithValue(content.Compile()))
        
    [<Extension>]
    static member inline stroke(this: WidgetBuilder<'msg, #IFabShape>, brush: string) =
        this.AddScalar(Shape.Stroke.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline strokeDashCap(this: WidgetBuilder<'msg, #IFabShape>, value: float list) =
        this.AddScalar(Shape.StrokeDashArray.WithValue(value))

    [<Extension>]
    static member inline strokeDashOffset(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeDashOffset.WithValue(value))

    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IFabShape>, value: float) =
        this.AddScalar(Shape.StrokeThickness.WithValue(value))

    [<Extension>]
    static member inline strokeLineCap(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineCap) =
        this.AddScalar(Shape.StrokeLineCap.WithValue(value))

    [<Extension>]
    static member inline strokeJoin(this: WidgetBuilder<'msg, #IFabShape>, value: PenLineJoin) =
        this.AddScalar(Shape.StrokeJoin.WithValue(value))
