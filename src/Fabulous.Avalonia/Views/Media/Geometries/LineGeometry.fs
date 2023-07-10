namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Media
open Fabulous

type IFabLineGeometry =
    inherit IFabGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LineGeometry.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LineGeometry.EndPointProperty

[<AutoOpen>]
module LineGeometryBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a LineGeometry widget</summary>
        /// <param name="startPoint">The start point of the line</param>
        /// <param name="endPoint">The end point of the line</param>
        static member LineGeometry(startPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )
