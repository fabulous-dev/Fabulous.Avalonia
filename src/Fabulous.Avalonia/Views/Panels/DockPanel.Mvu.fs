namespace Fabulous.Avalonia

open Fabulous

[<AutoOpen>]
module MvuDockPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DockPanel widget.</summary>
        static member Dock() =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, MvuPanel.Children, DockPanel.LastChildFill.WithValue(true))

        /// <summary>Creates a DockPanel widget.</summary>
        /// <param name="lastChildFill">Whether the last child element within a DockPanel stretches to fill the remaining available space.</param>
        static member Dock(lastChildFill: bool) =
            CollectionBuilder<'msg, IFabDockPanel, IFabControl>(DockPanel.WidgetKey, MvuPanel.Children, DockPanel.LastChildFill.WithValue(lastChildFill))