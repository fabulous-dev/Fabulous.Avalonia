namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu

type IFabMvuItemsRepeater =
    inherit IFabMvuPanel
    inherit IFabItemsRepeater


[<AutoOpen>]
module MvuItemsRepeaterBuilders =
    type Fabulous.Avalonia.Mvu.View with

        static member ItemsRepeater<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabMvuControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabMvuItemsRepeater, 'itemData, 'itemMarker> ItemsRepeater.WidgetKey ItemsRepeater.ItemsSource items template