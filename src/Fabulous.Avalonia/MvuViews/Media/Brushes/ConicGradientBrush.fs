namespace Fabulous.Avalonia.Mvu

open Avalonia
open Fabulous
open Fabulous.Avalonia

type IFabMvuConicGradientBrush =
    inherit IFabMvuGradientBrush
    inherit IFabConicGradientBrush

[<AutoOpen>]
module MvuConicGradientBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(center: RelativePoint, angle: float) =
            CollectionBuilder<'msg, IFabMvuConicGradientBrush, IFabMvuGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member ConicGradientBrush(center: RelativePoint) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(center),
                ConicGradientBrush.Angle.WithValue(0.)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The 'msg of the center.</param>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(center: Point, unit: RelativeUnit, angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The 'msg of the center.</param>
        static member ConicGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                ConicGradientBrush.Angle.WithValue(0.)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        /// <param name="angle">The angle of the gradient.</param>
        static member ConicGradientBrush(angle: float) =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(angle)
            )

        /// <summary>Creates a ConicGradientBrush widget.</summary>
        static member ConicGradientBrush() =
            CollectionBuilder<'msg, IFabConicGradientBrush, IFabGradientStop>(
                ConicGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                ConicGradientBrush.Center.WithValue(RelativePoint.Center),
                ConicGradientBrush.Angle.WithValue(0.)
            )
