namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentRadialGradientBrush =
    inherit IFabComponentGradientBrush
    inherit IFabRadialGradientBrush

module ComponentRadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let Radius =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module ComponentRadialGradientBrushBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint) =
            CollectionBuilder<unit, IFabComponentRadialGradientBrush, IFabComponentGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The relative unit of the center.</param>
        static member RadialGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<unit, IFabComponentRadialGradientBrush, IFabComponentGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<unit, IFabComponentRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        /// <param name="unit">The relative unit of the center and origin.</param>
        static member RadialGradientBrush(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<unit, IFabComponentRadialGradientBrush, IFabComponentGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        static member RadialGradientBrush() =
            CollectionBuilder<unit, IFabComponentRadialGradientBrush, IFabComponentGradientStop>(
                RadialGradientBrush.WidgetKey,
                ComponentGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )
