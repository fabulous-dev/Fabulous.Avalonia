namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module App =

    type Model =
        { WidgetModel: WidgetPage.Model
          Controls: string list
          SelectedIndex: int
          IsPanOpen: bool
          SafeAreaInsets: float
          PaneLength: float }

    type Msg =
        | WidgetPageMsg of WidgetPage.Msg
        | SelectedChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | OpenPan
        | DoNothing
        | OnLoaded of bool

    let init () =

        { WidgetModel = WidgetPage.init(0)
          IsPanOpen = true
          Controls = WidgetPage.samples |> List.map(fun s -> s.Name)
          SafeAreaInsets = 0.
          SelectedIndex = 0
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
            let m, c = WidgetPage.update msg model.WidgetModel
            { model with WidgetModel = m }, Cmd.batch [ (Cmd.map WidgetPageMsg c) ]
        | SelectedChanged args ->
            let control = args.Source :?> ListBox

            let model =
                { model with
                    WidgetModel = WidgetPage.init control.SelectedIndex
                    IsPanOpen = true
                    SelectedIndex = control.SelectedIndex }

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
            let content =
                View.map WidgetPageMsg ((WidgetPage.view model.WidgetModel).margin(16.))

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
        |> Program.withExceptionHandler(fun ex ->
            Debug.WriteLine(ex.ToString())
            true)
#if DEBUG
        |> Program.withLogger
            { ViewHelpers.defaultLogger() with
                MinLogLevel = LogLevel.Debug }
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
#endif
