namespace Gallery.Root

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Gallery
open Types
open System
open Avalonia.Animation.Easings

open type Fabulous.Avalonia.View

module MainWindow =
    let buttonSpinnerHeader () =
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
                    ListBoxItem("EffectsPage")
                    ListBoxItem("ExpanderPage")
                    ListBoxItem("FlyoutPage")
                    //ListBoxItem("GesturesPage")
                    ListBoxItem("GeometriesPage")
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
                    ListBoxItem("PointersPage")
                    ListBoxItem("PopupPage")
                    ListBoxItem("PageTransitionsPage")
                    ListBoxItem("RepeatButtonPage")
                    ListBoxItem("RadioButtonPage")
                    ListBoxItem("RefreshContainerPage")
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
                        Dock() {
                            Border(
                                TextBlock(model.HeaderText)
                                    .verticalAlignment(VerticalAlignment.Center)
                                    .margin(
                                        if model.IsPanOpen then
                                            Thickness(12., 0., 0., 0.)
                                        else
                                            Thickness(52., 0., 0., 0.)
                                    )
                                    .transition(
                                        ThicknessTransition(TextBlock.MarginProperty, TimeSpan.FromSeconds(1.))
                                            .easing(SpringEasing(0.1, 0.9, 0.2, 1.0))
                                    )
                            )
                                .dock(Dock.Top)
                                .height(36.)

                            Border(
                                ScrollViewer(
                                    match model.Navigation.CurrentPage with
                                    // ScrollBarPageModel does not work when wrapped in a ScrollViewer
                                    | ScrollBarPageModel _ -> AnyView(NavigationState.view SubpageMsg model.Navigation.CurrentPage)
                                    | _ -> AnyView(ScrollViewer(NavigationState.view SubpageMsg model.Navigation.CurrentPage))
                                )
                                    .verticalScrollBarVisibility(ScrollBarVisibility.Auto)
                                    .horizontalScrollBarVisibility(ScrollBarVisibility.Auto)
                                    .background(Brushes.Transparent)
                                    .padding(Thickness(12., 0., 4., 0.))
                            )
                                .cornerRadius(
                                    if model.IsPanOpen then
                                        CornerRadius(8., 0., 0., 0.)
                                    else
                                        CornerRadius(0., 0., 8., 8.)
                                )
                                .transition(CornerRadiusTransition(Border.CornerRadiusProperty, TimeSpan.FromSeconds(1.)))
                        }

                    SplitView(buttonSpinnerHeader(), content)
                        .isPresented(model.IsPanOpen, OpenPanChanged)
                        .compactPaneLength(40.)
                        .openPaneLength(200.)
                        .displayMode(SplitViewDisplayMode.Inline)
                        .panePlacement(SplitViewPanePlacement.Left)
                        .paneBackground(Brushes.Transparent)

                    ToggleButton(
                        model.IsPanOpen,
                        OpenPanChanged,
                        PathIcon(Paths.Path3)
                            .foreground(ThemeAware.With(Brush.Parse("#99000000"), Brush.Parse("#99FFFFFF")))
                    )
                        .width(40.)
                        .height(32.)
                        .margin(4., 2., 0., 0.)
                        .padding(0.)
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment(VerticalAlignment.Top)
                        .horizontalContentAlignment(HorizontalAlignment.Center)
                        .cornerRadius(4.)
                })
                    .onLoaded(OnLoaded)
            )
                .title("Fabulous Gallery")
                .menu(createMenu model)
        )
            .trayIcon(trayIcon())
            .onColorValuesChanged(OnColorValuesChanged)
