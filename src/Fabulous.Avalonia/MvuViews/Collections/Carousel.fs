namespace Fabulous.Avalonia.Mvu


open Fabulous
open Fabulous.Avalonia

type IFabMvuCarousel =
    inherit IFabMvuSelectingItemsControl
    inherit IFabCarousel

[<AutoOpen>]
module CarouselBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Carousel widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use to render each item.</param>
        static member Carousel<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabMvuControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabMvuCarousel, 'itemData, 'itemMarker> Carousel.WidgetKey ItemsControl.ItemsSourceTemplate items template
