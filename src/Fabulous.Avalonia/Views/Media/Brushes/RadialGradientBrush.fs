namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabRadialGradientBrush =
    inherit IFabBrush

module RadialGradientBrush =
    let WidgetKey = Widgets.register<RadialGradientBrush>()

    let Center =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.CenterProperty

    let GradientOrigin =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.GradientOriginProperty

    let Radius =
        Attributes.defineAvaloniaPropertyWithEquality RadialGradientBrush.RadiusProperty

[<AutoOpen>]
module RadialGradientBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        static member inline RadialGradientBrush<'msg>(center: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The relative unit of the center.</param>
        static member inline RadialGradientBrush<'msg>(center: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue((RelativePoint(center, unit))),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        static member inline RadialGradientBrush<'msg>(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        /// <param name="unit">The relative unit of the center and origin.</param>
        static member inline RadialGradientBrush<'msg>(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        static member inline RadialGradientBrush<'msg>() =
            CollectionBuilder<'msg, IFabRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                GradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

[<Extension>]
type RadialGradientBrushModifiers =

    /// <summary>Sets the Radius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Radius value.</param>
    [<Extension>]
    static member inline radius(this: WidgetBuilder<'msg, #IFabRadialGradientBrush>, value: float) =
        this.AddScalar(RadialGradientBrush.Radius.WithValue(value))
