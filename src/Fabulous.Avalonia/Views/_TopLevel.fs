namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Styling
open Fabulous

type IFabTopLevel =
    inherit IFabContentControl

module TopLevel =

    let ThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.RequestedThemeVariantProperty

    let ThemeVariantChanged =
        Attributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

    let TransparencyLevelHint =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyLevelHintProperty

    let TransparencyBackgroundFallbackWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.TransparencyBackgroundFallbackProperty

    let TransparencyBackgroundFallback =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyBackgroundFallbackProperty

    let Opened =
        Attributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let BackRequested =
        Attributes.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

[<Extension>]
type TopLevelModifiers =
    /// <summary>Sets the ThemeVariant property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    [<Extension>]
    static member inline themeVariant(this: WidgetBuilder<'msg, #IFabTopLevel>, value: ThemeVariant) =
        this.AddScalar(TopLevel.ThemeVariant.WithValue(value))

    /// <summary>Listens to the ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Function to call when the event is raised.</param>
    [<Extension>]
    static member inline onThemeVariantChanged(this: WidgetBuilder<'msg, #IFabTopLevel>, fn: ThemeVariant -> 'msg) =
        this.AddScalar(TopLevel.ThemeVariantChanged.WithValue(fn Application.Current.ActualThemeVariant))

    /// <summary>Sets the TransparencyLevelHint property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// [&lt;Struct&gt;]
    /// type WindowTransparencyLevel =
    /// | None = 0
    /// | Transparent = 1
    /// | Blur = 2
    /// | AcrylicBlur = 3
    /// | ForceAcrylicBlur = 4
    /// | Mica = 5
    /// </code>
    /// </example>
    [<Extension>]
    static member inline transparencyLevelHint(this: WidgetBuilder<'msg, #IFabTopLevel>, value: WindowTransparencyLevel) =
        this.AddScalar(TopLevel.TransparencyLevelHint.WithValue(value))

    /// <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="widget">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// Window(...)
    ///    .transparencyBackgroundFallback(SolidColorBrush(Colors.Yellow))
    /// </code>
    /// </example>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, widget: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallbackWidget.WithValue(widget.Compile()))

    // <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// Window(...)
    ///    .transparencyBackgroundFallback(Brushes.Yellow)
    /// </code>
    /// </example>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: IBrush) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(value))

    // <summary>Sets the TransparencyBackgroundFallback property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The value to set.</param>
    /// <example>
    /// <code lang="fsharp">
    /// Window(...)
    ///    .transparencyBackgroundFallback("#FF00FF00")
    /// </code>
    /// </example>
    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, value: string) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Listens to the Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Message to send when the event is raised.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.Opened.WithValue(msg))

    /// <summary>Listens to the Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Message to send when the event is raised.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.Closed.WithValue(msg))

    /// <summary>Listens to the BackRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Message to send when the event is raised.</param>
    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<'msg, #IFabTopLevel>, msg: 'msg) =
        this.AddScalar(TopLevel.BackRequested.WithValue(fun _ -> msg |> box))
