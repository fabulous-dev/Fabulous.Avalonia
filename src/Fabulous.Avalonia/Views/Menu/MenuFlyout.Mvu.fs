namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

module MvuMenuFlyout =
    let Items =
        MvuAttributes.defineAvaloniaNonGenericListWidgetCollection "MenuFlyout_Items" (fun target ->
            let target = target :?> MenuFlyout

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

[<AutoOpen>]
module MvuMenuFlyoutBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuFlyout widget.</summary>
        static member MenuFlyout() =
            CollectionBuilder<'msg, IFabMenuFlyout, IFabMenuItem>(MenuFlyout.WidgetKey, MvuMenuFlyout.Items)
