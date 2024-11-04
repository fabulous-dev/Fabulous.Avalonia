namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.StackAllocatedCollections

[<AutoOpen>]
module ComponentTabControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TabControl widget.</summary>
        /// <param name="placement">The placement of the tab strip.</param>
        static member TabControl(placement: Dock) =
            CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(TabControl.WidgetKey, ComponentItemsControl.Items, TabControl.TabStripPlacement.WithValue(placement))

        /// <summary>Creates a TabControl widget.</summary>
        static member TabControl() =
            CollectionBuilder<'msg, IFabTabControl, IFabTabItem>(TabControl.WidgetKey, ComponentItemsControl.Items, TabControl.TabStripPlacement.WithValue(Dock.Top))