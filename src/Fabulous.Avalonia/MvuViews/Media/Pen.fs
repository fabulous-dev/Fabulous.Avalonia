namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuPen =
    inherit IFabMvuElement
    inherit IFabPen

[<AutoOpen>]
module MvuPenBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: WidgetBuilder<'msg, #IFabBrush>, thickness: float) =
            WidgetBuilder<'msg, IFabMvuPen>(
                Pen.WidgetKey,
                AttributesBundle(StackList.one(Pen.Thickness.WithValue(thickness)), ValueSome [| Pen.BrushWidget.WithValue(brush.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Pen widget.</summary>
        /// <param name="brush">The brush used to draw the stroke.</param>
        /// <param name="thickness">The thickness of the stroke.</param>
        static member Pen(brush: IBrush, thickness: float) =
            WidgetBuilder<'msg, IFabMvuPen>(Pen.WidgetKey, Pen.Thickness.WithValue(thickness), Pen.Brush.WithValue(brush))

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

type MvuPenModifiers =
    /// <summary>Link a ViewRef to access the direct Pen control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuPen>, value: ViewRef<Pen>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
