namespace Gallery.Root

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery
open Avalonia.Controls
open Gallery.Pages
open Types

open type Fabulous.Avalonia.View

module MainWindow =

    let createMenu model =
        NativeMenu() {
            NativeMenuItem("Edit")
                .menu(
                    NativeMenu() {
                        NativeMenuItem((if model.IsPanOpen then "Close Pan" else "Open Pan"), OpenPan)
                        NativeMenuItemSeparator()

                        NativeMenuItem("After separator", DoNothing)
                            .toggleType(NativeMenuItemToggleType.CheckBox)
                            .isChecked(model.IsPanOpen)
                    }
                )
        }

    let trayIcons () =
        TrayIcon(WindowIcon(ImageSource.fromString "avares://Gallery/Assets/Icons/logo.ico"), "Avalonia Tray Icon Tooltip")
            .menu(
                NativeMenu() {
                    NativeMenuItem("Settings")
                        .menu(
                            NativeMenu() {
                                NativeMenuItem("Option 1", DoNothing)
                                    .toggleType(NativeMenuItemToggleType.Radio)
                                    .isChecked(true)

                                NativeMenuItem("Option 2", DoNothing)
                                    .toggleType(NativeMenuItemToggleType.Radio)
                                    .isChecked(true)

                                NativeMenuItemSeparator()

                                NativeMenuItem("Option 3", DoNothing)
                                    .toggleType(NativeMenuItemToggleType.CheckBox)
                                    .isChecked(true)

                                NativeMenuItem("Restore defaults", DoNothing)
                                    .icon(ImageSource.fromString "avares://Gallery/Assets/Icons/logo.ico")

                                NativeMenuItem("Disabled option", DoNothing).isEnabled(false)
                            }
                        )

                    NativeMenuItem("Exit", DoNothing)
                }
            )

    let view (model: Model) =
        DesktopApplication(
            Window(
                Grid() {
                    TabControl(Dock.Left) {
                        for page in Seq.rev model.Navigation.BackStack do
                            let control = NavigationState.view SubpageMsg page
                            TabItem("Tab 1", control)

                        let control = NavigationState.view SubpageMsg model.Navigation.CurrentPage
                        TabItem("Tab 1", control)
                    }
                }
            )
                .background(SolidColorBrush(Colors.Transparent))
                .title("Fabulous Gallery")
                .menu(createMenu model)
        )
            .trayIcon(trayIcons())
