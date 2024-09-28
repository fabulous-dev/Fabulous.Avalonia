namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

type IFabMvuTopLevel =
    inherit IFabMvuContentControl
    inherit IFabTopLevel

module MvuTopLevel =
    let Opened =
        MvuAttributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        MvuAttributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let ScalingChanged =
        MvuAttributes.defineEventNoArg "TopLevel_ScalingChangedEvent" (fun target -> (target :?> TopLevel).ScalingChanged)

    let BackRequested =
        MvuAttributes.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

    let ActualThemeVariantChanged =
        MvuAttributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> TopLevel).ActualThemeVariantChanged)

type MvuTopLevelModifiers =
    /// <summary>Listens to the TopLevel ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<unit, #IFabMvuTopLevel>, fn: unit -> unit) =
        this.AddScalar(MvuTopLevel.ActualThemeVariantChanged.WithValue(fn))

    /// <summary>Listens the TopLevel Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabMvuTopLevel>, fn: unit -> unit) =
        this.AddScalar(MvuTopLevel.Opened.WithValue(fn))

    /// <summary>Listens the TopLevel Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabMvuTopLevel>, fn: unit -> unit) =
        this.AddScalar(MvuTopLevel.Closed.WithValue(fn))

    /// <summary>Listens the TopLevel BackRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the back button is pressed.</param>
    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<unit, #IFabMvuTopLevel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuTopLevel.BackRequested.WithValue(fn))

    /// <summary>Listens the TopLevel ScalingChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TopLevel's scaling changes.</param>
    [<Extension>]
    static member inline onScalingChanged(this: WidgetBuilder<unit, #IFabMvuTopLevel>, fn: unit -> unit) =
        this.AddScalar(MvuTopLevel.ScalingChanged.WithValue(fn))
