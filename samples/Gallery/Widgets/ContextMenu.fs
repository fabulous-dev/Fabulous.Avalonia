namespace Gallery

open System.ComponentModel
open Avalonia.Input
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ContextMenu =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | ContextMenuOpening of CancelEventArgs
        | ContextMenuClosing of CancelEventArgs
        | ValueChanged of bool

    let init () = { Counter = 0; IsChecked = false }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }
        | ContextMenuOpening _ -> model
        | ContextMenuClosing _ -> model

    let view model =
        VStack(spacing = 15.) {
            Border(TextBlock("Right click me to open the context menu"))
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

                        MenuItem("Menu Item with _Icon")
                            .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                            .icon(Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png"))

                        MenuItem("Menu Item with _Checkbox")
                            .icon(
                                CheckBox(ValueChanged, model.IsChecked)
                                    .borderThickness(0.)
                                    .isHitTestVisible(false)
                            )

                        MenuItem("Menu Item that won't close on click").staysOpenOnClick(true)

                        MenuItem("Menu Item that will close on click")
                    })
                        .onContextMenuOpening(ContextMenuOpening)
                        .onContextMenuClosing(ContextMenuClosing)
                )
        }

    let sample =
        { Name = "ContextMenu"
          Description = "Control that displays a menu when invoked"
          Program = Helper.createProgram init update view }
