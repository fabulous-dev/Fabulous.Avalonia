namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentRectangle =
    inherit IFabComponentShape
    inherit IFabRectangle

[<AutoOpen>]
module ComponentRectangleBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Rectangle widget.</summary>
        /// <param name="radiusX">The radius on the X-axis used to round the corners of the rectangle.</param>
        /// <param name="radiusY">The radius on the Y-axis used to round the corners of the rectangle.</param>
        static member Rectangle(radiusX: float, radiusY: float) =
            WidgetBuilder<unit, IFabComponentRectangle>(Rectangle.WidgetKey, Rectangle.RadiusX.WithValue(radiusX), Rectangle.RadiusY.WithValue(radiusY))

        /// <summary>Creates a Rectangle widget.</summary>
        static member Rectangle() =
            WidgetBuilder<unit, IFabComponentRectangle>(Rectangle.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentRectangleModifiers =
    /// <summary>Link a ViewRef to access the direct Rectangle control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentRectangle>, value: ViewRef<Rectangle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
