namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open System.Collections.ObjectModel

open type Fabulous.Avalonia.View

module ItemsControlPage =
    type Crockery = { Title: string; Number: int }

    let items = [ for i in 1..1000 -> { Title = "dinner plate"; Number = i } ]

    let view () =

        VStack() {
            TextBlock("List of crockery:")

            ItemsControl(
                items,
                fun item ->
                    HStack() {
                        TextBlock(item.Title)
                        TextBlock(item.Number.ToString())
                    }
            )
                .itemsPanel(VirtualizingStackPanel())
        }
