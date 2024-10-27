namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia

type IFabMvuTabStrip =
    inherit IFabMvuSelectingItemsControl
    inherit IFabTabStrip


[<AutoOpen>]
module MvuTabStripBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TabStrip widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member TabStrip<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabMvuControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabMvuTabStrip, 'itemData, 'itemMarker> TabStrip.WidgetKey ItemsControl.ItemsSourceTemplate items template
