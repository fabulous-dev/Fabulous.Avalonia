namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open System.Runtime.CompilerServices

type IFabReversibleStackPanel =
    inherit IFabStackPanel

module ReversibleStackPanel =
    let WidgetKey = Widgets.register<ReversibleStackPanel>()

    let ReverseOrder =
        Attributes.defineAvaloniaPropertyWithEquality ReversibleStackPanel.ReverseOrderProperty

[<AutoOpen>]
module ReversibleStackPanelBuilders =
    type Fabulous.Avalonia.View with

        static member inline VStack<'msg>(?spacing: float, ?reverseOrder: bool) =

            let mutable scalers =
                StackList.one(StackPanel.Orientation.WithValue(Orientation.Vertical))

            match spacing with
            | None -> ()
            | Some v -> scalers <- StackList.add(&scalers, StackPanel.Spacing.WithValue(v))

            match reverseOrder with
            | None -> ()
            | Some v -> scalers <- StackList.add(&scalers, ReversibleStackPanel.ReverseOrder.WithValue(v))

            CollectionBuilder<'msg, IFabReversibleStackPanel, IFabControl>(ReversibleStackPanel.WidgetKey, scalers, Panel.Children)

        static member inline HStack<'msg>(?spacing: float, ?reverseOrder: bool) =

            let mutable scalers =
                StackList.one(StackPanel.Orientation.WithValue(Orientation.Horizontal))

            match spacing with
            | None -> ()
            | Some v -> scalers <- StackList.add(&scalers, StackPanel.Spacing.WithValue(v))

            match reverseOrder with
            | None -> ()
            | Some v -> scalers <- StackList.add(&scalers, ReversibleStackPanel.ReverseOrder.WithValue(v))

            CollectionBuilder<'msg, IFabReversibleStackPanel, IFabControl>(ReversibleStackPanel.WidgetKey, scalers, Panel.Children)
