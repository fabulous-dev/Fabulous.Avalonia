namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous


type IFabTabStrip =
    inherit IFabSelectingItemsControl

module TabStrip =
    let WidgetKey = Widgets.register<TabStrip>()

[<AutoOpen>]
module TabStripBuilders =
    type Fabulous.Avalonia.View with

        static member inline TabStrip<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabTabStrip, 'itemData, 'itemMarker> TabStrip.WidgetKey ItemsControl.ItemsSource items template
