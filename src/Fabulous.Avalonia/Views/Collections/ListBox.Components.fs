namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia


[<AutoOpen>]
module ComponentListBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ListBox widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ListBox<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<unit, 'itemMarker>)
            =
            WidgetHelpers.buildItems<unit, IFabListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        /// <summary>Creates a ListBox widget.</summary>
        static member ListBox() =
            CollectionBuilder<unit, IFabListBox, IFabListBoxItem>(ListBox.WidgetKey, ComponentItemsControl.Items)
