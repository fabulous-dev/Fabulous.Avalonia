namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentVirtualizingStackPanel =
    inherit IFabComponentVirtualizingPanel
    inherit IFabVirtualizingStackPanel

module ComponentVirtualizingStackPanel =
    let HorizontalSnapPointsChanged =
        ComponentAttributes.defineEvent "VirtualizingStackPanel_HorizontalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        ComponentAttributes.defineEvent "VirtualizingStackPanel_VerticalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .VerticalSnapPointsChanged)

[<AutoOpen>]
module ComponentVirtualizingStackPanelBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a VirtualizingStackPanel widget.</summary>
        static member VirtualizingStackPanel() =
            WidgetBuilder<'msg, IFabVirtualizingStackPanel>(VirtualizingStackPanel.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentVirtualizingStackPanelModifiers =

    /// <summary>Listens to the StackPanel HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<unit, #IFabComponentVirtualizingStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentVirtualizingStackPanel.HorizontalSnapPointsChanged.WithValue(fn))

    /// <summary>Listens to the StackPanel VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<unit, #IFabComponentVirtualizingStackPanel>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentVirtualizingStackPanel.VerticalSnapPointsChanged.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct VirtualizingStackPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentVirtualizingStackPanel>, value: ViewRef<VirtualizingStackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
