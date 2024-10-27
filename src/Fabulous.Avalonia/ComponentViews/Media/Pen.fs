namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentPen =
    inherit IFabComponentElement
    inherit IFabPen

[<AutoOpen>]
module ComponentPenBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: WidgetBuilder<'msg, #IFabBrush>, thickness: float) =
            WidgetBuilder<'msg, IFabComponentPen>(
                Pen.WidgetKey,
                AttributesBundle(StackList.one(Pen.Thickness.WithValue(thickness)), ValueSome [| Pen.BrushWidget.WithValue(brush.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: IBrush, thickness: float) =
            WidgetBuilder<'msg, IFabComponentPen>(Pen.WidgetKey, Pen.Thickness.WithValue(thickness), Pen.Brush.WithValue(brush))

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: Color, thickness: float) =
            View.Pen(View.SolidColorBrush(brush), thickness)

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: string, thickness: float) =
            View.Pen(View.SolidColorBrush(brush), thickness)

type ComponentPenModifiers =
    /// <summary>Link a ViewRef to access the direct Pen control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentPen>, value: ViewRef<Pen>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
