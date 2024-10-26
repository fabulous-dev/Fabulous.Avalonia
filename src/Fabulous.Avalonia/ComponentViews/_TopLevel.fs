namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentTopLevel =
    inherit IFabComponentContentControl
    inherit IFabTopLevel

module ComponentTopLevel =
    let Opened =
        Attributes.defineEventNoArgNoDispatch "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArgNoDispatch "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let ScalingChanged =
        Attributes.defineEventNoArgNoDispatch "TopLevel_ScalingChangedEvent" (fun target -> (target :?> TopLevel).ScalingChanged)

    let BackRequested =
        Attributes.defineEventNoDispatch "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArgNoDispatch "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

type ComponentTopLevelModifiers =
    /// <summary>Listens to the TopLevel ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<unit, #IFabComponentTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.ActualThemeVariantChanged.WithValue(fn))

    /// <summary>Listens the TopLevel Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabComponentTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.Opened.WithValue(fn))

    /// <summary>Listens the TopLevel Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabComponentTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.Closed.WithValue(fn))

    /// <summary>Listens the TopLevel BackRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the back button is pressed.</param>
    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<unit, #IFabComponentTopLevel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentTopLevel.BackRequested.WithValue(fn))

    /// <summary>Listens the TopLevel ScalingChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TopLevel's scaling changes.</param>
    [<Extension>]
    static member inline onScalingChanged(this: WidgetBuilder<unit, #IFabComponentTopLevel>, fn: unit -> unit) =
        this.AddScalar(ComponentTopLevel.ScalingChanged.WithValue(fn))

type ComponentTopLevelExtraModifiers =
    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallback value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<unit, #IFabComponentTopLevel>, value: Color) =
        TopLevelModifiers.transparencyBackgroundFallback(this, View.SolidColorBrush(value))

    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallback value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<unit, #IFabTopLevel>, value: string) =
        TopLevelModifiers.transparencyBackgroundFallback(this, View.SolidColorBrush(value))

    /// <summary>Sets the SystemBarColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColor value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<unit, #IFabTopLevel>, value: Color) =
        TopLevelModifiers.systemBarColor(this, View.SolidColorBrush(value))

    /// <summary>Sets the SystemBarColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColor value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<unit, #IFabTopLevel>, value: string) =
        TopLevelModifiers.systemBarColor(this, View.SolidColorBrush(value))
