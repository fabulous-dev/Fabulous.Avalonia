namespace Gallery

open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module DropDownButtonPage =
    type Model = { Count: int }

    type Msg =
        | Clicked
        | Clicked2
        | Increment
        | Decrement
        | Reset

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Count = 0 }, []

    let update msg model =
        match msg with
        | Clicked -> model, []
        | Clicked2 -> model, []
        | Increment -> { model with Count = model.Count + 1 }, []
        | Decrement -> { model with Count = model.Count - 1 }, []
        | Reset -> { model with Count = 0 }, []


    let view model =
        UniformGrid() {
            TextBlock($"Count: {model.Count}").centerVertical()

            DropDownButton("Open...", Clicked)
                .flyout(
                    (MenuFlyout() {
                        MenuItem("Item 1")
                            .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                        MenuItems("Item 2", Increment) {
                            MenuItem("Subitem 1")
                            MenuItem("Subitem 2")
                            MenuItem("Subitem 3")
                            MenuItem("Subitem 4")
                            MenuItem("Subitem 5")
                        }

                        MenuItem("Item 4").inputGesture(KeyGesture.Parse("Ctrl+A"))
                        MenuItem("Item 5").inputGesture(KeyGesture.Parse("Ctrl+A"))
                        MenuItem(TextBlock("Item 6"), Increment)
                        MenuItem("Item 7")
                    })
                        .placement(PlacementMode.BottomEdgeAlignedRight)
                )

            DropDownButton(Clicked2, TextBlock("Open..."))
                .flyout(
                    Flyout(
                        VWrap() {
                            TextBlock("Item 1")
                            Image("avares://Gallery/Assets/Icons/fabulous-icon.png")
                        }
                    )
                        .showMode(FlyoutShowMode.Standard)
                        .placement(PlacementMode.RightEdgeAlignedTop)
                )
                .background(Brushes.Blue)
        }
