namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections

type IFabReversibleStackPanel =
    inherit IFabStackPanel

module ReversibleStackPanel =
    let WidgetKey = Widgets.register<ReversibleStackPanel> ()

    let ReverseOrder =
        Attributes.defineAvaloniaPropertyWithEquality ReversibleStackPanel.ReverseOrderProperty

[<AutoOpen>]
module ReversibleStackPanelBuilders =
    type Fabulous.Avalonia.View with

        static member VStack<'msg>(?spacing: float, ?reverseOrder: bool) =
            let spacing =
                match spacing with
                | Some spacing -> spacing
                | None -> 0.

            let reverseOrder =
                match reverseOrder with
                | Some reverseOrder -> reverseOrder
                | None -> false


            let scalers: StackAllocatedCollections.StackList.StackList<ScalarAttribute> =
                StackAllocatedCollections.StackList.StackList<ScalarAttribute>.three
                    (StackPanel.Orientation.WithValue(Orientation.Vertical),
                     StackPanel.Spacing.WithValue(spacing),
                     ReversibleStackPanel.ReverseOrder.WithValue(reverseOrder))

            CollectionBuilder<'msg, IFabReversibleStackPanel, IFabControl>(
                ReversibleStackPanel.WidgetKey,
                scalers,
                Panel.Children
            )

        static member HStack<'msg>(?spacing: float, ?reverseOrder: bool) =
            let spacing =
                match spacing with
                | Some spacing -> spacing
                | None -> 0.

            let reverseOrder =
                match reverseOrder with
                | Some reverseOrder -> reverseOrder
                | None -> false

            let scalers: StackAllocatedCollections.StackList.StackList<ScalarAttribute> =
                StackAllocatedCollections.StackList.StackList<ScalarAttribute>.three
                    (StackPanel.Orientation.WithValue(Orientation.Horizontal),
                     StackPanel.Spacing.WithValue(spacing),
                     ReversibleStackPanel.ReverseOrder.WithValue(reverseOrder))

            CollectionBuilder<'msg, IFabReversibleStackPanel, IFabControl>(
                ReversibleStackPanel.WidgetKey,
                scalers,
                Panel.Children
            )
