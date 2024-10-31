namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia

type IFabComponentListBox =
    inherit IFabComponentSelectingItemsControl
    inherit IFabListBox

[<AutoOpen>]
module ListBoxBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ListBox widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member ListBox<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabComponentControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<unit, 'itemMarker>)
            =
            WidgetHelpers.buildItems<unit, IFabComponentListBox, 'itemData, 'itemMarker> ListBox.WidgetKey ItemsControl.ItemsSourceTemplate items template

        /// <summary>Creates a ListBox widget.</summary>
        static member ListBox() =
            CollectionBuilder<unit, IFabComponentListBox, IFabComponentListBoxItem>(ListBox.WidgetKey, ComponentItemsControl.Items)
