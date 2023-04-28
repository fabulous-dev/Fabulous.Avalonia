namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open Gallery

module App =

    type Model =
        { WidgetModel: Samples.Model
          Controls: string seq
          IsPanOpen: bool
          SafeAreaInsets: float
          PaneLength: float }

    type Msg =
        | WidgetPageMsg of Samples.Msg
        | SelectedChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | OpenPan
        | DoNothing
        | OnLoaded of bool

    let pages =
        [| Pages.AcrylicPage
           Pages.AdornerLayerPage
           Pages.AutoCompleteBoxPage
           Pages.AnimationsPage
           Pages.ButtonsPage
           Pages.BrushesPage
           Pages.ButtonSpinnerPage
           Pages.BorderPage
           Pages.CalendarPage
           Pages.CalendarDatePickerPage
           Pages.CanvasPage
           Pages.CheckBoxPage
           Pages.CarouselPage
           Pages.ComboBoxPage
           Pages.ContextMenuPage
           Pages.ContextFlyoutPage
           Pages.ClippingPage
           Pages.DockPanelPage
           Pages.DropDownButtonPage
           Pages.DrawingPage
           Pages.ExpanderPage
           Pages.FlyoutPage
           Pages.FormattedTextPage
           Pages.GesturesPage
           Pages.GlyphRunControlPage
           Pages.GridPage
           Pages.GridSplitterPage
           Pages.ImagePage
           Pages.LabelPage
           Pages.LayoutTransformControlPage
           Pages.ListBoxPage
           Pages.MenuFlyoutPage
           Pages.MaskedTextBoxPage
           Pages.MenuPage
           Pages.NumericUpDownPage
           Pages.ProgressBarPage
           Pages.PanelPage
           Pages.PathIconPage
           Pages.PopupPage
           Pages.PageTransitionsPage
           Pages.RepeatButtonPage
           Pages.RadioButtonPage
           Pages.RefreshContainerPage
           Pages.SelectableTextBlockPage
           Pages.SplitButtonPage
           Pages.SliderPage
           Pages.ShapesPage
           Pages.ScrollBarPage
           Pages.SplitViewPage
           Pages.StackPanelPage
           Pages.ScrollViewerPage
           Pages.ToggleSplitButtonPage
           Pages.TextBlockPage
           Pages.TextBoxPage
           Pages.TickBarPage
           Pages.ToggleSwitchPage
           Pages.ToggleButtonPage
           Pages.ToolTipPage
           Pages.TabControlPage
           Pages.TabStripPage
           Pages.TransitionsPage
           Pages.TransformsPage
           Pages.ThemeAwarePage
           Pages.UniformGridPage
           Pages.ViewBoxPage |]

    let init () =

        { WidgetModel = Samples.init(Pages.AcrylicPage)
          IsPanOpen = true
          Controls = pages |> Array.map Pages.Translate
          SafeAreaInsets = 0.
          PaneLength = 250. },
        Cmd.none

    let update msg model =
        match msg with
        | OnLoaded _ ->
#if MOBILE
            { model with
                SafeAreaInsets = 32.
                PaneLength = 180. },
            Cmd.none
#else
            model, Cmd.none
#endif
        | DoNothing -> model, Cmd.none
        | WidgetPageMsg msg ->
            let m, c = Samples.update msg model.WidgetModel
            { model with WidgetModel = m }, Cmd.batch [ (Cmd.map WidgetPageMsg c) ]
        | SelectedChanged args ->
            let control = args.Source :?> ListBox

            let page = pages.[control.SelectedIndex]

            let model =
                { model with
                    WidgetModel = Samples.init(page) }

            model, Cmd.none

        | OpenPanChanged x -> { model with IsPanOpen = x }, Cmd.none

        | OpenPan ->
            { model with
                IsPanOpen = not model.IsPanOpen },
            Cmd.none

    let hamburgerMenuIcon () =
        Path("M1,4 H18 V6 H1 V4 M1,9 H18 V11 H1 V7 M3,14 H18 V16 H1 V14")
            .fill(SolidColorBrush(Colors.Black))

    let buttonSpinnerHeader (model: Model) =
        ScrollViewer(
            VStack(16.) {
                Image(ImageSource.fromString "avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .size(100., 100.)

                TextBlock("Fabulous Gallery").centerHorizontal()

                ListBox(model.Controls, (fun x -> TextBlock(x)))
                    .selectionMode(SelectionMode.Single)
                    .onSelectionChanged(SelectedChanged)
            }
        )
            .padding(0., model.SafeAreaInsets, 0., 0.)

    let view model =
        (Grid() {
            let content = View.map WidgetPageMsg (Samples.view model.WidgetModel)

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

#if MOBILE || BROWSER
    let app model = SingleViewApplication(view model)
#else
    let app model =
        DesktopApplication(
            Window(view model)
                .background(SolidColorBrush(Colors.Transparent))
                .title("Fabulous Gallery")
                .menu(createMenu model)
        )
            .trayIcons() {
            trayIcons()
        }
#endif

    let program =
        Program.statefulWithCmd init update app
        |> Program.withThemeAwareness
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
