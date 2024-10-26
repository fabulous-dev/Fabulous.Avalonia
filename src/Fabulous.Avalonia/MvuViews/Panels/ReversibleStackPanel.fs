namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open System.Runtime.CompilerServices
open Fabulous.Avalonia

type IFabMvuReversibleStackPanel =
    inherit IFabMvuStackPanel
    inherit IFabReversibleStackPanel

[<AutoOpen>]
module MvuReversibleStackPanelBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a VStack widget.</summary>
        /// <param name="spacing">The spacing between each child.</param>
        /// <param name="reverseOrder">If true, the children will be reversed.</param>
        static member VStack(?spacing: float, ?reverseOrder: bool) =

            let mutable scalars =
                StackList.one(StackPanel.Orientation.WithValue(Orientation.Vertical))

            match spacing with
            | None -> ()
            | Some v -> scalars <- StackList.add(&scalars, StackPanel.Spacing.WithValue(v))

            match reverseOrder with
            | None -> ()
            | Some v -> scalars <- StackList.add(&scalars, ReversibleStackPanel.ReverseOrder.WithValue(v))

            CollectionBuilder<'msg, IFabMvuReversibleStackPanel, IFabMvuControl>(ReversibleStackPanel.WidgetKey, scalars, MvuPanel.Children)

        /// <summary>Creates a HStack widget.</summary>
        /// <param name="spacing">The spacing between each child.</param>
        /// <param name="reverseOrder">If true, the children will be reversed.</param>
        static member HStack(?spacing: float, ?reverseOrder: bool) =

            let mutable scalars =
                StackList.one(StackPanel.Orientation.WithValue(Orientation.Horizontal))

            match spacing with
            | None -> ()
            | Some v -> scalars <- StackList.add(&scalars, StackPanel.Spacing.WithValue(v))

            match reverseOrder with
            | None -> ()
            | Some v -> scalars <- StackList.add(&scalars, ReversibleStackPanel.ReverseOrder.WithValue(v))

            CollectionBuilder<'msg, IFabMvuReversibleStackPanel, IFabMvuControl>(ReversibleStackPanel.WidgetKey, scalars, MvuPanel.Children)