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

                (ListBox() {
                    ListBoxItem("AcrylicPage", true)
                    ListBoxItem("AdornerLayerPage")
                    ListBoxItem("AutoCompleteBoxPage")
                    ListBoxItem("AnimationsPage")
                    ListBoxItem("ImplicitCanvasAnimationsPage")
                    ListBoxItem("CompositorAnimationsPage")
                    ListBoxItem("ButtonsPage")
                    ListBoxItem("BrushesPage")
                    ListBoxItem("ButtonSpinnerPage")
                    ListBoxItem("BorderPage")
                    ListBoxItem("CalendarPage")
                    ListBoxItem("CalendarDatePickerPage")
                    ListBoxItem("CanvasPage")
                    ListBoxItem("CheckBoxPage")
                    ListBoxItem("CarouselPage")
                    ListBoxItem("ComboBoxPage")
                    ListBoxItem("ContextMenuPage")
                    ListBoxItem("ContextFlyoutPage")
                    ListBoxItem("ClippingPage")
                    ListBoxItem("ClipboardPage")
                    ListBoxItem("DockPanelPage")
                    ListBoxItem("DialogsPage")
                    ListBoxItem("DragAndDropPage")
                    ListBoxItem("DropDownButtonPage")
                    ListBoxItem("DrawLineAnimationPage")
                    ListBoxItem("DrawingPage")
                    ListBoxItem("ExpanderPage")
                    ListBoxItem("FlyoutPage")
                    //ListBoxItem("GesturesPage")
                    ListBoxItem("GeometriesPage")
                    ListBoxItem("GlyphRunControlPage")
                    ListBoxItem("GridPage")
                    ListBoxItem("GridSplitterPage")
                    ListBoxItem("ImagePage")
                    ListBoxItem("LabelPage")
                    ListBoxItem("LayoutTransformControlPage")
                    ListBoxItem("LineBoundsDemoControlPage")
                    ListBoxItem("ListBoxPage")
                    ListBoxItem("MenuFlyoutPage")
                    ListBoxItem("MaskedTextBoxPage")
                    ListBoxItem("MenuPage")
                    ListBoxItem("NumericUpDownPage")
                    ListBoxItem("NotificationsPage")
                    ListBoxItem("ProgressBarPage")
                    ListBoxItem("PanelPage")
                    ListBoxItem("PathIconPage")
                    ListBoxItem("PopupPage")
                    ListBoxItem("PageTransitionsPage")
                    ListBoxItem("RepeatButtonPage")
                    ListBoxItem("RadioButtonPage")
                    //ListBoxItem("RefreshContainerPage")
                    ListBoxItem("SelectableTextBlockPage")
                    ListBoxItem("SplitButtonPage")
                    ListBoxItem("SliderPage")
                    ListBoxItem("ShapesPage")
                    ListBoxItem("ScrollBarPage")
                    ListBoxItem("SplitViewPage")
                    ListBoxItem("StackPanelPage")
                    ListBoxItem("ScrollViewerPage")
                    ListBoxItem("ToggleSplitButtonPage")
                    ListBoxItem("TextBlockPage")
                    ListBoxItem("TextBoxPage")
                    ListBoxItem("TickBarPage")
                    ListBoxItem("ToggleSwitchPage")
                    ListBoxItem("ToggleButtonPage")
                    ListBoxItem("ToolTipPage")
                    ListBoxItem("TabControlPage")
                    ListBoxItem("TabStripPage")
                    ListBoxItem("TransitionsPage")
                    ListBoxItem("TransformsPage")
                    ListBoxItem("ThemeAwarePage")
                    ListBoxItem("UniformGridPage")
                    ListBoxItem("ViewBoxPage")
                })
                    .selectionMode(SelectionMode.Single)
                    .onSelectionChanged(OnSelectionChanged)
            }
        )
            .padding(0., 0., 0., 0.)

    let hamburgerMenuIcon () =
        Path(Paths.Path3).fill(SolidColorBrush(Colors.Black))

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
        DesktopApplication(
            Window(
                (Grid() {
                    let content =
                        match model.Navigation.CurrentPage with
                        // ScrollBarPageModel does not work when wrapped in a ScrollViewer
                        | ScrollBarPageModel _ -> AnyView(NavigationState.view SubpageMsg model.Navigation.CurrentPage)
                        | _ -> AnyView(ScrollViewer(NavigationState.view SubpageMsg model.Navigation.CurrentPage))

                    SplitView(buttonSpinnerHeader model, content)
                        .isPresented(model.IsPanOpen, OpenPanChanged)
                        .displayMode(SplitViewDisplayMode.Inline)
                        .panePlacement(SplitViewPanePlacement.Left)

                    Button(OpenPan, hamburgerMenuIcon())
                        .verticalAlignment(VerticalAlignment.Top)
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .margin(4., 0., 0., 0.)
                })
                    .onLoaded(OnLoaded)
            )
                .title("Fabulous Gallery")
                .menu(createMenu model)
        )
            .trayIcon(trayIcon())
