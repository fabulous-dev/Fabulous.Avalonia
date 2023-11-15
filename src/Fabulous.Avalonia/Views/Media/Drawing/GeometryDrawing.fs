namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Immutable
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

    let BrushWidget =
        Attributes.defineAvaloniaPropertyWidget GeometryDrawing.BrushProperty

    let Brush =
        Attributes.defineAvaloniaPropertyWithEquality GeometryDrawing.BrushProperty

    let Pen = Attributes.defineAvaloniaPropertyWidget GeometryDrawing.PenProperty

[<AutoOpen>]
module GeometryDrawingBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<'msg, #IFabGeometry>, brush: WidgetBuilder<'msg, #IFabBrush>) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
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
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: WidgetBuilder<'msg, #IFabBrush>) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry))),
                    ValueSome [| GeometryDrawing.BrushWidget.WithValue(brush.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: string) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry)),
                        GeometryDrawing.Brush.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush)
                    ),
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<'msg, #IFabGeometry>, brush: string) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Brush.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush)),
                    ValueSome [| GeometryDrawing.GeometryWidget.WithValue(geometry.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: WidgetBuilder<'msg, #IFabGeometry>, brush: IBrush) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.one(GeometryDrawing.Brush.WithValue(brush)),
                    ValueSome [| GeometryDrawing.GeometryWidget.WithValue(geometry.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a GeometryDrawing widget.</summary>
        /// <param name="geometry">The Geometry that describes the shape of this GeometryDrawing.</param>
        /// <param name="brush">The Brush used to fill the interior of the shape described by this GeometryDrawing.</param>
        static member GeometryDrawing(geometry: string, brush: IBrush) =
            WidgetBuilder<'msg, IFabGeometryDrawing>(
                GeometryDrawing.WidgetKey,
                AttributesBundle(
                    StackList.two(GeometryDrawing.Brush.WithValue(brush), GeometryDrawing.Geometry.WithValue(StreamGeometry.Parse(geometry))),
                    ValueNone,
                    ValueNone
                )
            )

type GeometryDrawingModifiers =

    /// <summary>Sets the Pen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Pen value.</param>
    [<Extension>]
    static member inline pen(this: WidgetBuilder<'msg, #IFabGeometryDrawing>, value: WidgetBuilder<'msg, #IFabPen>) =
        this.AddWidget(GeometryDrawing.Pen.WithValue(value.Compile()))
