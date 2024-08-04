namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia

type IFabComponentCarousel =
    inherit IFabComponentSelectingItemsControl
    inherit IFabCarousel

[<AutoOpen>]
module CarouselBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Carousel widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member Carousel<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabComponentControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabComponentCarousel, 'itemData, 'itemMarker> Carousel.WidgetKey ItemsControl.ItemsSourceTemplate items template
