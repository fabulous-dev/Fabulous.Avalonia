namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuVirtualizingStackPanel =
    inherit IFabMvuVirtualizingPanel
    inherit IFabVirtualizingStackPanel

module MvuVirtualizingStackPanel =
    let HorizontalSnapPointsChanged =
        Attributes.defineEvent "VirtualizingStackPanel_HorizontalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEvent "VirtualizingStackPanel_VerticalSnapPointsChanged" (fun target ->
            (target :?> VirtualizingStackPanel)
                .VerticalSnapPointsChanged)

[<AutoOpen>]
module MvuVirtualizingStackPanelBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a VirtualizingStackPanel widget.</summary>
        static member VirtualizingStackPanel() =
            WidgetBuilder<'msg, IFabVirtualizingStackPanel>(VirtualizingStackPanel.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuVirtualizingStackPanelModifiers =

    /// <summary>Listens to the StackPanel HorizontalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabMvuVirtualizingStackPanel>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuVirtualizingStackPanel.HorizontalSnapPointsChanged.WithValue(fn))

    /// <summary>Listens to the StackPanel VerticalSnapPointsChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalSnapPointsChanged event fires.</param>
    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabMvuVirtualizingStackPanel>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuVirtualizingStackPanel.VerticalSnapPointsChanged.WithValue(fn))
