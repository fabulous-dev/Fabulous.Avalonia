namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabLineGeometry =
    inherit IFabGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()
    
    let StartPoint = Attributes.defineAvaloniaPropertyWithEquality LineGeometry.StartPointProperty
    
    let EndPoint = Attributes.defineAvaloniaPropertyWithEquality LineGeometry.EndPointProperty
        
[<AutoOpen>]
module LineGeometryBuilders =
    type Fabulous.Avalonia.View with
        static member LineGeometry(startPoint: Point, endPoint: Point) =
             WidgetBuilder<'msg, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                AttributesBundle(
                    StackList.two(LineGeometry.StartPoint.WithValue(startPoint), LineGeometry.EndPoint.WithValue(endPoint)),
                    ValueNone,
                    ValueNone)
                )
