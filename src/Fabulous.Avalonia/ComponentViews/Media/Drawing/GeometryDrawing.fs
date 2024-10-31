namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentGeometryDrawing =
    inherit IFabComponentDrawing
    inherit IFabGeometryDrawing

[<AutoOpen>]
module ComponentGeometryDrawingBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<'msg, #IFabComponentGeometry>, brush: WidgetBuilder<'msg, #IFabComponentBrush>) =
            WidgetBuilder<'msg, IFabComponentGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome
                        [| GeometryDrawing.BrushWidget.WithValue(brush.Compile())
                           GeometryDrawing.GeometryWidget.WithValue(geometry.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: WidgetBuilder<'msg, #IFabComponentBrush>) =
            WidgetBuilder<'msg, IFabComponentGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry))),
                    ValueSome [| GeometryDrawing.BrushWidget.WithValue(brush.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: Color) =
            View.GeometryDrawing(geometry, View.SolidColorBrush(brush))

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: string) =
            View.GeometryDrawing(geometry, View.SolidColorBrush(brush))

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<unit, #IFabComponentGeometry>, brush: Color) =
            View.GeometryDrawing(geometry, View.SolidColorBrush(brush))

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<unit, #IFabComponentGeometry>, brush: string) =
            View.GeometryDrawing(geometry, View.SolidColorBrush(brush))

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<'msg, #IFabComponentGeometry>, brush: IBrush) =
            WidgetBuilder<'msg, IFabComponentGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Brush.WithValue(brush)),
                    ValueSome [| GeometryDrawing.GeometryWidget.WithValue(geometry.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior with the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: IBrush) =
            WidgetBuilder<'msg, IFabComponentGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.two(GeometryDrawing.Brush.WithValue(brush), GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry))),
                    ValueNone,
                    ValueNone
                )
            )

type ComponentGeometryDrawingModifiers =

    /// <summary>Sets the Pen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Pen value.</param>
    [<Extension>]
    static member inline pen(this: WidgetBuilder<'msg, #IFabComponentGeometryDrawing>, value: WidgetBuilder<'msg, #IFabPen>) =
        this.AddWidget(GeometryDrawing.Pen.WithValue(value.Compile()))
