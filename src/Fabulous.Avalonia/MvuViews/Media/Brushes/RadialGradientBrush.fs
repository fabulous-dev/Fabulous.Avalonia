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
            CollectionBuilder<unit, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="unit">The relative unit of the center.</param>
        static member RadialGradientBrush(center: Point, unit: RelativeUnit) =
            CollectionBuilder<unit, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        static member RadialGradientBrush(center: RelativePoint, origin: RelativePoint) =
            CollectionBuilder<unit, IFabMvuRadialGradientBrush, IFabGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(center),
                RadialGradientBrush.GradientOrigin.WithValue(origin)
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        /// <param name="center">The center of the gradient.</param>
        /// <param name="origin">The origin of the gradient.</param>
        /// <param name="unit">The relative unit of the center and origin.</param>
        static member RadialGradientBrush(center: Point, origin: Point, unit: RelativeUnit) =
            CollectionBuilder<unit, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint(center, unit)),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint(origin, unit))
            )

        /// <summary>Creates a RadialGradientBrush widget.</summary>
        static member RadialGradientBrush() =
            CollectionBuilder<unit, IFabMvuRadialGradientBrush, IFabMvuGradientStop>(
                RadialGradientBrush.WidgetKey,
                MvuGradientBrush.GradientStops,
                RadialGradientBrush.Center.WithValue(RelativePoint.Center),
                RadialGradientBrush.GradientOrigin.WithValue(RelativePoint.Center)
            )

type MvuRadialGradientBrushModifiers =

    /// <summary>Link a ViewRef to access the direct RadialGradientBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuRadialGradientBrush>, value: ViewRef<RadialGradientBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
