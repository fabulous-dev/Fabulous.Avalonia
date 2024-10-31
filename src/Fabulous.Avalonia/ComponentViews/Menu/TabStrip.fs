namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentTabStrip =
    inherit IFabComponentSelectingItemsControl
    inherit IFabTabStrip


[<AutoOpen>]
module ComponentTabStripBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TabStrip widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member TabStrip<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabComponentControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabComponentTabStrip, 'itemData, 'itemMarker> TabStrip.WidgetKey ItemsControl.ItemsSourceTemplate items template
