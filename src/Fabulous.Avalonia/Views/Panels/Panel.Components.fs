namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel() =
            CollectionBuilder<'msg, IFabPanel, IFabControl>(Panel.WidgetKey, ComponentPanel.Children)
