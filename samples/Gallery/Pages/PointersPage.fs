namespace Gallery.Pages

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module PointersPage =
    type Model = { IsOpen: bool }

    type Msg =
        | NoMsg

    type CmdMsg = | NoCmdMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoCmdMsg -> Cmd.none

    let init () = { IsOpen = false }, []

    let update msg model =
        match msg with
        | NoMsg -> model, []

    let view model =
        TabControl(Dock.Top) {
            TabItem(
                "Arch",
                VStack() {
                    TextBlock("This is the first page in the TabControl.")

                    Image(ImageSource.fromString "avares://Gallery/Assets/delicate-arch.jpg")
                        .width(300.)
                }
            )

            TabItem(
                TextBlock("Leaf"),
                VStack() {
                    TextBlock("This is the second page in the TabControl.")

                    Image(ImageSource.fromString "avares://Gallery/Assets/maple-leaf.jpg")
                        .width(300.)
                }
            )

            TabItem(TextBlock("Disabled"), TextBlock(">You should not see this."))
        }
