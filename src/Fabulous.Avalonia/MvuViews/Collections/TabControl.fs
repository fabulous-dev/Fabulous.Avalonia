namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuTabControl =
    inherit IFabMvuSelectingItemsControl
    inherit IFabTabControl

[<AutoOpen>]
module MvuTabControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TabControl widget.</summary>
        /// <param name="placement">The placement of the tab strip.</param>
        static member TabControl(placement: Dock) =
            CollectionBuilder<'msg, IFabMvuTabControl, IFabMvuTabItem>(
                TabControl.WidgetKey,
                MvuItemsControl.Items,
                TabControl.TabStripPlacement.WithValue(placement)
            )

        /// <summary>Creates a TabControl widget.</summary>
        static member TabControl() =
            CollectionBuilder<'msg, IFabMvuTabControl, IFabMvuTabItem>(
                TabControl.WidgetKey,
                MvuItemsControl.Items,
                TabControl.TabStripPlacement.WithValue(Dock.Top)
            )
