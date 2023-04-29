namespace Gallery.Pages

module Types =
    type Pages =
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
        | FormattedTextPage
        | GesturesPage
        | GlyphRunControlPage
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

        static member Translate(value: Pages) =
            match value with
            | AcrylicPage -> "AcrylicPage"
            | AdornerLayerPage -> "AdornerLayerPage"
            | AutoCompleteBoxPage -> "AutoCompleteBoxPage"
            | AnimationsPage -> "AnimationsPage"
            | ButtonsPage -> "ButtonsPage"
            | BrushesPage -> "BrushesPage"
            | ButtonSpinnerPage -> "ButtonSpinnerPage"
            | BorderPage -> "BorderPage"
            | CalendarPage -> "CalendarPage"
            | CalendarDatePickerPage -> "CalendarDatePickerPage"
            | CanvasPage -> "CanvasPage"
            | CheckBoxPage -> "CheckBoxPage"
            | CarouselPage -> "CarouselPage"
            | ComboBoxPage -> "ComboBoxPage"
            | ContextMenuPage -> "ContextMenuPage"
            | ContextFlyoutPage -> "ContextFlyoutPage"
            | ClippingPage -> "ClippingPage"
            | DockPanelPage -> "DockPanelPage"
            | DropDownButtonPage -> "DropDownButtonPage"
            | DrawingPage -> "DrawingPage"
            | ExpanderPage -> "ExpanderPage"
            | FlyoutPage -> "FlyoutPage"
            | FormattedTextPage -> "FormattedTextPage"
            | GesturesPage -> "GesturesPage"
            | GlyphRunControlPage -> "GlyphRunControlPage"
            | GridPage -> "GridPage"
            | GridSplitterPage -> "GridSplitterPage"
            | ImagePage -> "ImagePage"
            | LabelPage -> "LabelPage"
            | LayoutTransformControlPage -> "LayoutTransformControlPage"
            | LineBoundsDemoControlPage -> "LineBoundsDemoControlPage"
            | ListBoxPage -> "ListBoxPage"
            | MenuFlyoutPage -> "MenuFlyoutPage"
            | MaskedTextBoxPage -> "MaskedTextBoxPage"
            | MenuPage -> "MenuPage"
            | NumericUpDownPage -> "NumericUpDownPage"
            | ProgressBarPage -> "ProgressBarPage"
            | PanelPage -> "PanelPage"
            | PathIconPage -> "PathIconPage"
            | PopupPage -> "PopupPage"
            | PageTransitionsPage -> "PageTransitionsPage"
            | RepeatButtonPage -> "RepeatButtonPage"
            | RadioButtonPage -> "RadioButtonPage"
            | RefreshContainerPage -> "RefreshContainerPage"
            | SelectableTextBlockPage -> "SelectableTextBlockPage"
            | SplitButtonPage -> "SplitButtonPage"
            | SliderPage -> "SliderPage"
            | ShapesPage -> "ShapesPage"
            | ScrollBarPage -> "ScrollBarPage"
            | SplitViewPage -> "SplitViewPage"
            | StackPanelPage -> "StackPanelPage"
            | ScrollViewerPage -> "ScrollViewerPage"
            | ToggleSplitButtonPage -> "ToggleSplitButtonPage"
            | TextBlockPage -> "TextBlockPage"
            | TextBoxPage -> "TextBoxPage"
            | TickBarPage -> "TickBarPage"
            | ToggleSwitchPage -> "ToggleSwitchPage"
            | ToggleButtonPage -> "ToggleButtonPage"
            | ToolTipPage -> "ToolTipPage"
            | TabControlPage -> "TabControlPage"
            | TabStripPage -> "TabStripPage"
            | TransitionsPage -> "TransitionsPage"
            | TransformsPage -> "TransformsPage"
            | ThemeAwarePage -> "ThemeAwarePage"
            | UniformGridPage -> "UniformGridPage"
            | ViewBoxPage -> "ViewBoxPage"

    type Model =
        { CurrentPage: Pages
          AcrylicPageModel: AcrylicPage.Model
          AdornerLayerPageModel: AdornerLayerPage.Model
          AutoCompleteBoxPageModel: AutoCompleteBoxPage.Model
          AnimationsPageModel: AnimationsPage.Model
          ButtonsPageModel: ButtonsPage.Model
          BrushesPageModel: BrushesPage.Model
          ButtonSpinnerPageModel: ButtonSpinnerPage.Model
          BorderPageModel: BorderPage.Model
          CalendarPageModel: CalendarPage.Model
          CalendarDatePickerPageModel: CalendarDatePickerPage.Model
          CanvasPageModel: CanvasPage.Model
          CheckBoxPageModel: CheckBoxPage.Model
          CarouselPageModel: CarouselPage.Model
          ComboBoxPageModel: ComboBoxPage.Model
          ContextMenuPageModel: ContextMenuPage.Model
          ContextFlyoutPageModel: ContextFlyoutPage.Model
          ClippingPageModel: ClippingPage.Model
          DockPanelPageModel: DockPanelPage.Model
          DropDownButtonPageModel: DropDownButtonPage.Model
          DrawingPageModel: DrawingPage.Model
          ExpanderPageModel: ExpanderPage.Model
          FlyoutPageModel: FlyoutPage.Model
          FormattedTextPageModel: FormattedTextPage.Model
          GesturesPageModel: GesturesPage.Model
          GlyphRunControlPageModel: GlyphRunControlPage.Model
          GridPageModel: GridPage.Model
          GridSplitterPageModel: GridSplitterPage.Model
          ImagePageModel: ImagePage.Model
          LabelPageModel: LabelPage.Model
          LayoutTransformControlPageModel: LayoutTransformControlPage.Model
          LineBoundsDemoControlPageModel: LineBoundsDemoControlPage.Model
          ListBoxPageModel: ListBoxPage.Model
          MenuFlyoutPageModel: MenuFlyoutPage.Model
          MaskedTextBoxPageModel: MaskedTextBoxPage.Model
          MenuPageModel: MenuPage.Model
          NumericUpDownPageModel: NumericUpDownPage.Model
          ProgressBarPageModel: ProgressBarPage.Model
          PanelPageModel: PanelPage.Model
          PathIconPageModel: PathIconPage.Model
          PopupPageModel: PopupPage.Model
          PageTransitionsPageModel: PageTransitionsPage.Model
          RepeatButtonPageModel: RepeatButtonPage.Model
          RadioButtonPageModel: RadioButtonPage.Model
          RefreshContainerPageModel: RefreshContainerPage.Model
          SelectableTextBlockPageModel: SelectableTextBlockPage.Model
          SplitButtonPageModel: SplitButtonPage.Model
          SliderPageModel: SliderPage.Model
          ShapesPageModel: ShapesPage.Model
          ScrollBarPageModel: ScrollBarPage.Model
          SplitViewPageModel: SplitViewPage.Model
          StackPanelPageModel: StackPanelPage.Model
          ScrollViewerPageModel: ScrollViewerPage.Model
          ToggleSplitButtonPageModel: ToggleSplitButtonPage.Model
          TextBlockPageModel: TextBlockPage.Model
          TextBoxPageModel: TextBoxPage.Model
          TickBarPageModel: TickBarPage.Model
          ToggleSwitchPageModel: ToggleSwitchPage.Model
          ToggleButtonPageModel: ToggleButtonPage.Model
          ToolTipPageModel: ToolTipPage.Model
          TabControlPageModel: TabControlPage.Model
          TabStripPageModel: TabStripPage.Model
          TransitionsPageModel: TransitionsPage.Model
          TransformsPageModel: TransformsPage.Model
          ThemeAwarePageModel: ThemeAwarePage.Model
          UniformGridPageModel: UniformGridPage.Model
          ViewBoxPageModel: ViewBoxPage.Model }

    type Msg =
        | AcrylicPageMsg of AcrylicPage.Msg
        | AdornerLayerPageMsg of AdornerLayerPage.Msg
        | AutoCompleteBoxPageMsg of AutoCompleteBoxPage.Msg
        | AnimationsPageMsg of AnimationsPage.Msg
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
        | ContextMenuPageMsg of ContextMenuPage.Msg
        | ContextFlyoutPageMsg of ContextFlyoutPage.Msg
        | ClippingPageMsg of ClippingPage.Msg
        | DockPanelPageMsg of DockPanelPage.Msg
        | DropDownButtonPageMsg of DropDownButtonPage.Msg
        | DrawingPageMsg of DrawingPage.Msg
        | ExpanderPageMsg of ExpanderPage.Msg
        | FlyoutPageMsg of FlyoutPage.Msg
        | FormattedTextPageMsg of FormattedTextPage.Msg
        | GesturesPageMsg of GesturesPage.Msg
        | GlyphRunControlPageMsg of GlyphRunControlPage.Msg
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
        | ProgressBarPageMsg of ProgressBarPage.Msg
        | PanelPageMsg of PanelPage.Msg
        | PathIconPageMsg of PathIconPage.Msg
        | PopupPageMsg of PopupPage.Msg
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
        | TransitionsPageMsg of TransitionsPage.Msg
        | TransformsPageMsg of TransformsPage.Msg
        | ThemeAwarePageMsg of ThemeAwarePage.Msg
        | UniformGridPageMsg of UniformGridPage.Msg
        | ViewBoxPageMsg of ViewBoxPage.Msg
