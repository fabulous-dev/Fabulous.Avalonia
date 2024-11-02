namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.Avalonia

[<AutoOpen>]
module MvuPanelBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Panel widget.</summary>
        static member Panel() =
            CollectionBuilder<'msg, IFabPanel, IFabControl>(Panel.WidgetKey, MvuPanel.Children)