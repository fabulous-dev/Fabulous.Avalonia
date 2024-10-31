namespace Fabulous.Avalonia.Components

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
