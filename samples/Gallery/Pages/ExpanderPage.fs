namespace Gallery.Pages

open System
open Avalonia.Animation
open Avalonia.Controls
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ExpanderPage =
    type Model = { IsExpanded: bool }

    type Msg =
        | ExpandChanged of bool
        | Expanding
        | Collapsing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsExpanded = true }, []

    let update msg model =
        match msg with
        | ExpandChanged b -> { model with IsExpanded = b }, []
        | Expanding -> model, []
        | Collapsing -> model, []

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
