namespace Gallery.Root

open System
open Avalonia.Controls
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open Types
open Avalonia.Themes.Fluent
open type Fabulous.Avalonia.View

module MainWindow =
    let createMenu model =
        NativeMenu() {
            NativeMenuItem("Edit")
                .menu(
                    NativeMenu() {
                        NativeMenuItem((if model.IsPanOpen then "Close Pan" else "Open Pan"), DoNothing)
                        NativeMenuItemSeparator()

                        NativeMenuItem("After separator", DoNothing)
                            .toggleType(NativeMenuItemToggleType.CheckBox)
                            .isChecked(model.IsPanOpen)
                    }
                )
        }

    let trayIcon () =
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

                                NativeMenuItem("Disabled option", DoNothing)
                                    .isEnabled(false)
                            }
                        )

                    NativeMenuItem("Exit", DoNothing)
                }
            )

    let view (model: Model) =
        //FabApplication.Current.AppTheme <- FluentTheme()
        let theme = StyleInclude(baseUri = null)
        theme.Source <- Uri("avares://Gallery/Styles/DefaultTheme.xaml")
        let textStyles = StyleInclude(baseUri = null)
        textStyles.Source <- Uri("avares://Gallery/Styles/TextStyles.xaml")
        FabApplication.Current.Styles.AddRange([ theme; textStyles ])

        DesktopApplication(
            Window(Panel() { HamburgerMenu.mainView model })
                .title("Fabulous Gallery")
                .menu(createMenu model)
                .width(1024.)
                .height(800.)
                .icon(WindowIcon(ImageSource.fromString "avares://Gallery/Assets/Icons/logo.ico"))
        )
            .trayIcon(trayIcon())
//Enable this only for debugging purposes
//.debugOverlays(RendererDebugOverlays.Fps ||| RendererDebugOverlays.DirtyRects)
