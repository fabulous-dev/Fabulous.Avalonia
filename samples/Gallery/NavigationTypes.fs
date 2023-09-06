namespace Gallery

[<RequireQualifiedAccess>]
type NavigationRoute =
    | AcrylicPage
    | AdornerLayerPage
    | AutoCompleteBoxPage
    | AnimationsPage
    | ImplicitCanvasAnimationsPage
    | CompositorAnimationsPage
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
    | CompositionPage
    | ContextMenuPage
    | ContextFlyoutPage
    | ClippingPage
    | ClipboardPage
    | DockPanelPage
    | DialogsPage
    | DragAndDropPage
    | DropDownButtonPage
    | DrawingPage
    | DrawLineAnimationPage
    | EffectsPage
    | ExpanderPage
    | FlyoutPage
    | GesturesPage
    | GeometriesPage
    | GridPage
    | GridSplitterPage
    | ImagePage
    | LabelPage
    | LayoutTransformControlPage
    | LineBoundsDemoControlPage
    | ListBoxPage
    | MenuFlyoutPage
    | MaskedTextBoxPage
    | MenuPage
    | NumericUpDownPage
    | NotificationsPage
    | ProgressBarPage
    | OpenGLPage
    | PanelPage
    | PathIconPage
    | PopupPage
    | PointersPage
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
    | StylesPage
    | ScrollViewerPage
    | ToggleSplitButtonPage
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

    static member GetRoute(route: string) =
        match route with
        | "AcrylicPage" -> AcrylicPage
        | "AdornerLayerPage" -> AdornerLayerPage
        | "AutoCompleteBoxPage" -> AutoCompleteBoxPage
        | "AnimationsPage" -> AnimationsPage
        | "ImplicitCanvasAnimationsPage" -> ImplicitCanvasAnimationsPage
        | "CompositorAnimationsPage" -> CompositorAnimationsPage
        | "ButtonsPage" -> ButtonsPage
        | "BrushesPage" -> BrushesPage
        | "ButtonSpinnerPage" -> ButtonSpinnerPage
        | "BorderPage" -> BorderPage
        | "CalendarPage" -> CalendarPage
        | "CalendarDatePickerPage" -> CalendarDatePickerPage
        | "CanvasPage" -> CanvasPage
        | "CheckBoxPage" -> CheckBoxPage
        | "CarouselPage" -> CarouselPage
        | "ComboBoxPage" -> ComboBoxPage
        | "CompositionPage" -> CompositionPage
        | "ContextMenuPage" -> ContextMenuPage
        | "ContextFlyoutPage" -> ContextFlyoutPage
        | "ClippingPage" -> ClippingPage
        | "ClipboardPage" -> ClipboardPage
        | "DockPanelPage" -> DockPanelPage
        | "DragAndDropPage" -> DragAndDropPage
        | "DialogsPage" -> DialogsPage
        | "DropDownButtonPage" -> DropDownButtonPage
        | "DrawLineAnimationPage" -> DrawLineAnimationPage
        | "DrawingPage" -> DrawingPage
        | "EffectsPage" -> EffectsPage
        | "ExpanderPage" -> ExpanderPage
        | "FlyoutPage" -> FlyoutPage
        | "GesturesPage" -> GesturesPage
        | "GeometriesPage" -> GeometriesPage
        | "GridPage" -> GridPage
        | "GridSplitterPage" -> GridSplitterPage
        | "ImagePage" -> ImagePage
        | "LabelPage" -> LabelPage
        | "LayoutTransformControlPage" -> LayoutTransformControlPage
        | "LineBoundsDemoControlPage" -> LineBoundsDemoControlPage
        | "ListBoxPage" -> ListBoxPage
        | "MenuFlyoutPage" -> MenuFlyoutPage
        | "MaskedTextBoxPage" -> MaskedTextBoxPage
        | "MenuPage" -> MenuPage
        | "NumericUpDownPage" -> NumericUpDownPage
        | "NotificationsPage" -> NotificationsPage
        | "OpenGLPage" -> OpenGLPage
        | "ProgressBarPage" -> ProgressBarPage
        | "PanelPage" -> PanelPage
        | "PathIconPage" -> PathIconPage
        | "PopupPage" -> PopupPage
        | "PointersPage" -> PointersPage
        | "PageTransitionsPage" -> PageTransitionsPage
        | "RepeatButtonPage" -> RepeatButtonPage
        | "RadioButtonPage" -> RadioButtonPage
        | "RefreshContainerPage" -> RefreshContainerPage
        | "SelectableTextBlockPage" -> SelectableTextBlockPage
        | "SplitButtonPage" -> SplitButtonPage
        | "SliderPage" -> SliderPage
        | "ShapesPage" -> ShapesPage
        | "ScrollBarPage" -> ScrollBarPage
        | "SplitViewPage" -> SplitViewPage
        | "StylesPage" -> StylesPage
        | "StackPanelPage" -> StackPanelPage
        | "ScrollViewerPage" -> ScrollViewerPage
        | "ToggleSplitButtonPage" -> ToggleSplitButtonPage
        | "TextBlockPage" -> TextBlockPage
        | "TextBoxPage" -> TextBoxPage
        | "TickBarPage" -> TickBarPage
        | "ToggleSwitchPage" -> ToggleSwitchPage
        | "ToggleButtonPage" -> ToggleButtonPage
        | "ToolTipPage" -> ToolTipPage
        | "TabControlPage" -> TabControlPage
        | "TabStripPage" -> TabStripPage
        | "TransitionsPage" -> TransitionsPage
        | "TransformsPage" -> TransformsPage
        | "ThemeAwarePage" -> ThemeAwarePage
        | "UniformGridPage" -> UniformGridPage
        | "ViewBoxPage" -> ViewBoxPage
        | _ -> failwithf $"Unknown route: %s{route}"
