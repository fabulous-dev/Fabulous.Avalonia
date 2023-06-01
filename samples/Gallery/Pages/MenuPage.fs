namespace Gallery.Pages

open Avalonia.Controls
open Avalonia.Input
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View
open Gallery

module MenuPage =
    type Model = { IsChecked: bool }

    type Msg = ValueChanged of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () = { IsChecked = false }, []

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }, []

    let view model =
        VStack(4.) {
            TextBlock("Exported menu fallback")
            TextBlock("Should be only visible on platforms without desktop-global menu bar")
            NativeMenuBar()

            Dock() {
                (Menu() {
                    MenuItems'("_First") {
                        MenuItem("Standard _Menu Item")
                            .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))
                            .enableMenuItemClickForwarding(true)

                        MenuItem("_Disabled Menu Item")
                            .inputGesture(KeyGesture(Key.D, KeyModifiers.Control))
                            .isEnabled(false)

                        Separator()

                        MenuItems'("Menu with _Submenu") {
                            MenuItem("Submenu _1")
                            MenuItems'("Submenu _2 with Submenu") { MenuItem("Submenu Level 2") }

                            (MenuItems'("Submenu _3 with Submenu Disabled") { MenuItem("Submenu Level 2") })
                                .isEnabled(false)
                        }

                        MenuItem("Menu Item with _Icon")
                            .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                            .icon(Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png"))

                        MenuItem("Menu Item with _Checkbox")
                            .icon(CheckBox(model.IsChecked, ValueChanged))
                            .borderThickness(0.)
                            .isHitTestVisible(false)
                    }

                    MenuItems'("_Second") { MenuItem("Second _Menu Item") }
                })
                    .dock(Dock.Top)
            }
        }
