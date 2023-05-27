namespace Gallery.Pages

open System.ComponentModel
open Avalonia.Input
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module ContextMenuPage =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpened
        | MenuClosed
        | ContextMenuOpening of CancelEventArgs
        | ContextMenuClosing of CancelEventArgs
        | ValueChanged of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { Counter = 0; IsChecked = false }, []

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }
        | ContextMenuOpening _ -> model
        | ContextMenuClosing _ -> model
        | MenuOpened _ -> model
        | MenuClosed _ -> model

    let view model =
        VStack(spacing = 15.) {
            Border(TextBlock("A right click menu that can be applied to any control."))
                .contextMenu(
                    (ContextMenu() {
                        MenuItem("Standard _Menu Item")
                            .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

                        MenuItem("Standard _Menu Item")
                            .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

                        MenuItem("_Disabled Menu Item")
                            .inputGesture(KeyGesture(Key.D, KeyModifiers.Control))
                            .isEnabled(false)

                        Separator()

                        MenuItems("Menu with _Submenu") {
                            MenuItem("Submenu _1")
                            MenuItem("Submenu _1")
                            MenuItem("Submenu _2")
                            MenuItem("Submenu _2")
                        }
                    })
                        .onContextMenuOpening(ContextMenuOpening)
                        .onContextMenuClosing(ContextMenuClosing)
                )

            Border(TextBlock("A right click menu that can be applied to any control."))
                .contextMenu(
                    (ContextMenu() {
                        MenuItem("Menu Item with _Icon")
                            .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                            .icon(Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png"))

                        MenuItem("Menu Item with _Checkbox")
                            .icon(
                                CheckBox(model.IsChecked, ValueChanged)
                                    .borderThickness(0.)
                                    .isHitTestVisible(false)
                            )
                            .staysOpenOnClick(true)

                        MenuItem("Menu Item that won't close on click").staysOpenOnClick(true)

                        MenuItem("Menu Item that will close on click")
                    })
                        .onMenuOpened(MenuOpened)
                        .onMenuClosed(MenuClosed)
                )
        }
