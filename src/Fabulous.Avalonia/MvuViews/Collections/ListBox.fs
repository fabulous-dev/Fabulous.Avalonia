namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuListBox =
    inherit IFabMvuSelectingItemsControl
    inherit IFabListBox

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ListBox widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ListBox<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabMvuListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        /// <summary>Creates a ListBox widget.</summary>
        static member ListBox() =
            CollectionBuilder<'msg, IFabMvuListBox, IFabMvuListBoxItem>(ListBox.WidgetKey, MvuItemsControl.Items)
