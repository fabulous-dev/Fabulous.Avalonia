namespace Gallery.Root

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Gallery
open Types

open type Fabulous.Avalonia.View

module MainWindow =
    let buttonSpinnerHeader (model: Model) =
        ScrollViewer(
            VStack(16.) {
                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .size(100., 100.)

                TextBlock("Fabulous Gallery").centerHorizontal()

                ListBox(model.Pages, (fun x -> TextBlock(x)))
                    .selectionMode(SelectionMode.Single)
                    .onSelectedIndexChanged(model.SelectedIndex, SelectedIndexChanged)
            }
        )
            .padding(0., model.SafeAreaInsets, 0., 0.)

    let hamburgerMenuIcon () =
        Path(Paths.Path3).fill(SolidColorBrush(Colors.Black))

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

                                NativeMenuItem("Disabled option", DoNothing).isEnabled(false)
                            }
                        )

                    NativeMenuItem("Exit", DoNothing)
                }
            )

    let view (model: Model) =
        DesktopApplication(
            Window(
                (Grid() {
                    let content = NavigationState.view SubpageMsg model.Navigation.CurrentPage

                    SplitView(buttonSpinnerHeader model, content)
                        .isPresented(model.IsPanOpen, OpenPanChanged)
                        .displayMode(SplitViewDisplayMode.Inline)
                        .panePlacement(SplitViewPanePlacement.Left)

                    Button(OpenPan, hamburgerMenuIcon())
                        .verticalAlignment(VerticalAlignment.Top)
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .margin(4., model.SafeAreaInsets, 0., 0.)
                })
                    .onLoaded(OnLoaded)
            )
                .title("Fabulous Gallery")
        )
            .trayIcon(trayIcon())
