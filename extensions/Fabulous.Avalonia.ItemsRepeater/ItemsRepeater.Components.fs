namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Components

type IFabComponentItemsRepeater =
    inherit IFabComponentPanel
    inherit IFabItemsRepeater


[<AutoOpen>]
module ComponentItemsRepeaterBuilders =
    type Fabulous.Avalonia.Components.View with

        static member ItemsRepeater<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabComponentControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabComponentItemsRepeater, 'itemData, 'itemMarker> ItemsRepeater.WidgetKey ItemsRepeater.ItemsSource items template
