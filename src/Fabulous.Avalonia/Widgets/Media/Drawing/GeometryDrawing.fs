namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabGeometryDrawing =
    inherit IFabDrawing

module GeometryDrawing =
    let WidgetKey = Widgets.register<GeometryDrawing>()

    let Geometry =
        Attributes.defineAvaloniaPropertyWithEquality GeometryDrawing.GeometryProperty

    let GeometryWidget =
        Attributes.defineAvaloniaPropertyWidget GeometryDrawing.GeometryProperty

    let Brush = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.BrushProperty

    let Pen = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.PenProperty

[<AutoOpen>]
module GeometryDrawingBuilders =
    type Fabulous.Avalonia.View with

        static member GeometryDrawing(geometry: string, pen: WidgetBuilder<'msg, #IFabPen>, brush: WidgetBuilder<'msg, #IFabBrush>) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry))),
                    ValueSome
                        [| GeometryDrawing.Brush.WithValue(brush.Compile())
                           GeometryDrawing.Pen.WithValue(pen.Compile()) |],
                    ValueNone
                )
            )

        static member GeometryDrawing
            (
                geometry: WidgetBuilder<'msg, #IFabGeometry>,
                pen: WidgetBuilder<'msg, #IFabPen>,
                brush: WidgetBuilder<'msg, #IFabBrush>
            ) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| GeometryDrawing.GeometryWidget.WithValue(geometry.Compile())
                           GeometryDrawing.Brush.WithValue(brush.Compile())
                           GeometryDrawing.Pen.WithValue(pen.Compile()) |],
                    ValueNone
                )
            )
