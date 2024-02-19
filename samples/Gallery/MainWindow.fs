namespace Gallery

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Markup.Xaml.Styling
open Fabulous.Avalonia
open type Fabulous.Avalonia.View

open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous
open type Fabulous.Avalonia.View

module MainWindow =
    type Model =
        { ThemeVariants: ThemeVariant list
          FlowDirections: FlowDirection list
          TransparencyLevels: WindowTransparencyLevel list }

    type Msg =
        | DecorationsOnSelectionChanged of SelectionChangedEventArgs
        | ThemeVariantsOnSelectionChanged of SelectionChangedEventArgs
        | FlowDirectionsOnSelectionChanged of SelectionChangedEventArgs
        | TransparencyLevelsOnSelectionChanged of SelectionChangedEventArgs
        | DoNothing

    let init () =
        { ThemeVariants = [ ThemeVariant.Default; ThemeVariant.Dark; ThemeVariant.Light ]
          FlowDirections = [ FlowDirection.LeftToRight; FlowDirection.RightToLeft ]
          TransparencyLevels =
            [ WindowTransparencyLevel.None
              WindowTransparencyLevel.AcrylicBlur
              WindowTransparencyLevel.Blur
              WindowTransparencyLevel.Mica
              WindowTransparencyLevel.Transparent ] },
        Cmd.none

    let update msg model =
        match msg with
        | DecorationsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = args.SelectedItem :?> ComboBoxItem
            let decoration = SystemDecorations.Parse(content.Content.ToString())
            FabApplication.Current.MainWindow.SystemDecorations <- decoration
            model, Cmd.none
        | ThemeVariantsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = model.ThemeVariants[args.SelectedIndex]
            FabApplication.Current.RequestedThemeVariant <- content
            model, Cmd.none
        | FlowDirectionsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = model.FlowDirections[args.SelectedIndex]
            FabApplication.Current.TopLevel.FlowDirection <- content
            model, Cmd.none
        | TransparencyLevelsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let _content = model.TransparencyLevels[args.SelectedIndex]
            model, Cmd.none
        | DoNothing -> model, Cmd.none


    let createMenu () =
        NativeMenu() {
            NativeMenuItem("Edit")
                .menu(
                    NativeMenu() {
                        NativeMenuItem("Close Pan", DoNothing)
                        NativeMenuItem("Open Pan", DoNothing)
                        NativeMenuItemSeparator()

                        NativeMenuItem("After separator", DoNothing)
                            .toggleType(NativeMenuItemToggleType.CheckBox)
                    }
                )
        }

    let trayIcon () =
        TrayIcon("avares://Gallery/Assets/Icons/logo.ico", "Avalonia Tray Icon Tooltip")
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

    let hamburgerMenu model =
        (HamburgerMenu() {
            TabItem("AcrylicPage", AcrylicPage.view())
            TabItem("AdornerLayerPage", AdornerLayerPage.view())
            TabItem("AutoCompleteBoxPage", AutoCompleteBoxPage.view())
            TabItem("ButtonsPage", ButtonsPage.view())
            TabItem("ButtonSpinnerPage", ButtonSpinnerPage.view())
            TabItem("BorderPage", BorderPage.view())
            TabItem("CalendarPage", CalendarPage.view())
            TabItem("CalendarDatePickerPage", CalendarDatePickerPage.view())
            TabItem("CanvasPage", CanvasPage.view())
            TabItem("CheckBoxPage", CheckBoxPage.view())
            TabItem("CarouselPage", CarouselPage.view())
            TabItem("ComboBoxPage", ComboBoxPage.view())
            TabItem("ColorPickerPage", ColorPickerPage.view())
            TabItem("CompositionPage", CompositionPageControl())
            TabItem("ContextMenuPage", ContextMenuPage.view())
            TabItem("CursorPage", CursorPage.view())
            TabItem("ContextFlyoutPage", ContextFlyoutPage.view())
            TabItem("ClipboardPage", ClipboardPage.view())
            TabItem("DataGridPage", DataGridPage.view())
            TabItem("DockPanelPage", DockPanelPage.view())
            TabItem("DialogsPage", DialogsPage.view())
            TabItem("DragAndDropPage", DragAndDropPage.view())
            TabItem("DropDownButtonPage", DropDownButtonPage.view())
            TabItem("EffectsPage", EffectsPage.view())
            TabItem("ExpanderPage", ExpanderPage.view())
            TabItem("FlyoutPage", FlyoutPage.view())
            TabItem("GesturesPage", GesturesPage.view())
            TabItem("GeometriesPage", GeometriesPage.view())
            TabItem("GridPage", GridPage.view())
            TabItem("GridSplitterPage", GridSplitterPage.view())
            TabItem("ImagePage", ImagePage.view())
            TabItem("ItemsRepeaterPage", ItemsRepeaterPage.view())
            TabItem("LabelPage", LabelPage.view())
            TabItem("LayoutTransformControlPage", LayoutTransformControlPage.view())
            TabItem("ListBoxPage", ListBoxPage.view())
            TabItem("MenuFlyoutPage", MenuFlyoutPage.view())
            TabItem("MaskedTextBoxPage", MaskedTextBoxPage.view())
            TabItem("MenuPage", MenuPage.view())
            TabItem("NumericUpDownPage", NumericUpDownPage.view())
            TabItem("NotificationsPage", NotificationsPage.view())
            TabItem("OpenGLPage", OpenGLPage.view())
            TabItem("ProgressBarPage", ProgressBarPage.view())
            TabItem("PanelPage", PanelPage.view())
            TabItem("PathIconPage", PathIconPage.view())
            TabItem("PointersPage", PointersPage.view())
            TabItem("PopupPage", PopupPage.view())
            TabItem("PageTransitionsPage", PageTransitionsPage.view())
            TabItem("RepeatButtonPage", RepeatButtonPage.view())
            TabItem("RadioButtonPage", RadioButtonPage.view())
            TabItem("RefreshContainerPage", RefreshContainerPage.view())
            TabItem("SelectableTextBlockPage", SelectableTextBlockPage.view())
            TabItem("SplitButtonPage", SplitButtonPage.view())
            TabItem("SliderPage", SliderPage.view())
            TabItem("ShapesPage", ShapesPage.view())
            TabItem("ScrollBarPage", ScrollBarPage.view())
            TabItem("SplitViewPage", SplitViewPage.view())
            TabItem("StackPanelPage", StackPanelPage.view())
            TabItem("StylesPage", StylesPage.view())
            TabItem("ScrollViewerPage", ScrollViewerPage.view())
            TabItem("ToggleSplitButtonPage", ToggleSplitButtonPage.view())
            TabItem("TextBlockPage", TextBlockPage.view())
            TabItem("TextBoxPage", TextBoxPage.view())
            TabItem("TickBarPage", TickBarPage.view())
            TabItem("ToggleSwitchPage", ToggleSwitchPage.view())
            TabItem("ToggleButtonPage", ToggleButtonPage.view())
            TabItem("ToolTipPage", ToolTipPage.view())
            TabItem("TabControlPage", TabControlPage.view())
            TabItem("TreeViewPage", TreeViewPage.view())
            TabItem("TreeDataGridViewPage", TreeDataGridPage.view())
            TabItem("TransitioningContentPage", TransitioningContentControlPage.view())
            TabItem("TabStripPage", TabStripPage.view())
            TabItem("ThemeAwarePage", ThemeAwarePage.view())
            TabItem("UniformGridPage", UniformGridPage.view())
            TabItem("ViewBoxPage", ViewBoxPage.view())
        })
            .expandedModeThresholdWidth(760)
            .attachedFlyout(
                Flyout(
                    VStack() {
                        (ComboBox() {
                            ComboBoxItem("None")
                            ComboBoxItem("BorderOnly")
                            ComboBoxItem("Full")
                        })
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .placeholderText("Decorations")
                            .onSelectionChanged(DecorationsOnSelectionChanged)

                        ComboBox(model.ThemeVariants, (fun i -> TextBlock(i.ToString())))
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .placeholderText("Themes")
                            .onSelectionChanged(ThemeVariantsOnSelectionChanged)

                        ComboBox(model.FlowDirections, (fun x -> TextBlock(x.ToString())))
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .placeholderText("FlowDirections")
                            .onSelectionChanged(FlowDirectionsOnSelectionChanged)

                        (ComboBox() {
                            ComboBoxItem("Fluent")
                            ComboBoxItem("Simple")
                        })
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .selectedIndex(0)

                        ComboBox(model.TransparencyLevels, (fun x -> TextBlock(x.ToString())))
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .placeholderText("TransparencyLevels")
                            .onSelectionChanged(TransparencyLevelsOnSelectionChanged)

                        (ComboBox() {
                            ComboBoxItem("Normal")
                            ComboBoxItem("Minimized")
                            ComboBoxItem("Maximized")
                            ComboBoxItem("FullScreen")
                        })
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .selectedIndex(0)
                    }
                )
                    .showMode(FlyoutShowMode.Standard)
                    .placement(PlacementMode.RightEdgeAlignedTop)
            )

    let view model =
        DesktopApplication() {
            (Window() { hamburgerMenu model })
                .title("Fabulous Gallery")
                .menu(createMenu())
                .width(1024.)
                .height(800.)
                .icon("avares://Gallery/Assets/Icons/logo.ico")
        }
        |> _.trayIcon(trayIcon())

    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://Gallery/App.xaml"))

        let program =
            Program.statefulWithCmd init update
            |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
            |> Program.withExceptionHandler(fun ex ->
#if DEBUG
                printfn $"Exception: %s{ex.ToString()}"
                false
#else
                true
#endif
            )
            |> Program.withView view

        FabulousAppBuilder.Configure(theme, program)
