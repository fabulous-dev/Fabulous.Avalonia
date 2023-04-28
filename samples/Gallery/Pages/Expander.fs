namespace Gallery

open System
open Avalonia.Animation
open Avalonia.Controls
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ExpanderPage =
    type Model = { IsExpanded: bool }

    type Msg =
        | ExpandChanged of bool
        | Expanding
        | Collapsing

    let init () = { IsExpanded = true }

    let update msg model =
        match msg with
        | ExpandChanged b -> { model with IsExpanded = b }
        | Expanding -> model
        | Collapsing -> model

    let view model =
        VStack(spacing = 15.) {
            Expander("Title", "Mr.").isExpanded(model.IsExpanded)

            Expander(TextBlock("Title"), "Mr.")
                .onExpandedChanged(model.IsExpanded, ExpandChanged)

            Expander(
                "Title",
                VStack(8.) {
                    TextBlock("Mr.")
                    TextBlock("Mr.")
                    TextBlock("Ms.")
                    TextBlock("Mr.")
                }
            )
                .contentTransition(CrossFade(TimeSpan.FromSeconds(2.5)) :> IPageTransition)


            Expander(
                TextBlock("Marital status"),
                VStack(8.) {
                    TextBlock("Married")
                    Separator()
                    TextBlock("Single")
                    Separator()
                    TextBlock("Divorced")
                    Separator()
                    TextBlock("Widowed")
                }
            )
                .expandDirection(ExpandDirection.Right)
                .onCollapsing(Collapsing)
                .onExpanding(Expanding)
        }
