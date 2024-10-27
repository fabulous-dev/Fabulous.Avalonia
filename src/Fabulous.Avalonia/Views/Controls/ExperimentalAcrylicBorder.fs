namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous

type IFabExperimentalAcrylicBorder =
    inherit IFabDecorator

module ExperimentalAcrylicBorder =
    let WidgetKey = Widgets.register<ExperimentalAcrylicBorder>()

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicBorder.CornerRadiusProperty

    let Material =
        Attributes.defineAvaloniaPropertyWidget ExperimentalAcrylicBorder.MaterialProperty

type ExperimentalAcrylicBorderModifiers =
    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>, value: CornerRadius) =
        this.AddScalar(ExperimentalAcrylicBorder.CornerRadius.WithValue(value))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>, value: float) =
        this.AddScalar(ExperimentalAcrylicBorder.CornerRadius.WithValue(CornerRadius(value)))

    /// <summary>Sets the Material property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Material value.</param>
    [<Extension>]
    static member inline material(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>, value: WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>) =
        this.AddWidget(ExperimentalAcrylicBorder.Material.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct ExperimentalAcrylicBorder control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExperimentalAcrylicBorder>, value: ViewRef<ExperimentalAcrylicBorder>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
