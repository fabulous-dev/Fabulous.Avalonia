namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

type IFabMvuStackPanel =
    inherit IFabMvuPanel
    inherit IFabStackPanel

module MvuStackPanel =
    let HorizontalSnapPointsChanged =
        Attributes.defineEvent "StackPanel_HorizontalSnapPointsChanged" (fun target -> (target :?> StackPanel).HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEvent "StackPanel_VerticalSnapPointsChanged" (fun target -> (target :?> StackPanel).VerticalSnapPointsChanged)

type MvuStackPanelModifiers =

    /// <summary>Listens to the StackPanel HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<unit, #IFabMvuStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuStackPanel.HorizontalSnapPointsChanged.WithValue(fn))

    /// <summary>Listens to the StackPanel VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<unit, #IFabMvuStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuStackPanel.VerticalSnapPointsChanged.WithValue(fn))
