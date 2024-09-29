namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabMvuDockPanel =
    inherit IFabMvuPanel
    inherit IFabDockPanel

[<AutoOpen>]
module MvuDockPanelBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DockPanel widget.</summary>
        static member Dock() =
            CollectionBuilder<unit, IFabMvuDockPanel, IFabMvuControl>(
                DockPanel.WidgetKey,
                MvuPanel.Children,
                DockPanel.LastChildFill.WithValue(true)
            )

        /// <summary>Creates a DockPanel widget.</summary>
        /// <param name="lastChildFill">Whether the last child element within a DockPanel stretches to fill the remaining available space.</param>
        static member Dock(lastChildFill: bool) =
            CollectionBuilder<unit, IFabMvuDockPanel, IFabMvuControl>(
                DockPanel.WidgetKey,
                MvuPanel.Children,
                DockPanel.LastChildFill.WithValue(lastChildFill)
            )

type MvuDockPanelModifiers =
    /// <summary>Link a ViewRef to access the direct DockPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuDockPanel>, value: ViewRef<DockPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
