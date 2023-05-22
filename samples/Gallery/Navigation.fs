namespace Gallery

open Gallery

[<RequireQualifiedAccess>]
type NavigationRoute =
    | AcrylicPage
    | AdornerLayerPage
    | AutoCompleteBoxPage
    | AnimationsPage
    | ButtonsPage
    | BrushesPage
    | ButtonSpinnerPage
    | BorderPage
    | CalendarPage
    | CalendarDatePickerPage
    | CanvasPage
    | CheckBoxPage
    | CarouselPage
    | ComboBoxPage
    | ContextMenuPage
    | ContextFlyoutPage
    | ClippingPage
    | DockPanelPage
    | DropDownButtonPage
    | DrawingPage
    | ExpanderPage
    | FlyoutPage
    | GesturesPage
    | GeometriesPage
    | GlyphRunControlPage
    | GridPage
    | GridSplitterPage
    | ImagePage
    | LabelPage
    | LayoutTransformControlPage
    | ListBoxPage
    | MenuFlyoutPage
    | MaskedTextBoxPage
    | MenuPage
    | NumericUpDownPage
    | NotificationsPage
    | ProgressBarPage
    | PanelPage
    | PathIconPage
    | PopupPage
    | PageTransitionsPage
    | RepeatButtonPage
    | RadioButtonPage
    | RefreshContainerPage
    | SelectableTextBlockPage
    | SplitButtonPage
    | SliderPage
    | ShapesPage
    | ScrollBarPage
    | SplitViewPage
    | StackPanelPage
    | ScrollViewerPage
    | ToggleSplitButton
    | TextBlockPage
    | TextBoxPage
    | TickBarPage
    | ToggleSwitchPage
    | ToggleButtonPage
    | ToolTipPage
    | TabControlPage
    | TabStripPage
    | TransitionsPage
    | TransformsPage
    | ThemeAwarePage
    | UniformGridPage
    | ViewBoxPage

type NavigationController() =
    let navigationRequested = Event<NavigationRoute>()
    let backNavigationRequested = Event<unit>()

    member this.NavigationRequested = navigationRequested.Publish
    member this.BackNavigationRequested = backNavigationRequested.Publish

    member this.RequestNavigation(route: NavigationRoute) = navigationRequested.Trigger route
    member this.RequestBackNavigation() = backNavigationRequested.Trigger()

module Navigation =
    let internal navigateTo (nav: NavigationController) route =
        Cmd.perform(fun () -> nav.RequestNavigation(route))

    let goBack (nav: NavigationController) =
        Cmd.perform(fun () -> nav.RequestBackNavigation())

    let goToOnboarding nav =
        navigateTo nav NavigationRoute.AcrylicPage

    let goToHome nav =
        navigateTo nav NavigationRoute.AdornerLayerPage
