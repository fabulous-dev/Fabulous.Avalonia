namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentVirtualizingStackPanel =
    let HorizontalSnapPointsChanged =
        Attributes.defineEventNoDispatch "VirtualizingStackPanel_HorizontalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEventNoDispatch "VirtualizingStackPanel_VerticalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .VerticalSnapPointsChanged)

type ComponentVirtualizingStackPanelModifiers =

    /// <summary>Listens to the StackPanel HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<unit, #IFabVirtualizingStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentVirtualizingStackPanel.HorizontalSnapPointsChanged.WithValue(fn))

    /// <summary>Listens to the StackPanel VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<unit, #IFabVirtualizingStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentVirtualizingStackPanel.VerticalSnapPointsChanged.WithValue(fn))
