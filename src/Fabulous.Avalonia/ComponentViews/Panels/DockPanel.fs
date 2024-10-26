namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentDockPanel =
    inherit IFabComponentPanel
    inherit IFabDockPanel

[<AutoOpen>]
module ComponentDockPanelBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DockPanel widget.</summary>
        static member Dock() =
            CollectionBuilder<unit, IFabComponentDockPanel, IFabComponentControl>(
                DockPanel.WidgetKey,
                ComponentPanel.Children,
                DockPanel.LastChildFill.WithValue(true)
            )

        /// <summary>Creates a DockPanel widget.</summary>
        /// <param name="lastChildFill">Whether the last child element within a DockPanel stretches to fill the remaining available space.</param>
        static member Dock(lastChildFill: bool) =
            CollectionBuilder<unit, IFabComponentDockPanel, IFabComponentControl>(
                DockPanel.WidgetKey,
                ComponentPanel.Children,
                DockPanel.LastChildFill.WithValue(lastChildFill)
            )

type ComponentDockPanelModifiers =
    /// <summary>Link a ViewRef to access the direct DockPanel control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentDockPanel>, value: ViewRef<DockPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
