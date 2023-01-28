namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous

type IFabCarousel =
    inherit IFabSelectingItemsControl


module Carousel =
    let WidgetKey = Widgets.register<Carousel>()

    let IsVirtualized =
        Attributes.defineAvaloniaPropertyWithEquality Carousel.IsVirtualizedProperty

    let PageTransition =
        Attributes.defineAvaloniaPropertyWithEquality Carousel.PageTransitionProperty

    let Items =
        Attributes.defineListWidgetCollection "Carousel_Items" (fun target -> (target :?> Carousel).Items :?> IList<_>)

    let ItemsSource =
        Attributes.defineSimpleScalar<WidgetItems>
            "Carousel_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> Carousel

                match newValueOpt with
                | ValueNone ->
                    itemsView.ClearValue(Carousel.ItemTemplateProperty)
                    itemsView.ClearValue(Carousel.ItemsProperty)
                | ValueSome value ->
                    itemsView.SetValue(Carousel.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    itemsView.SetValue(Carousel.ItemsProperty, value.OriginalItems))

[<AutoOpen>]
module CarouselBuilders =
    type Fabulous.Avalonia.View with

        static member inline Carousel<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFabControl>
            (
                items: seq<'itemData>,
                template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>
            ) =
            WidgetHelpers.buildItems<'msg, IFabCarousel, 'itemData, 'itemMarker> Carousel.WidgetKey Carousel.ItemsSource items template

        static member inline Carousel<'msg>() =
            CollectionBuilder<'msg, IFabCarousel, IFabControl>(Carousel.WidgetKey, Carousel.Items)

[<Extension>]
type CarouselModifiers =

    [<Extension>]
    static member inline isVirtualized(this: WidgetBuilder<'msg, #IFabCarousel>, value: bool) =
        this.AddScalar(Carousel.IsVirtualized.WithValue(value))

    [<Extension>]
    static member inline pageTransition(this: WidgetBuilder<'msg, #IFabCarousel>, value: IPageTransition) =
        this.AddScalar(Carousel.PageTransition.WithValue(value))

    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCarousel>, value: ViewRef<Carousel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
