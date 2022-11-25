namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabGeometryDrawing =
    inherit IFabDrawing

module GeometryDrawing =
    let WidgetKey = Widgets.register<GeometryDrawing>()
    
    let Geometry = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.GeometryProperty
    
    let Brush = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.BrushProperty
    
    let Pen = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.PenProperty
    
[<AutoOpen>]
module GeometryDrawingBuilders =
    type Fabulous.Avalonia.View with
        static member GeometryDrawing(content: WidgetBuilder<'msg, #IFabGeometry>) =
             WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| GeometryDrawing.Geometry.WithValue(content.Compile()) |],
                    ValueNone)
                )
             
[<Extension>]             
type GeometryDrawingModifiers =
    [<Extension>]
    static member inline brush(this: WidgetBuilder<'msg, #IFabGeometryDrawing>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(GeometryDrawing.Brush.WithValue(value.Compile()))
        
    [<Extension>]
    static member inline pen(this: WidgetBuilder<'msg, #IFabGeometryDrawing>, value: WidgetBuilder<'msg, #IFabPen>) =
        this.AddWidget(GeometryDrawing.Brush.WithValue(value.Compile()))
