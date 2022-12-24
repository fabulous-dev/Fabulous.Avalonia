namespace Fabulous.Avalonia

open Avalonia.Controls.Shapes
open Avalonia
open Fabulous

type IFabLine =
    inherit IFabShape

module Line =
    let WidgetKey = Widgets.register<Line> ()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality Line.StartPointProperty

    let EndPoint = Attributes.defineAvaloniaPropertyWithEquality Line.EndPointProperty

[<AutoOpen>]
module LineBuilders =
    type Fabulous.Avalonia.View with

        static member Line(starPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabLine>(
                Line.WidgetKey,
                Line.StartPoint.WithValue(starPoint),
                Line.EndPoint.WithValue(endPoint)
            )
