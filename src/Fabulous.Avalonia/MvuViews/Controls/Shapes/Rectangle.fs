namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuRectangle =
    inherit IFabMvuShape
    inherit IFabRectangle

[<AutoOpen>]
module MvuRectangleBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Rectangle widget.</summary>
        /// <param name="radiusX">The radius on the X-axis used to round the corners of the rectangle.</param>
        /// <param name="radiusY">The radius on the Y-axis used to round the corners of the rectangle.</param>
        static member Rectangle(radiusX: float, radiusY: float) =
            WidgetBuilder<unit, IFabMvuRectangle>(Rectangle.WidgetKey, Rectangle.RadiusX.WithValue(radiusX), Rectangle.RadiusY.WithValue(radiusY))

        /// <summary>Creates a Rectangle widget.</summary>
        static member Rectangle() =
            WidgetBuilder<unit, IFabMvuRectangle>(Rectangle.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
