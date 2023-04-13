namespace Gallery

open System.ComponentModel
open Avalonia.Input
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ContextFlyout =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpening
        | MenuClosing
        | ValueChanged of bool

    let init () = { Counter = 0; IsChecked = false }

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }
        | MenuOpening _ -> model
        | MenuClosing _ -> model

    let view model =
        VStack(spacing = 15.) {
            Border(TextBlock("A right click Flyout that can be applied to any control."))
                .contextFlyout(
                    (MenuFlyout() {
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
                                CheckBox(model.IsChecked, ValueChanged)
                                    .borderThickness(0.)
                                    .isHitTestVisible(false)
                            )

                        MenuItem("Menu Item that won't close on click").staysOpenOnClick(true)

                        MenuItem("Menu Item that will close on click")
                    })
                        .onClosed(MenuClosing)
                        .onOpening(MenuOpening)
                )
        }

    let sample =
        { Name = "ContextFlyout"
          Description = "Control the context flyout of a control"
          Program = Helper.createProgram init update view }
