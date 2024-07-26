namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Styling
open Fabulous

type IFabTopLevel =
    inherit IFabContentControl

module TopLevel =
    let PointerOverElement =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.PointerOverElementProperty

    let TransparencyLevelHint =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyLevelHintProperty

    let SystemBarColorWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.SystemBarColorProperty

    let SystemBarColor =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.SystemBarColorProperty

    let TransparencyBackgroundFallbackWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.TransparencyBackgroundFallbackProperty

    let TransparencyBackgroundFallback =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyBackgroundFallbackProperty

    let AutoSafeAreaPadding =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.AutoSafeAreaPaddingProperty

    let Opened =
        Attributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let ScalingChanged =
        Attributes.defineEventNoArg "TopLevel_ScalingChangedEvent" (fun target -> (target :?> TopLevel).ScalingChanged)

    let BackRequested =
        Attributes.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

    let RequestedThemeVariant =
        Attributes.definePropertyWithGetSet
            "TopLevel_RequestedThemeVariant"
            (fun target ->
                let target = target :?> TopLevel
                target.ActualThemeVariant)
            (fun target value ->
                let target = target :?> TopLevel
                target.RequestedThemeVariant <- value)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

type TopLevelModifiers =
    /// <summary>Sets the PointerOverElement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PointerOverElement value.</param>
    [<Extension>]
    static member inline pointerOverElement(this: WidgetBuilder<'msg, #IFabTopLevel>, value: IInputElement) =
        this.AddScalar(TopLevel.PointerOverElement.WithValue(value))

    /// <summary>Sets the ThemeVariant property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ThemeVariant value.</param>
    [<Extension>]
    static member inline requestedThemeVariant(this: WidgetBuilder<'msg, #IFabTopLevel>, value: ThemeVariant) =
        this.AddScalar(TopLevel.RequestedThemeVariant.WithValue(value))

    /// <summary>Listens to the TopLevel ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: 'msg) =
        this.AddScalar(TopLevel.ActualThemeVariantChanged.WithValue(MsgValue(fn)))

    /// <summary>Sets the TransparencyLevelHint property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyLevelHint value.</param>
    [<Extension>]
    static member inline transparencyLevelHint(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WindowTransparencyLevel list) =
        this.AddScalar(TopLevel.TransparencyLevelHint.WithValue(value))

    /// <summary>Sets the TransparencyBackgroundFallbackWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallbackWidget value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallbackWidget.WithValue(value.Compile()))

    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallback value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: IBrush) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(value))

    /// <summary>Sets the SystemBarColorWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColorWidget value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.SystemBarColorWidget.WithValue(value.Compile()))

    /// <summary>Sets the AutoSafeAreaPadding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoSafeAreaPadding value.</param>
    [<Extension>]
    static member inline autoSafeAreaPadding(this: WidgetBuilder<'msg, #IFabTopLevel>, value: bool) =
        this.AddScalar(TopLevel.AutoSafeAreaPadding.WithValue(value))

    /// <summary>Listens the TopLevel Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.Opened.WithValue(MsgValue msg))

    /// <summary>Listens the TopLevel Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.Closed.WithValue(MsgValue msg))

    /// <summary>Listens the TopLevel BackRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the back button is pressed.</param>
    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(TopLevel.BackRequested.WithValue(fn))

    /// <summary>Listens the TopLevel ScalingChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the TopLevel's scaling changes.</param>
    [<Extension>]
    static member inline onScalingChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.ScalingChanged.WithValue(MsgValue msg))

type TopLevelExtraModifiers =
    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallback value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: Color) =
        TopLevelModifiers.transparencyBackgroundFallback(this, View.SolidColorBrush(value))

    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransparencyBackgroundFallback value.</param>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: string) =
        TopLevelModifiers.transparencyBackgroundFallback(this, View.SolidColorBrush(value))

    /// <summary>Sets the SystemBarColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColor value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, value: Color) =
        TopLevelModifiers.systemBarColor(this, View.SolidColorBrush(value))

    /// <summary>Sets the SystemBarColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SystemBarColor value.</param>
    [<Extension>]
    static member inline systemBarColor(this: WidgetBuilder<'msg, #IFabTopLevel>, value: string) =
        TopLevelModifiers.systemBarColor(this, View.SolidColorBrush(value))
