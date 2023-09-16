namespace Gallery.Root

open Gallery
open Gallery.Pages
open Fabulous
open Fabulous.Avalonia

[<RequireQualifiedAccess>]
type NavigationRoute =
    | AcrylicPage
    | AdornerLayerPage
    | AutoCompleteBoxPage
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
    | TransformsPage
    | ThemeAwarePage
    | UniformGridPage
    | ViewBoxPage

    static member GetRoute(route: string) =
        match route with
        | "AcrylicPage" -> AcrylicPage
        | "AdornerLayerPage" -> AdornerLayerPage
        | "AutoCompleteBoxPage" -> AutoCompleteBoxPage
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
        | "TransformsPage" -> TransformsPage
        | "ThemeAwarePage" -> ThemeAwarePage
        | "UniformGridPage" -> UniformGridPage
        | "ViewBoxPage" -> ViewBoxPage
        | _ -> failwithf $"Unknown route: %s{route}"

type SubpageModel =
    | AcrylicPageModel of AcrylicPage.Model
    | AdornerLayerPageModel of AdornerLayerPage.Model
    | AutoCompleteBoxPageModel of AutoCompleteBoxPage.Model
    | ButtonsPageModel of ButtonsPage.Model
    | BrushesPageModel of BrushesPage.Model
    | ButtonSpinnerPageModel of ButtonSpinnerPage.Model
    | BorderPageModel of BorderPage.Model
    | CalendarPageModel of CalendarPage.Model
    | CalendarDatePickerPageModel of CalendarDatePickerPage.Model
    | CanvasPageModel of CanvasPage.Model
    | CheckBoxPageModel of CheckBoxPage.Model
    | CarouselPageModel of CarouselPage.Model
    | ComboBoxPageModel of ComboBoxPage.Model
    | CompositionPageModel of CompositionPage.Model
    | ContextMenuPageModel of ContextMenuPage.Model
    | ContextFlyoutPageModel of ContextFlyoutPage.Model
    | ClippingPageModel of ClippingPage.Model
    | ClipboardPageModel of ClipboardPage.Model
    | DialogsPageModel of DialogsPage.Model
    | DragAndDropPageModel of DragAndDropPage.Model
    | DockPanelPageModel of DockPanelPage.Model
    | DropDownButtonPageModel of DropDownButtonPage.Model
    | DrawingPageModel of DrawingPage.Model
    | EffectsPageModel of EffectsPage.Model
    | ExpanderPageModel of ExpanderPage.Model
    | FlyoutPageModel of FlyoutPage.Model
    | GesturesPageModel of GesturesPage.Model
    | GeometriesPageModel of GeometriesPage.Model
    | GridPageModel of GridPage.Model
    | GridSplitterPageModel of GridSplitterPage.Model
    | ImagePageModel of ImagePage.Model
    | LabelPageModel of LabelPage.Model
    | LayoutTransformControlPageModel of LayoutTransformControlPage.Model
    | LineBoundsDemoControlPageModel of LineBoundsDemoControlPage.Model
    | ListBoxPageModel of ListBoxPage.Model
    | MenuFlyoutPageModel of MenuFlyoutPage.Model
    | MaskedTextBoxPageModel of MaskedTextBoxPage.Model
    | MenuPageModel of MenuPage.Model
    | NumericUpDownPageModel of NumericUpDownPage.Model
    | NotificationsPageModel of NotificationsPage.Model
    | OpenGLPageModel of OpenGLPage.Model
    | ProgressBarPageModel of ProgressBarPage.Model
    | PanelPageModel of PanelPage.Model
    | PathIconPageModel of PathIconPage.Model
    | PointersPageModel of PointersPage.Model
    | PopupPageModel of PopupPage.Model
    | PageTransitionsPageModel of PageTransitionsPage.Model
    | RepeatButtonPageModel of RepeatButtonPage.Model
    | RadioButtonPageModel of RadioButtonPage.Model
    | RefreshContainerPageModel of RefreshContainerPage.Model
    | SelectableTextBlockPageModel of SelectableTextBlockPage.Model
    | SplitButtonPageModel of SplitButtonPage.Model
    | SliderPageModel of SliderPage.Model
    | ShapesPageModel of ShapesPage.Model
    | ScrollBarPageModel of ScrollBarPage.Model
    | SplitViewPageModel of SplitViewPage.Model
    | StackPanelPageModel of StackPanelPage.Model
    | StylesPageModel of StylesPage.Model
    | ScrollViewerPageModel of ScrollViewerPage.Model
    | ToggleSplitButtonPageModel of ToggleSplitButtonPage.Model
    | TextBlockPageModel of TextBlockPage.Model
    | TextBoxPageModel of TextBoxPage.Model
    | TickBarPageModel of TickBarPage.Model
    | ToggleSwitchPageModel of ToggleSwitchPage.Model
    | ToggleButtonPageModel of ToggleButtonPage.Model
    | ToolTipPageModel of ToolTipPage.Model
    | TabControlPageModel of TabControlPage.Model
    | TabStripPageModel of TabStripPage.Model
    | TransformsPageModel of TransformsPage.Model
    | ThemeAwarePageModel of ThemeAwarePage.Model
    | UniformGridPageModel of UniformGridPage.Model
    | ViewBoxPageModel of ViewBoxPage.Model

    member x.GetSubpageName() =
        match x with
        | AcrylicPageModel _ -> "Acrylic"
        | AdornerLayerPageModel _ -> "AdornerLayer"
        | AutoCompleteBoxPageModel _ -> "AutoCompleteBox"
        | ButtonsPageModel _ -> "Buttons"
        | BrushesPageModel _ -> "Brushes"
        | ButtonSpinnerPageModel _ -> "ButtonSpinner"
        | BorderPageModel _ -> "Border"
        | CalendarPageModel _ -> "Calendar"
        | CalendarDatePickerPageModel _ -> "CalendarDatePicker"
        | CanvasPageModel _ -> "Canvas"
        | CheckBoxPageModel _ -> "CheckBox"
        | CarouselPageModel _ -> "Carousel"
        | ComboBoxPageModel _ -> "ComboBox"
        | CompositionPageModel _ -> "Composition"
        | ContextMenuPageModel _ -> "ContextMenu"
        | ContextFlyoutPageModel _ -> "ContextFlyout"
        | ClippingPageModel _ -> "Clipping"
        | ClipboardPageModel _ -> "Clipboard"
        | DialogsPageModel _ -> "Dialogs"
        | DragAndDropPageModel _ -> "DragAndDrop"
        | DockPanelPageModel _ -> "DockPanel"
        | DropDownButtonPageModel _ -> "DropDownButton"
        | DrawingPageModel _ -> "Drawing"
        | EffectsPageModel _ -> "Effects"
        | ExpanderPageModel _ -> "Expander"
        | FlyoutPageModel _ -> "Flyout"
        | GesturesPageModel _ -> "Gestures"
        | GeometriesPageModel _ -> "Geometries"
        | GridPageModel _ -> "Grid"
        | GridSplitterPageModel _ -> "GridSplitter"
        | ImagePageModel _ -> "Image"
        | LabelPageModel _ -> "Label"
        | LayoutTransformControlPageModel _ -> "LayoutTransformControl"
        | LineBoundsDemoControlPageModel _ -> "LineBoundsDemoControl"
        | ListBoxPageModel _ -> "ListBox"
        | MenuFlyoutPageModel _ -> "MenuFlyout"
        | MaskedTextBoxPageModel _ -> "MaskedTextBox"
        | MenuPageModel _ -> "Menu"
        | NumericUpDownPageModel _ -> "NumericUpDown"
        | NotificationsPageModel _ -> "Notifications"
        | OpenGLPageModel _ -> "OpenGL"
        | ProgressBarPageModel _ -> "ProgressBar"
        | PanelPageModel _ -> "Panel"
        | PathIconPageModel _ -> "PathIcon"
        | PointersPageModel _ -> "Pointers"
        | PopupPageModel _ -> "Popup"
        | PageTransitionsPageModel _ -> "PageTransitions"
        | RepeatButtonPageModel _ -> "RepeatButton"
        | RadioButtonPageModel _ -> "RadioButton"
        | RefreshContainerPageModel _ -> "RefreshContainer"
        | SelectableTextBlockPageModel _ -> "SelectableTextBlock"
        | SplitButtonPageModel _ -> "SplitButton"
        | SliderPageModel _ -> "Slider"
        | ShapesPageModel _ -> "Shapes"
        | ScrollBarPageModel _ -> "ScrollBar"
        | SplitViewPageModel _ -> "SplitView"
        | StackPanelPageModel _ -> "StackPanel"
        | StylesPageModel _ -> "Styles"
        | ScrollViewerPageModel _ -> "ScrollViewer"
        | ToggleSplitButtonPageModel _ -> "ToggleSplitButton"
        | TextBlockPageModel _ -> "TextBlock"
        | TextBoxPageModel _ -> "TextBox"
        | TickBarPageModel _ -> "TickBar"
        | ToggleSwitchPageModel _ -> "ToggleSwitch"
        | ToggleButtonPageModel _ -> "ToggleButton"
        | ToolTipPageModel _ -> "ToolTip"
        | TabControlPageModel _ -> "TabControl"
        | TabStripPageModel _ -> "TabStrip"
        | TransformsPageModel _ -> "Transforms"
        | ThemeAwarePageModel _ -> "ThemeAware"
        | UniformGridPageModel _ -> "UniformGrid"
        | ViewBoxPageModel _ -> "ViewBox"

type SubpageMsg =
    | AcrylicPageMsg of AcrylicPage.Msg
    | AdornerLayerPageMsg of AdornerLayerPage.Msg
    | AutoCompleteBoxPageMsg of AutoCompleteBoxPage.Msg
    | ButtonsPageMsg of ButtonsPage.Msg
    | BrushesPageMsg of BrushesPage.Msg
    | ButtonSpinnerPageMsg of ButtonSpinnerPage.Msg
    | BorderPageMsg of BorderPage.Msg
    | CalendarPageMsg of CalendarPage.Msg
    | CalendarDatePickerPageMsg of CalendarDatePickerPage.Msg
    | CanvasPageMsg of CanvasPage.Msg
    | CheckBoxPageMsg of CheckBoxPage.Msg
    | CarouselPageMsg of CarouselPage.Msg
    | ComboBoxPageMsg of ComboBoxPage.Msg
    | CompositionPageMsg of CompositionPage.Msg
    | ContextMenuPageMsg of ContextMenuPage.Msg
    | ContextFlyoutPageMsg of ContextFlyoutPage.Msg
    | ClippingPageMsg of ClippingPage.Msg
    | ClipboardPageMsg of ClipboardPage.Msg
    | DockPanelPageMsg of DockPanelPage.Msg
    | DialogsPageMsg of DialogsPage.Msg
    | DragAndDropPageMsg of DragAndDropPage.Msg
    | DropDownButtonPageMsg of DropDownButtonPage.Msg
    | DrawingPageMsg of DrawingPage.Msg
    | EffectsPageMsg of EffectsPage.Msg
    | ExpanderPageMsg of ExpanderPage.Msg
    | FlyoutPageMsg of FlyoutPage.Msg
    | GesturesPageMsg of GesturesPage.Msg
    | GeometriesPageMsg of GeometriesPage.Msg
    | GridPageMsg of GridPage.Msg
    | GridSplitterPageMsg of GridSplitterPage.Msg
    | ImagePageMsg of ImagePage.Msg
    | LabelPageMsg of LabelPage.Msg
    | LayoutTransformControlPageMsg of LayoutTransformControlPage.Msg
    | LineBoundsDemoControlPageMsg of LineBoundsDemoControlPage.Msg
    | ListBoxPageMsg of ListBoxPage.Msg
    | MenuFlyoutPageMsg of MenuFlyoutPage.Msg
    | MaskedTextBoxPageMsg of MaskedTextBoxPage.Msg
    | MenuPageMsg of MenuPage.Msg
    | NumericUpDownPageMsg of NumericUpDownPage.Msg
    | NotificationsPageMsg of NotificationsPage.Msg
    | OpenGLPageMsg of OpenGLPage.Msg
    | ProgressBarPageMsg of ProgressBarPage.Msg
    | PanelPageMsg of PanelPage.Msg
    | PathIconPageMsg of PathIconPage.Msg
    | PopupPageMsg of PopupPage.Msg
    | PointersPageMsg of PointersPage.Msg
    | PageTransitionsPageMsg of PageTransitionsPage.Msg
    | RepeatButtonPageMsg of RepeatButtonPage.Msg
    | RadioButtonPageMsg of RadioButtonPage.Msg
    | RefreshContainerPageMsg of RefreshContainerPage.Msg
    | SelectableTextBlockPageMsg of SelectableTextBlockPage.Msg
    | SplitButtonPageMsg of SplitButtonPage.Msg
    | SliderPageMsg of SliderPage.Msg
    | ShapesPageMsg of ShapesPage.Msg
    | ScrollBarPageMsg of ScrollBarPage.Msg
    | SplitViewPageMsg of SplitViewPage.Msg
    | StackPanelPageMsg of StackPanelPage.Msg
    | StylesPageMsg of StylesPage.Msg
    | ScrollViewerPageMsg of ScrollViewerPage.Msg
    | ToggleSplitButtonPageMsg of ToggleSplitButtonPage.Msg
    | TextBlockPageMsg of TextBlockPage.Msg
    | TextBoxPageMsg of TextBoxPage.Msg
    | TickBarPageMsg of TickBarPage.Msg
    | ToggleSwitchPageMsg of ToggleSwitchPage.Msg
    | ToggleButtonPageMsg of ToggleButtonPage.Msg
    | ToolTipPageMsg of ToolTipPage.Msg
    | TabControlPageMsg of TabControlPage.Msg
    | TabStripPageMsg of TabStripPage.Msg
    | TransformsPageMsg of TransformsPage.Msg
    | ThemeAwarePageMsg of ThemeAwarePage.Msg
    | UniformGridPageMsg of UniformGridPage.Msg
    | ViewBoxPageMsg of ViewBoxPage.Msg

type SubpageCmdMsg =
    | AcrylicPageCmdMsgs of AcrylicPage.CmdMsg list
    | AdornerLayerPageCmdMsgs of AdornerLayerPage.CmdMsg list
    | AutoCompleteBoxPageCmdMsgs of AutoCompleteBoxPage.CmdMsg list
    | ButtonsPageCmdMsgs of ButtonsPage.CmdMsg list
    | BrushesPageCmdMsgs of BrushesPage.CmdMsg list
    | ButtonSpinnerPageCmdMsgs of ButtonSpinnerPage.CmdMsg list
    | BorderPageCmdMsgs of BorderPage.CmdMsg list
    | CalendarPageCmdMsgs of CalendarPage.CmdMsg list
    | CalendarDatePickerPageCmdMsgs of CalendarDatePickerPage.CmdMsg list
    | CanvasPageCmdMsgs of CanvasPage.CmdMsg list
    | CheckBoxPageCmdMsgs of CheckBoxPage.CmdMsg list
    | CarouselPageCmdMsgs of CarouselPage.CmdMsg list
    | ComboBoxPageCmdMsgs of ComboBoxPage.CmdMsg list
    | CompositionPageCmdMsgs of CompositionPage.CmdMsg list
    | ContextMenuPageCmdMsgs of ContextMenuPage.CmdMsg list
    | ContextFlyoutPageCmdMsgs of ContextFlyoutPage.CmdMsg list
    | ClippingPageCmdMsgs of ClippingPage.CmdMsg list
    | ClipboardPageCmdMsgs of ClipboardPage.CmdMsg list
    | DockPanelPageCmdMsgs of DockPanelPage.CmdMsg list
    | DragAndDropPageCmdMsgs of DragAndDropPage.CmdMsg list
    | DialogsPageCmdMsgs of DialogsPage.CmdMsg list
    | DropDownButtonPageCmdMsgs of DropDownButtonPage.CmdMsg list
    | DrawingPageCmdMsgs of DrawingPage.CmdMsg list
    | EffectsPageCmdMsgs of EffectsPage.CmdMsg list
    | ExpanderPageCmdMsgs of ExpanderPage.CmdMsg list
    | FlyoutPageCmdMsgs of FlyoutPage.CmdMsg list
    | GesturesPageCmdMsgs of GesturesPage.CmdMsg list
    | GeometriesPageCmdMsgs of GeometriesPage.CmdMsg list
    | GridPageCmdMsgs of GridPage.CmdMsg list
    | GridSplitterPageCmdMsgs of GridSplitterPage.CmdMsg list
    | ImagePageCmdMsgs of ImagePage.CmdMsg list
    | LabelPageCmdMsgs of LabelPage.CmdMsg list
    | LayoutTransformControlPageCmdMsgs of LayoutTransformControlPage.CmdMsg list
    | LineBoundsDemoControlPageCmdMsgs of LineBoundsDemoControlPage.CmdMsg list
    | ListBoxPageCmdMsgs of ListBoxPage.CmdMsg list
    | MenuFlyoutPageCmdMsgs of MenuFlyoutPage.CmdMsg list
    | MaskedTextBoxPageCmdMsgs of MaskedTextBoxPage.CmdMsg list
    | MenuPageCmdMsgs of MenuPage.CmdMsg list
    | NumericUpDownPageCmdMsgs of NumericUpDownPage.CmdMsg list
    | NotificationsPageCmdMsgs of NotificationsPage.CmdMsg list
    | OpenGLPageCmdMsgs of OpenGLPage.CmdMsg list
    | ProgressBarPageCmdMsgs of ProgressBarPage.CmdMsg list
    | PanelPageCmdMsgs of PanelPage.CmdMsg list
    | PathIconPageCmdMsgs of PathIconPage.CmdMsg list
    | PopupPageCmdMsgs of PopupPage.CmdMsg list
    | PointersPageCmdMsgs of PointersPage.CmdMsg list
    | PageTransitionsPageCmdMsgs of PageTransitionsPage.CmdMsg list
    | RepeatButtonPageCmdMsgs of RepeatButtonPage.CmdMsg list
    | RadioButtonPageCmdMsgs of RadioButtonPage.CmdMsg list
    | RefreshContainerPageCmdMsgs of RefreshContainerPage.CmdMsg list
    | SelectableTextBlockPageCmdMsgs of SelectableTextBlockPage.CmdMsg list
    | SplitButtonPageCmdMsgs of SplitButtonPage.CmdMsg list
    | SliderPageCmdMsgs of SliderPage.CmdMsg list
    | ShapesPageCmdMsgs of ShapesPage.CmdMsg list
    | ScrollBarPageCmdMsgs of ScrollBarPage.CmdMsg list
    | SplitViewPageCmdMsgs of SplitViewPage.CmdMsg list
    | StackPanelPageCmdMsgs of StackPanelPage.CmdMsg list
    | StylesPageCmdMsgs of StylesPage.CmdMsg list
    | ScrollViewerPageCmdMsgs of ScrollViewerPage.CmdMsg list
    | ToggleSplitButtonPageCmdMsgs of ToggleSplitButtonPage.CmdMsg list
    | TextBlockPageCmdMsgs of TextBlockPage.CmdMsg list
    | TextBoxPageCmdMsgs of TextBoxPage.CmdMsg list
    | TickBarPageCmdMsgs of TickBarPage.CmdMsg list
    | ToggleSwitchPageCmdMsgs of ToggleSwitchPage.CmdMsg list
    | ToggleButtonPageCmdMsgs of ToggleButtonPage.CmdMsg list
    | ToolTipPageCmdMsgs of ToolTipPage.CmdMsg list
    | TabControlPageCmdMsgs of TabControlPage.CmdMsg list
    | TabStripPageCmdMsgs of TabStripPage.CmdMsg list
    | TransformsPageCmdMsgs of TransformsPage.CmdMsg list
    | ThemeAwarePageCmdMsgs of ThemeAwarePage.CmdMsg list
    | UniformGridPageCmdMsgs of UniformGridPage.CmdMsg list
    | ViewBoxPageCmdMsgs of ViewBoxPage.CmdMsg list

type NavigationModel =
    { CurrentPage: SubpageModel }

    static member Init(root: SubpageModel) = { CurrentPage = root }

    member this.Push(page: SubpageModel) = { CurrentPage = page }

module NavigationState =
    let mapCmdMsgToMsg cmdMsgs =
        let mapSubpageCmdMsg (cmdMsg: SubpageCmdMsg) =
            let map (mapCmdMsgFn: 'subCmdMsg -> Cmd<'subMsg>) (mapFn: 'subMsg -> 'msg) (subCmdMsgs: 'subCmdMsg list) =
                subCmdMsgs
                |> List.map(fun c ->
                    let cmd = mapCmdMsgFn c
                    Cmd.map mapFn cmd)

            match cmdMsg with
            | AcrylicPageCmdMsgs subCmdMsgs -> map AcrylicPage.mapCmdMsgToCmd AcrylicPageMsg subCmdMsgs
            | AdornerLayerPageCmdMsgs subCmdMsgs -> map AdornerLayerPage.mapCmdMsgToCmd AdornerLayerPageMsg subCmdMsgs
            | AutoCompleteBoxPageCmdMsgs subCmdMsgs -> map AutoCompleteBoxPage.mapCmdMsgToCmd AutoCompleteBoxPageMsg subCmdMsgs
            | ButtonsPageCmdMsgs subCmdMsgs -> map ButtonsPage.mapCmdMsgToCmd ButtonsPageMsg subCmdMsgs
            | ButtonSpinnerPageCmdMsgs subCmdMsgs -> map ButtonSpinnerPage.mapCmdMsgToCmd ButtonSpinnerPageMsg subCmdMsgs
            | BorderPageCmdMsgs subCmdMsgs -> map BorderPage.mapCmdMsgToCmd BorderPageMsg subCmdMsgs
            | BrushesPageCmdMsgs subCmdMsgs -> map BrushesPage.mapCmdMsgToCmd BrushesPageMsg subCmdMsgs
            | CalendarPageCmdMsgs subCmdMsgs -> map CalendarPage.mapCmdMsgToCmd CalendarPageMsg subCmdMsgs
            | CalendarDatePickerPageCmdMsgs subCmdMsgs -> map CalendarDatePickerPage.mapCmdMsgToCmd CalendarDatePickerPageMsg subCmdMsgs
            | CanvasPageCmdMsgs subCmdMsgs -> map CanvasPage.mapCmdMsgToCmd CanvasPageMsg subCmdMsgs
            | CheckBoxPageCmdMsgs subCmdMsgs -> map CheckBoxPage.mapCmdMsgToCmd CheckBoxPageMsg subCmdMsgs
            | CarouselPageCmdMsgs subCmdMsgs -> map CarouselPage.mapCmdMsgToCmd CarouselPageMsg subCmdMsgs
            | ComboBoxPageCmdMsgs subCmdMsgs -> map ComboBoxPage.mapCmdMsgToCmd ComboBoxPageMsg subCmdMsgs
            | CompositionPageCmdMsgs subCmdMsgs -> map CompositionPage.mapCmdMsgToCmd CompositionPageMsg subCmdMsgs
            | ContextMenuPageCmdMsgs subCmdMsgs -> map ContextMenuPage.mapCmdMsgToCmd ContextMenuPageMsg subCmdMsgs
            | ContextFlyoutPageCmdMsgs subCmdMsgs -> map ContextFlyoutPage.mapCmdMsgToCmd ContextFlyoutPageMsg subCmdMsgs
            | ClipboardPageCmdMsgs subCmdMsgs -> map ClipboardPage.mapCmdMsgToCmd ClipboardPageMsg subCmdMsgs
            | ClippingPageCmdMsgs subCmdMsgs -> map ClippingPage.mapCmdMsgToCmd ClippingPageMsg subCmdMsgs
            | DockPanelPageCmdMsgs subCmdMsgs -> map DockPanelPage.mapCmdMsgToCmd DockPanelPageMsg subCmdMsgs
            | DialogsPageCmdMsgs subCmdMsgs -> map DialogsPage.mapCmdMsgToCmd DialogsPageMsg subCmdMsgs
            | DragAndDropPageCmdMsgs subCmdMsgs -> map DragAndDropPage.mapCmdMsgToCmd DragAndDropPageMsg subCmdMsgs
            | DropDownButtonPageCmdMsgs subCmdMsgs -> map DropDownButtonPage.mapCmdMsgToCmd DropDownButtonPageMsg subCmdMsgs
            | DrawingPageCmdMsgs subCmdMsgs -> map DrawingPage.mapCmdMsgToCmd DrawingPageMsg subCmdMsgs
            | EffectsPageCmdMsgs subCmdMsgs -> map EffectsPage.mapCmdMsgToCmd EffectsPageMsg subCmdMsgs
            | ExpanderPageCmdMsgs subCmdMsgs -> map ExpanderPage.mapCmdMsgToCmd ExpanderPageMsg subCmdMsgs
            | FlyoutPageCmdMsgs subCmdMsgs -> map FlyoutPage.mapCmdMsgToCmd FlyoutPageMsg subCmdMsgs
            | GesturesPageCmdMsgs subCmdMsgs -> map GesturesPage.mapCmdMsgToCmd GesturesPageMsg subCmdMsgs
            | GeometriesPageCmdMsgs subCmdMsgs -> map GeometriesPage.mapCmdMsgToCmd GeometriesPageMsg subCmdMsgs
            | GridPageCmdMsgs subCmdMsgs -> map GridPage.mapCmdMsgToCmd GridPageMsg subCmdMsgs
            | GridSplitterPageCmdMsgs subCmdMsgs -> map GridSplitterPage.mapCmdMsgToCmd GridSplitterPageMsg subCmdMsgs
            | ImagePageCmdMsgs subCmdMsgs -> map ImagePage.mapCmdMsgToCmd ImagePageMsg subCmdMsgs
            | LabelPageCmdMsgs subCmdMsgs -> map LabelPage.mapCmdMsgToCmd LabelPageMsg subCmdMsgs
            | LayoutTransformControlPageCmdMsgs subCmdMsgs -> map LayoutTransformControlPage.mapCmdMsgToCmd LayoutTransformControlPageMsg subCmdMsgs
            | LineBoundsDemoControlPageCmdMsgs subCmdMsgs -> map LineBoundsDemoControlPage.mapCmdMsgToCmd LineBoundsDemoControlPageMsg subCmdMsgs
            | ListBoxPageCmdMsgs subCmdMsgs -> map ListBoxPage.mapCmdMsgToCmd ListBoxPageMsg subCmdMsgs
            | MenuFlyoutPageCmdMsgs subCmdMsgs -> map MenuFlyoutPage.mapCmdMsgToCmd MenuFlyoutPageMsg subCmdMsgs
            | MenuPageCmdMsgs subCmdMsgs -> map MenuPage.mapCmdMsgToCmd MenuPageMsg subCmdMsgs
            | MaskedTextBoxPageCmdMsgs subCmdMsgs -> map MaskedTextBoxPage.mapCmdMsgToCmd MaskedTextBoxPageMsg subCmdMsgs
            | NumericUpDownPageCmdMsgs subCmdMsgs -> map NumericUpDownPage.mapCmdMsgToCmd NumericUpDownPageMsg subCmdMsgs
            | NotificationsPageCmdMsgs subCmdMsgs -> map NotificationsPage.mapCmdMsgToCmd NotificationsPageMsg subCmdMsgs
            | OpenGLPageCmdMsgs subCmdMsgs -> map OpenGLPage.mapCmdMsgToCmd OpenGLPageMsg subCmdMsgs
            | ProgressBarPageCmdMsgs subCmdMsgs -> map ProgressBarPage.mapCmdMsgToCmd ProgressBarPageMsg subCmdMsgs
            | PanelPageCmdMsgs subCmdMsgs -> map PanelPage.mapCmdMsgToCmd PanelPageMsg subCmdMsgs
            | PathIconPageCmdMsgs subCmdMsgs -> map PathIconPage.mapCmdMsgToCmd PathIconPageMsg subCmdMsgs
            | PointersPageCmdMsgs subCmdMsgs -> map PointersPage.mapCmdMsgToCmd PointersPageMsg subCmdMsgs
            | PopupPageCmdMsgs subCmdMsgs -> map PopupPage.mapCmdMsgToCmd PopupPageMsg subCmdMsgs
            | PageTransitionsPageCmdMsgs subCmdMsgs -> map PageTransitionsPage.mapCmdMsgToCmd PageTransitionsPageMsg subCmdMsgs
            | RepeatButtonPageCmdMsgs subCmdMsgs -> map RepeatButtonPage.mapCmdMsgToCmd RepeatButtonPageMsg subCmdMsgs
            | RadioButtonPageCmdMsgs subCmdMsgs -> map RadioButtonPage.mapCmdMsgToCmd RadioButtonPageMsg subCmdMsgs
            | RefreshContainerPageCmdMsgs subCmdMsgs -> map RefreshContainerPage.mapCmdMsgToCmd RefreshContainerPageMsg subCmdMsgs
            | SelectableTextBlockPageCmdMsgs subCmdMsgs -> map SelectableTextBlockPage.mapCmdMsgToCmd SelectableTextBlockPageMsg subCmdMsgs
            | SplitButtonPageCmdMsgs subCmdMsgs -> map SplitButtonPage.mapCmdMsgToCmd SplitButtonPageMsg subCmdMsgs
            | SliderPageCmdMsgs subCmdMsgs -> map SliderPage.mapCmdMsgToCmd SliderPageMsg subCmdMsgs
            | ShapesPageCmdMsgs subCmdMsgs -> map ShapesPage.mapCmdMsgToCmd ShapesPageMsg subCmdMsgs
            | ScrollViewerPageCmdMsgs subCmdMsgs -> map ScrollViewerPage.mapCmdMsgToCmd ScrollViewerPageMsg subCmdMsgs
            | SplitViewPageCmdMsgs subCmdMsgs -> map SplitViewPage.mapCmdMsgToCmd SplitViewPageMsg subCmdMsgs
            | StackPanelPageCmdMsgs subCmdMsgs -> map StackPanelPage.mapCmdMsgToCmd StackPanelPageMsg subCmdMsgs
            | StylesPageCmdMsgs subCmdMsgs -> map StylesPage.mapCmdMsgToCmd StylesPageMsg subCmdMsgs
            | ScrollBarPageCmdMsgs subCmdMsgs -> map ScrollBarPage.mapCmdMsgToCmd ScrollBarPageMsg subCmdMsgs
            | TabControlPageCmdMsgs subCmdMsgs -> map TabControlPage.mapCmdMsgToCmd TabControlPageMsg subCmdMsgs
            | TabStripPageCmdMsgs subCmdMsgs -> map TabStripPage.mapCmdMsgToCmd TabStripPageMsg subCmdMsgs
            | TextBlockPageCmdMsgs subCmdMsgs -> map TextBlockPage.mapCmdMsgToCmd TextBlockPageMsg subCmdMsgs
            | TextBoxPageCmdMsgs subCmdMsgs -> map TextBoxPage.mapCmdMsgToCmd TextBoxPageMsg subCmdMsgs
            | ToggleButtonPageCmdMsgs subCmdMsgs -> map ToggleButtonPage.mapCmdMsgToCmd ToggleButtonPageMsg subCmdMsgs
            | ToggleSwitchPageCmdMsgs subCmdMsgs -> map ToggleSwitchPage.mapCmdMsgToCmd ToggleSwitchPageMsg subCmdMsgs
            | ToolTipPageCmdMsgs subCmdMsgs -> map ToolTipPage.mapCmdMsgToCmd ToolTipPageMsg subCmdMsgs
            | TickBarPageCmdMsgs subCmdMsgs -> map TickBarPage.mapCmdMsgToCmd TickBarPageMsg subCmdMsgs
            | TransformsPageCmdMsgs subCmdMsgs -> map TransformsPage.mapCmdMsgToCmd TransformsPageMsg subCmdMsgs
            | ThemeAwarePageCmdMsgs subCmdMsgs -> map ThemeAwarePage.mapCmdMsgToCmd ThemeAwarePageMsg subCmdMsgs
            | UniformGridPageCmdMsgs subCmdMsgs -> map UniformGridPage.mapCmdMsgToCmd UniformGridPageMsg subCmdMsgs
            | ViewBoxPageCmdMsgs subCmdMsgs -> map ViewBoxPage.mapCmdMsgToCmd ViewBoxPageMsg subCmdMsgs
            | ToggleSplitButtonPageCmdMsgs cmdMsgs -> map ToggleSplitButtonPage.mapCmdMsgToCmd ToggleSplitButtonPageMsg cmdMsgs

        cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let initRoute (route: NavigationRoute) =
        match route with
        | NavigationRoute.AcrylicPage ->
            let m, c = AcrylicPage.init()
            AcrylicPageModel m, [ AcrylicPageCmdMsgs c ]

        | NavigationRoute.AdornerLayerPage ->
            let m, c = AdornerLayerPage.init()
            AdornerLayerPageModel m, [ AdornerLayerPageCmdMsgs c ]

        | NavigationRoute.AutoCompleteBoxPage ->
            let m, c = AutoCompleteBoxPage.init()
            AutoCompleteBoxPageModel m, [ AutoCompleteBoxPageCmdMsgs c ]

        | NavigationRoute.ButtonsPage ->
            let m, c = ButtonsPage.init()
            ButtonsPageModel m, [ ButtonsPageCmdMsgs c ]
        | NavigationRoute.BrushesPage ->
            let m, c = BrushesPage.init()
            BrushesPageModel m, [ BrushesPageCmdMsgs c ]
        | NavigationRoute.ButtonSpinnerPage ->
            let m, c = ButtonSpinnerPage.init()
            ButtonSpinnerPageModel m, [ ButtonSpinnerPageCmdMsgs c ]
        | NavigationRoute.BorderPage ->
            let m, c = BorderPage.init()
            BorderPageModel m, [ BorderPageCmdMsgs c ]
        | NavigationRoute.CalendarPage ->
            let m, c = CalendarPage.init()
            CalendarPageModel m, [ CalendarPageCmdMsgs c ]
        | NavigationRoute.CalendarDatePickerPage ->
            let m, c = CalendarDatePickerPage.init()
            CalendarDatePickerPageModel m, [ CalendarDatePickerPageCmdMsgs c ]
        | NavigationRoute.CanvasPage ->
            let m, c = CanvasPage.init()
            CanvasPageModel m, [ CanvasPageCmdMsgs c ]
        | NavigationRoute.CheckBoxPage ->
            let m, c = CheckBoxPage.init()
            CheckBoxPageModel m, [ CheckBoxPageCmdMsgs c ]
        | NavigationRoute.CarouselPage ->
            let m, c = CarouselPage.init()
            CarouselPageModel m, [ CarouselPageCmdMsgs c ]
        | NavigationRoute.ComboBoxPage ->
            let m, c = ComboBoxPage.init()
            ComboBoxPageModel m, [ ComboBoxPageCmdMsgs c ]

        | NavigationRoute.CompositionPage ->
            let m, c = CompositionPage.init()
            CompositionPageModel m, [ CompositionPageCmdMsgs c ]
        | NavigationRoute.ContextMenuPage ->
            let m, c = ContextMenuPage.init()
            ContextMenuPageModel m, [ ContextMenuPageCmdMsgs c ]
        | NavigationRoute.ContextFlyoutPage ->
            let m, c = ContextFlyoutPage.init()
            ContextFlyoutPageModel m, [ ContextFlyoutPageCmdMsgs c ]
        | NavigationRoute.ClippingPage ->
            let m, c = ClippingPage.init()
            ClippingPageModel m, [ ClippingPageCmdMsgs c ]
        | NavigationRoute.ClipboardPage ->
            let m, c = ClipboardPage.init()
            ClipboardPageModel m, [ ClipboardPageCmdMsgs c ]
        | NavigationRoute.DockPanelPage ->
            let m, c = DockPanelPage.init()
            DockPanelPageModel m, [ DockPanelPageCmdMsgs c ]
        | NavigationRoute.DragAndDropPage ->
            let m, c = DragAndDropPage.init()
            DragAndDropPageModel m, [ DragAndDropPageCmdMsgs c ]
        | NavigationRoute.DropDownButtonPage ->
            let m, c = DropDownButtonPage.init()
            DropDownButtonPageModel m, [ DropDownButtonPageCmdMsgs c ]
        | NavigationRoute.DialogsPage ->
            let m, c = DialogsPage.init()
            DialogsPageModel m, [ DialogsPageCmdMsgs c ]
        | NavigationRoute.DrawingPage ->
            let m, c = DrawingPage.init()
            DrawingPageModel m, [ DrawingPageCmdMsgs c ]
        | NavigationRoute.EffectsPage ->
            let m, c = EffectsPage.init()
            EffectsPageModel m, [ EffectsPageCmdMsgs c ]
        | NavigationRoute.ExpanderPage ->
            let m, c = ExpanderPage.init()
            ExpanderPageModel m, [ ExpanderPageCmdMsgs c ]
        | NavigationRoute.FlyoutPage ->
            let m, c = FlyoutPage.init()
            FlyoutPageModel m, [ FlyoutPageCmdMsgs c ]
        | NavigationRoute.GesturesPage ->
            let m, c = GesturesPage.init()
            GesturesPageModel m, [ GesturesPageCmdMsgs c ]
        | NavigationRoute.GeometriesPage ->
            let m, c = GeometriesPage.init()
            GeometriesPageModel m, [ GeometriesPageCmdMsgs c ]
        | NavigationRoute.GridPage ->
            let m, c = GridPage.init()
            GridPageModel m, [ GridPageCmdMsgs c ]
        | NavigationRoute.GridSplitterPage ->
            let m, c = GridSplitterPage.init()
            GridSplitterPageModel m, [ GridSplitterPageCmdMsgs c ]
        | NavigationRoute.ImagePage ->
            let m, c = ImagePage.init()
            ImagePageModel m, [ ImagePageCmdMsgs c ]
        | NavigationRoute.LabelPage ->
            let m, c = LabelPage.init()
            LabelPageModel m, [ LabelPageCmdMsgs c ]
        | NavigationRoute.LayoutTransformControlPage ->
            let m, c = LayoutTransformControlPage.init()
            LayoutTransformControlPageModel m, [ LayoutTransformControlPageCmdMsgs c ]
        | NavigationRoute.ListBoxPage ->
            let m, c = ListBoxPage.init()
            ListBoxPageModel m, [ ListBoxPageCmdMsgs c ]
        | NavigationRoute.MenuFlyoutPage ->
            let m, c = MenuFlyoutPage.init()
            MenuFlyoutPageModel m, [ MenuFlyoutPageCmdMsgs c ]
        | NavigationRoute.MaskedTextBoxPage ->
            let m, c = MaskedTextBoxPage.init()
            MaskedTextBoxPageModel m, [ MaskedTextBoxPageCmdMsgs c ]
        | NavigationRoute.MenuPage ->
            let m, c = MenuPage.init()
            MenuPageModel m, [ MenuPageCmdMsgs c ]
        | NavigationRoute.NumericUpDownPage ->
            let m, c = NumericUpDownPage.init()
            NumericUpDownPageModel m, [ NumericUpDownPageCmdMsgs c ]
        | NavigationRoute.NotificationsPage ->
            let m, c = NotificationsPage.init()
            NotificationsPageModel m, [ NotificationsPageCmdMsgs c ]
        | NavigationRoute.OpenGLPage ->
            let m, c = OpenGLPage.init()
            OpenGLPageModel m, [ OpenGLPageCmdMsgs c ]
        | NavigationRoute.ProgressBarPage ->
            let m, c = ProgressBarPage.init()
            ProgressBarPageModel m, [ ProgressBarPageCmdMsgs c ]
        | NavigationRoute.PanelPage ->
            let m, c = PanelPage.init()
            PanelPageModel m, [ PanelPageCmdMsgs c ]
        | NavigationRoute.PathIconPage ->
            let m, c = PathIconPage.init()
            PathIconPageModel m, [ PathIconPageCmdMsgs c ]
        | NavigationRoute.PointersPage ->
            let m, c = PointersPage.init()
            PointersPageModel m, [ PointersPageCmdMsgs c ]
        | NavigationRoute.PopupPage ->
            let m, c = PopupPage.init()
            PopupPageModel m, [ PopupPageCmdMsgs c ]
        | NavigationRoute.PageTransitionsPage ->
            let m, c = PageTransitionsPage.init()
            PageTransitionsPageModel m, [ PageTransitionsPageCmdMsgs c ]
        | NavigationRoute.RepeatButtonPage ->
            let m, c = RepeatButtonPage.init()
            RepeatButtonPageModel m, [ RepeatButtonPageCmdMsgs c ]
        | NavigationRoute.RadioButtonPage ->
            let m, c = RadioButtonPage.init()
            RadioButtonPageModel m, [ RadioButtonPageCmdMsgs c ]
        | NavigationRoute.RefreshContainerPage ->
            let m, c = RefreshContainerPage.init()
            RefreshContainerPageModel m, [ RefreshContainerPageCmdMsgs c ]
        | NavigationRoute.SelectableTextBlockPage ->
            let m, c = SelectableTextBlockPage.init()
            SelectableTextBlockPageModel m, [ SelectableTextBlockPageCmdMsgs c ]
        | NavigationRoute.SplitButtonPage ->
            let m, c = SplitButtonPage.init()
            SplitButtonPageModel m, [ SplitButtonPageCmdMsgs c ]
        | NavigationRoute.SliderPage ->
            let m, c = SliderPage.init()
            SliderPageModel m, [ SliderPageCmdMsgs c ]
        | NavigationRoute.ShapesPage ->
            let m, c = ShapesPage.init()
            ShapesPageModel m, [ ShapesPageCmdMsgs c ]
        | NavigationRoute.ScrollBarPage ->
            let m, c = ScrollBarPage.init()
            ScrollBarPageModel m, [ ScrollBarPageCmdMsgs c ]
        | NavigationRoute.SplitViewPage ->
            let m, c = SplitViewPage.init()
            SplitViewPageModel m, [ SplitViewPageCmdMsgs c ]
        | NavigationRoute.StackPanelPage ->
            let m, c = StackPanelPage.init()
            StackPanelPageModel m, [ StackPanelPageCmdMsgs c ]
        | NavigationRoute.StylesPage ->
            let m, c = StylesPage.init()
            StylesPageModel m, [ StylesPageCmdMsgs c ]
        | NavigationRoute.ScrollViewerPage ->
            let m, c = ScrollViewerPage.init()
            ScrollViewerPageModel m, [ ScrollViewerPageCmdMsgs c ]
        | NavigationRoute.ToggleSplitButtonPage ->
            let m, c = ToggleSplitButtonPage.init()
            ToggleSplitButtonPageModel m, [ ToggleSplitButtonPageCmdMsgs c ]
        | NavigationRoute.TextBlockPage ->
            let m, c = TextBlockPage.init()
            TextBlockPageModel m, [ TextBlockPageCmdMsgs c ]
        | NavigationRoute.TextBoxPage ->
            let m, c = TextBoxPage.init()
            TextBoxPageModel m, [ TextBoxPageCmdMsgs c ]
        | NavigationRoute.TickBarPage ->
            let m, c = TickBarPage.init()
            TickBarPageModel m, [ TickBarPageCmdMsgs c ]
        | NavigationRoute.ToggleSwitchPage ->
            let m, c = ToggleSwitchPage.init()
            ToggleSwitchPageModel m, [ ToggleSwitchPageCmdMsgs c ]
        | NavigationRoute.ToggleButtonPage ->
            let m, c = ToggleButtonPage.init()
            ToggleButtonPageModel m, [ ToggleButtonPageCmdMsgs c ]
        | NavigationRoute.ToolTipPage ->
            let m, c = ToolTipPage.init()
            ToolTipPageModel m, [ ToolTipPageCmdMsgs c ]
        | NavigationRoute.TabControlPage ->
            let m, c = TabControlPage.init()
            TabControlPageModel m, [ TabControlPageCmdMsgs c ]
        | NavigationRoute.TabStripPage ->
            let m, c = TabStripPage.init()
            TabStripPageModel m, [ TabStripPageCmdMsgs c ]
        | NavigationRoute.TransformsPage ->
            let m, c = TransformsPage.init()
            TransformsPageModel m, [ TransformsPageCmdMsgs c ]
        | NavigationRoute.ThemeAwarePage ->
            let m, c = ThemeAwarePage.init()
            ThemeAwarePageModel m, [ ThemeAwarePageCmdMsgs c ]
        | NavigationRoute.UniformGridPage ->
            let m, c = UniformGridPage.init()
            UniformGridPageModel m, [ UniformGridPageCmdMsgs c ]
        | NavigationRoute.ViewBoxPage ->
            let m, c = ViewBoxPage.init()
            ViewBoxPageModel m, [ ViewBoxPageCmdMsgs c ]
        | NavigationRoute.LineBoundsDemoControlPage ->
            let m, c = LineBoundsDemoControlPage.init()
            LineBoundsDemoControlPageModel m, [ LineBoundsDemoControlPageCmdMsgs c ]

    let update (msg: SubpageMsg) (model: NavigationModel) =
        let subpageModel, cmdMsgs =
            match msg, model.CurrentPage with
            | AcrylicPageMsg subMsg, AcrylicPageModel m ->
                let m, c = AcrylicPage.update subMsg m
                AcrylicPageModel m, [ AcrylicPageCmdMsgs c ]

            | AdornerLayerPageMsg subMsg, AdornerLayerPageModel m ->
                let m, c = AdornerLayerPage.update subMsg m
                AdornerLayerPageModel m, [ AdornerLayerPageCmdMsgs c ]

            | AutoCompleteBoxPageMsg subMsg, AutoCompleteBoxPageModel m ->
                let m, c = AutoCompleteBoxPage.update subMsg m
                AutoCompleteBoxPageModel m, [ AutoCompleteBoxPageCmdMsgs c ]

            | ButtonsPageMsg subMsg, ButtonsPageModel m ->
                let m, c = ButtonsPage.update subMsg m
                ButtonsPageModel m, [ ButtonsPageCmdMsgs c ]

            | BrushesPageMsg subMsg, BrushesPageModel m ->
                let m, c = BrushesPage.update subMsg m
                BrushesPageModel m, [ BrushesPageCmdMsgs c ]

            | ButtonSpinnerPageMsg subMsg, ButtonSpinnerPageModel m ->
                let m, c = ButtonSpinnerPage.update subMsg m
                ButtonSpinnerPageModel m, [ ButtonSpinnerPageCmdMsgs c ]

            | BorderPageMsg subMsg, BorderPageModel m ->
                let m, c = BorderPage.update subMsg m
                BorderPageModel m, [ BorderPageCmdMsgs c ]

            | CheckBoxPageMsg subMsg, CheckBoxPageModel m ->
                let m, c = CheckBoxPage.update subMsg m
                CheckBoxPageModel m, [ CheckBoxPageCmdMsgs c ]

            | CalendarDatePickerPageMsg subMsg, CalendarDatePickerPageModel m ->
                let m, c = CalendarDatePickerPage.update subMsg m
                CalendarDatePickerPageModel m, [ CalendarDatePickerPageCmdMsgs c ]

            | CalendarPageMsg subMsg, CalendarPageModel m ->
                let m, c = CalendarPage.update subMsg m
                CalendarPageModel m, [ CalendarPageCmdMsgs c ]

            | CanvasPageMsg subMsg, CanvasPageModel m ->
                let m, c = CanvasPage.update subMsg m
                CanvasPageModel m, [ CanvasPageCmdMsgs c ]

            | CarouselPageMsg subMsg, CarouselPageModel m ->
                let m, c = CarouselPage.update subMsg m
                CarouselPageModel m, [ CarouselPageCmdMsgs c ]

            | ClippingPageMsg subMsg, ClippingPageModel m ->
                let m, c = ClippingPage.update subMsg m
                ClippingPageModel m, [ ClippingPageCmdMsgs c ]

            | ClipboardPageMsg subMsg, ClipboardPageModel m ->
                let m, c = ClipboardPage.update subMsg m
                ClipboardPageModel m, [ ClipboardPageCmdMsgs c ]

            | ComboBoxPageMsg subMsg, ComboBoxPageModel m ->
                let m, c = ComboBoxPage.update subMsg m
                ComboBoxPageModel m, [ ComboBoxPageCmdMsgs c ]

            | CompositionPageMsg subMsg, CompositionPageModel m ->
                let m, c = CompositionPage.update subMsg m
                CompositionPageModel m, [ CompositionPageCmdMsgs c ]

            | ContextFlyoutPageMsg subMsg, ContextFlyoutPageModel m ->
                let m, c = ContextFlyoutPage.update subMsg m
                ContextFlyoutPageModel m, [ ContextFlyoutPageCmdMsgs c ]

            | ContextMenuPageMsg subMsg, ContextMenuPageModel m ->
                let m, c = ContextMenuPage.update subMsg m
                ContextMenuPageModel m, [ ContextMenuPageCmdMsgs c ]

            | DockPanelPageMsg subMsg, DockPanelPageModel m ->
                let m, c = DockPanelPage.update subMsg m
                DockPanelPageModel m, [ DockPanelPageCmdMsgs c ]

            | DialogsPageMsg subMsg, DialogsPageModel m ->
                let m, c = DialogsPage.update subMsg m
                DialogsPageModel m, [ DialogsPageCmdMsgs c ]
            | DragAndDropPageMsg subMsg, DragAndDropPageModel m ->
                let m, c = DragAndDropPage.update subMsg m
                DragAndDropPageModel m, [ DragAndDropPageCmdMsgs c ]

            | DropDownButtonPageMsg subMsg, DropDownButtonPageModel m ->
                let m, c = DropDownButtonPage.update subMsg m
                DropDownButtonPageModel m, [ DropDownButtonPageCmdMsgs c ]

            | DrawingPageMsg subMsg, DrawingPageModel m ->
                let m, c = DrawingPage.update subMsg m
                DrawingPageModel m, [ DrawingPageCmdMsgs c ]

            | EffectsPageMsg subMsg, EffectsPageModel m ->
                let m, c = EffectsPage.update subMsg m
                EffectsPageModel m, [ EffectsPageCmdMsgs c ]

            | ExpanderPageMsg subMsg, ExpanderPageModel m ->
                let m, c = ExpanderPage.update subMsg m
                ExpanderPageModel m, [ ExpanderPageCmdMsgs c ]

            | FlyoutPageMsg subMsg, FlyoutPageModel m ->
                let m, c = FlyoutPage.update subMsg m
                FlyoutPageModel m, [ FlyoutPageCmdMsgs c ]

            | GesturesPageMsg subMsg, GesturesPageModel m ->
                let m, c = GesturesPage.update subMsg m
                GesturesPageModel m, [ GesturesPageCmdMsgs c ]

            | GeometriesPageMsg subMsg, GeometriesPageModel m ->
                let m, c = GeometriesPage.update subMsg m
                GeometriesPageModel m, [ GeometriesPageCmdMsgs c ]

            | GridPageMsg subMsg, GridPageModel m ->
                let m, c = GridPage.update subMsg m
                GridPageModel m, [ GridPageCmdMsgs c ]

            | GridSplitterPageMsg subMsg, GridSplitterPageModel m ->
                let m, c = GridSplitterPage.update subMsg m
                GridSplitterPageModel m, [ GridSplitterPageCmdMsgs c ]

            | ImagePageMsg subMsg, ImagePageModel m ->
                let m, c = ImagePage.update subMsg m
                ImagePageModel m, [ ImagePageCmdMsgs c ]

            | LabelPageMsg subMsg, LabelPageModel m ->
                let m, c = LabelPage.update subMsg m
                LabelPageModel m, [ LabelPageCmdMsgs c ]

            | LayoutTransformControlPageMsg subMsg, LayoutTransformControlPageModel m ->
                let m, c = LayoutTransformControlPage.update subMsg m
                LayoutTransformControlPageModel m, [ LayoutTransformControlPageCmdMsgs c ]

            | LineBoundsDemoControlPageMsg subMsg, LineBoundsDemoControlPageModel m ->
                let m, c = LineBoundsDemoControlPage.update subMsg m
                LineBoundsDemoControlPageModel m, [ LineBoundsDemoControlPageCmdMsgs c ]

            | ListBoxPageMsg subMsg, ListBoxPageModel m ->
                let m, c = ListBoxPage.update subMsg m
                ListBoxPageModel m, [ ListBoxPageCmdMsgs c ]

            | MaskedTextBoxPageMsg subMsg, MaskedTextBoxPageModel m ->
                let m, c = MaskedTextBoxPage.update subMsg m
                MaskedTextBoxPageModel m, [ MaskedTextBoxPageCmdMsgs c ]

            | MenuPageMsg subMsg, MenuPageModel m ->
                let m, c = MenuPage.update subMsg m
                MenuPageModel m, [ MenuPageCmdMsgs c ]

            | MenuFlyoutPageMsg subMsg, MenuFlyoutPageModel m ->
                let m, c = MenuFlyoutPage.update subMsg m
                MenuFlyoutPageModel m, [ MenuFlyoutPageCmdMsgs c ]

            | NumericUpDownPageMsg subMsg, NumericUpDownPageModel m ->
                let m, c = NumericUpDownPage.update subMsg m
                NumericUpDownPageModel m, [ NumericUpDownPageCmdMsgs c ]

            | NotificationsPageMsg subMsg, NotificationsPageModel m ->
                let m, c = NotificationsPage.update subMsg m
                NotificationsPageModel m, [ NotificationsPageCmdMsgs c ]

            | OpenGLPageMsg subMsg, OpenGLPageModel m ->
                let m, c = OpenGLPage.update subMsg m
                OpenGLPageModel m, [ OpenGLPageCmdMsgs c ]

            | PanelPageMsg subMsg, PanelPageModel m ->
                let m, c = PanelPage.update subMsg m
                PanelPageModel m, [ PanelPageCmdMsgs c ]

            | PathIconPageMsg subMsg, PathIconPageModel m ->
                let m, c = PathIconPage.update subMsg m
                PathIconPageModel m, [ PathIconPageCmdMsgs c ]

            | PageTransitionsPageMsg subMsg, PageTransitionsPageModel m ->
                let m, c = PageTransitionsPage.update subMsg m
                PageTransitionsPageModel m, [ PageTransitionsPageCmdMsgs c ]

            | PointersPageMsg subMsg, PointersPageModel m ->
                let m, c = PointersPage.update subMsg m
                PointersPageModel m, [ PointersPageCmdMsgs c ]

            | PopupPageMsg subMsg, PopupPageModel m ->
                let m, c = PopupPage.update subMsg m
                PopupPageModel m, [ PopupPageCmdMsgs c ]

            | ProgressBarPageMsg subMsg, ProgressBarPageModel m ->
                let m, c = ProgressBarPage.update subMsg m
                ProgressBarPageModel m, [ ProgressBarPageCmdMsgs c ]

            | RadioButtonPageMsg subMsg, RadioButtonPageModel m ->
                let m, c = RadioButtonPage.update subMsg m
                RadioButtonPageModel m, [ RadioButtonPageCmdMsgs c ]

            | RefreshContainerPageMsg subMsg, RefreshContainerPageModel m ->
                let m, c = RefreshContainerPage.update subMsg m
                RefreshContainerPageModel m, [ RefreshContainerPageCmdMsgs c ]

            | RepeatButtonPageMsg subMsg, RepeatButtonPageModel m ->
                let m, c = RepeatButtonPage.update subMsg m
                RepeatButtonPageModel m, [ RepeatButtonPageCmdMsgs c ]

            | ScrollBarPageMsg subMsg, ScrollBarPageModel m ->
                let m, c = ScrollBarPage.update subMsg m
                ScrollBarPageModel m, [ ScrollBarPageCmdMsgs c ]

            | ScrollViewerPageMsg subMsg, ScrollViewerPageModel m ->
                let m, c = ScrollViewerPage.update subMsg m
                ScrollViewerPageModel m, [ ScrollViewerPageCmdMsgs c ]

            | SelectableTextBlockPageMsg subMsg, SelectableTextBlockPageModel m ->
                let m, c = SelectableTextBlockPage.update subMsg m
                SelectableTextBlockPageModel m, [ SelectableTextBlockPageCmdMsgs c ]

            | SliderPageMsg subMsg, SliderPageModel m ->
                let m, c = SliderPage.update subMsg m
                SliderPageModel m, [ SliderPageCmdMsgs c ]

            | SplitButtonPageMsg subMsg, SplitButtonPageModel m ->
                let m, c = SplitButtonPage.update subMsg m
                SplitButtonPageModel m, [ SplitButtonPageCmdMsgs c ]

            | SplitViewPageMsg subMsg, SplitViewPageModel m ->
                let m, c = SplitViewPage.update subMsg m
                SplitViewPageModel m, [ SplitViewPageCmdMsgs c ]

            | StackPanelPageMsg subMsg, StackPanelPageModel m ->
                let m, c = StackPanelPage.update subMsg m
                StackPanelPageModel m, [ StackPanelPageCmdMsgs c ]

            | StylesPageMsg subMsg, StylesPageModel m ->
                let m, c = StylesPage.update subMsg m
                StylesPageModel m, [ StylesPageCmdMsgs c ]

            | TabStripPageMsg subMsg, TabStripPageModel m ->
                let m, c = TabStripPage.update subMsg m
                TabStripPageModel m, [ TabStripPageCmdMsgs c ]

            | TabControlPageMsg subMsg, TabControlPageModel m ->
                let m, c = TabControlPage.update subMsg m
                TabControlPageModel m, [ TabControlPageCmdMsgs c ]

            | TextBoxPageMsg subMsg, TextBoxPageModel m ->
                let m, c = TextBoxPage.update subMsg m
                TextBoxPageModel m, [ TextBoxPageCmdMsgs c ]

            | TextBlockPageMsg subMsg, TextBlockPageModel m ->
                let m, c = TextBlockPage.update subMsg m
                TextBlockPageModel m, [ TextBlockPageCmdMsgs c ]

            | TickBarPageMsg subMsg, TickBarPageModel m ->
                let m, c = TickBarPage.update subMsg m
                TickBarPageModel m, [ TickBarPageCmdMsgs c ]

            | ToggleButtonPageMsg subMsg, ToggleButtonPageModel m ->
                let m, c = ToggleButtonPage.update subMsg m
                ToggleButtonPageModel m, [ ToggleButtonPageCmdMsgs c ]

            | ToggleSwitchPageMsg subMsg, ToggleSwitchPageModel m ->
                let m, c = ToggleSwitchPage.update subMsg m
                ToggleSwitchPageModel m, [ ToggleSwitchPageCmdMsgs c ]

            | ToggleSplitButtonPageMsg subMsg, ToggleSplitButtonPageModel m ->
                let m, c = ToggleSplitButtonPage.update subMsg m
                ToggleSplitButtonPageModel m, [ ToggleSplitButtonPageCmdMsgs c ]

            | ThemeAwarePageMsg subMsg, ThemeAwarePageModel m ->
                let m, c = ThemeAwarePage.update subMsg m
                ThemeAwarePageModel m, [ ThemeAwarePageCmdMsgs c ]

            | ToolTipPageMsg subMsg, ToolTipPageModel m ->
                let m, c = ToolTipPage.update subMsg m
                ToolTipPageModel m, [ ToolTipPageCmdMsgs c ]

            | TransformsPageMsg subMsg, TransformsPageModel m ->
                let m, c = TransformsPage.update subMsg m
                TransformsPageModel m, [ TransformsPageCmdMsgs c ]

            | UniformGridPageMsg subMsg, UniformGridPageModel m ->
                let m, c = UniformGridPage.update subMsg m
                UniformGridPageModel m, [ UniformGridPageCmdMsgs c ]

            | ShapesPageMsg subMsg, ShapesPageModel m ->
                let m, c = ShapesPage.update subMsg m
                ShapesPageModel m, [ ShapesPageCmdMsgs c ]

            | ViewBoxPageMsg subMsg, ViewBoxPageModel m ->
                let m, c = ViewBoxPage.update subMsg m
                ViewBoxPageModel m, [ ViewBoxPageCmdMsgs c ]

            | _, currentPage ->
                let pageName = currentPage.GetSubpageName()
                let errMessage = $"Unexpected message '%A{msg}'on page '%s{pageName}'"

                //failwith errMessage
                System.Diagnostics.Debug.WriteLine errMessage
                //System.Diagnostics.Debugger.Break()
                currentPage, []

        { model with
            CurrentPage = subpageModel },
        cmdMsgs

    let view mapFn (model: SubpageModel) =
        let map viewFn subpageMsg model =
            let view = viewFn model
            View.AnyView(View.map (subpageMsg >> mapFn) view)

        match model with
        | AcrylicPageModel m -> map AcrylicPage.view AcrylicPageMsg m
        | AdornerLayerPageModel m -> map AdornerLayerPage.view AdornerLayerPageMsg m
        | AutoCompleteBoxPageModel m -> map AutoCompleteBoxPage.view AutoCompleteBoxPageMsg m
        | ButtonsPageModel m -> map ButtonsPage.view ButtonsPageMsg m
        | BrushesPageModel m -> map BrushesPage.view BrushesPageMsg m
        | ButtonSpinnerPageModel m -> map ButtonSpinnerPage.view ButtonSpinnerPageMsg m
        | BorderPageModel model -> map BorderPage.view BorderPageMsg model
        | CalendarPageModel m -> map CalendarPage.view CalendarPageMsg m
        | CalendarDatePickerPageModel m -> map CalendarDatePickerPage.view CalendarDatePickerPageMsg m
        | CanvasPageModel m -> map CanvasPage.view CanvasPageMsg m
        | CheckBoxPageModel m -> map CheckBoxPage.view CheckBoxPageMsg m
        | CarouselPageModel m -> map CarouselPage.view CarouselPageMsg m
        | ComboBoxPageModel m -> map ComboBoxPage.view ComboBoxPageMsg m
        | CompositionPageModel m -> map CompositionPage.view CompositionPageMsg m
        | ContextMenuPageModel m -> map ContextMenuPage.view ContextMenuPageMsg m
        | ContextFlyoutPageModel m -> map ContextFlyoutPage.view ContextFlyoutPageMsg m
        | ClippingPageModel m -> map ClippingPage.view ClippingPageMsg m
        | ClipboardPageModel m -> map ClipboardPage.view ClipboardPageMsg m
        | DockPanelPageModel m -> map DockPanelPage.view DockPanelPageMsg m
        | DialogsPageModel m -> map DialogsPage.view DialogsPageMsg m
        | DragAndDropPageModel m -> map DragAndDropPage.view DragAndDropPageMsg m
        | DropDownButtonPageModel m -> map DropDownButtonPage.view DropDownButtonPageMsg m
        | DrawingPageModel m -> map DrawingPage.view DrawingPageMsg m
        | EffectsPageModel m -> map EffectsPage.view EffectsPageMsg m
        | ExpanderPageModel m -> map ExpanderPage.view ExpanderPageMsg m
        | FlyoutPageModel m -> map FlyoutPage.view FlyoutPageMsg m
        | GesturesPageModel m -> map GesturesPage.view GesturesPageMsg m
        | GeometriesPageModel m -> map GeometriesPage.view GeometriesPageMsg m
        | GridPageModel m -> map GridPage.view GridPageMsg m
        | GridSplitterPageModel m -> map GridSplitterPage.view GridSplitterPageMsg m
        | ImagePageModel m -> map ImagePage.view ImagePageMsg m
        | LabelPageModel m -> map LabelPage.view LabelPageMsg m
        | LayoutTransformControlPageModel m -> map LayoutTransformControlPage.view LayoutTransformControlPageMsg m
        | LineBoundsDemoControlPageModel m -> map LineBoundsDemoControlPage.view LineBoundsDemoControlPageMsg m
        | ListBoxPageModel m -> map ListBoxPage.view ListBoxPageMsg m
        | MenuFlyoutPageModel m -> map MenuFlyoutPage.view MenuFlyoutPageMsg m
        | MaskedTextBoxPageModel m -> map MaskedTextBoxPage.view MaskedTextBoxPageMsg m
        | MenuPageModel m -> map MenuPage.view MenuPageMsg m
        | NumericUpDownPageModel m -> map NumericUpDownPage.view NumericUpDownPageMsg m
        | NotificationsPageModel m -> map NotificationsPage.view NotificationsPageMsg m
        | OpenGLPageModel m -> map OpenGLPage.view OpenGLPageMsg m
        | ProgressBarPageModel m -> map ProgressBarPage.view ProgressBarPageMsg m
        | PanelPageModel m -> map PanelPage.view PanelPageMsg m
        | PathIconPageModel m -> map PathIconPage.view PathIconPageMsg m
        | PointersPageModel m -> map PointersPage.view PointersPageMsg m
        | PopupPageModel m -> map PopupPage.view PopupPageMsg m
        | PageTransitionsPageModel m -> map PageTransitionsPage.view PageTransitionsPageMsg m
        | RepeatButtonPageModel m -> map RepeatButtonPage.view RepeatButtonPageMsg m
        | RadioButtonPageModel m -> map RadioButtonPage.view RadioButtonPageMsg m
        | RefreshContainerPageModel m -> map RefreshContainerPage.view RefreshContainerPageMsg m
        | SelectableTextBlockPageModel m -> map SelectableTextBlockPage.view SelectableTextBlockPageMsg m
        | SplitButtonPageModel m -> map SplitButtonPage.view SplitButtonPageMsg m
        | SliderPageModel m -> map SliderPage.view SliderPageMsg m
        | ShapesPageModel m -> map ShapesPage.view ShapesPageMsg m
        | ScrollBarPageModel m -> map ScrollBarPage.view ScrollBarPageMsg m
        | SplitViewPageModel m -> map SplitViewPage.view SplitViewPageMsg m
        | StackPanelPageModel m -> map StackPanelPage.view StackPanelPageMsg m
        | StylesPageModel m -> map StylesPage.view StylesPageMsg m
        | ScrollViewerPageModel m -> map ScrollViewerPage.view ScrollViewerPageMsg m
        | ToggleSplitButtonPageModel m -> map ToggleSplitButtonPage.view ToggleSplitButtonPageMsg m
        | TextBlockPageModel m -> map TextBlockPage.view TextBlockPageMsg m
        | TextBoxPageModel m -> map TextBoxPage.view TextBoxPageMsg m
        | TickBarPageModel m -> map TickBarPage.view TickBarPageMsg m
        | ToggleSwitchPageModel m -> map ToggleSwitchPage.view ToggleSwitchPageMsg m
        | ToggleButtonPageModel m -> map ToggleButtonPage.view ToggleButtonPageMsg m
        | ToolTipPageModel m -> map ToolTipPage.view ToolTipPageMsg m
        | TabControlPageModel m -> map TabControlPage.view TabControlPageMsg m
        | TabStripPageModel m -> map TabStripPage.view TabStripPageMsg m
        | TransformsPageModel m -> map TransformsPage.view TransformsPageMsg m
        | ThemeAwarePageModel m -> map ThemeAwarePage.view ThemeAwarePageMsg m
        | UniformGridPageModel m -> map UniformGridPage.view UniformGridPageMsg m
        | ViewBoxPageModel m -> map ViewBoxPage.view ViewBoxPageMsg m
