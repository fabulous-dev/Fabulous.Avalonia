namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

type IFabComponentStackPanel =
    inherit IFabComponentPanel
    inherit IFabStackPanel

module ComponentStackPanel =
    let HorizontalSnapPointsChanged =
        ComponentAttributes.defineEvent "StackPanel_HorizontalSnapPointsChanged" (fun target -> (target :?> StackPanel).HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        ComponentAttributes.defineEvent "StackPanel_VerticalSnapPointsChanged" (fun target -> (target :?> StackPanel).VerticalSnapPointsChanged)

type ComponentStackPanelModifiers =

    /// <summary>Listens to the StackPanel HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<unit, #IFabComponentStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentStackPanel.HorizontalSnapPointsChanged.WithValue(fn))

    /// <summary>Listens to the StackPanel VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<unit, #IFabComponentStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentStackPanel.VerticalSnapPointsChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct StackPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentStackPanel>, value: ViewRef<StackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
