namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabMvuRadialGradientBrush =
    inherit IFabMvuGradientBrush
    inherit IFabRadialGradientBrush

module MvuRadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let Radius =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module MvuRadialGradientBrushBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint) =
            CollectionBuilder<'msg, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The relative 'msg of the center.</param>
        static member RadialGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<'msg, IFabMvuRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        /// <param name="unit">The relative 'msg of the center and origin.</param>
        static member RadialGradientBrush(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        static member RadialGradientBrush() =
            CollectionBuilder<'msg, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )
