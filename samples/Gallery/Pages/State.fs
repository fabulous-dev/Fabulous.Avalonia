namespace Gallery.Pages

open Fabulous

open Types

module State =
    let init page =
        { CurrentPage = page
          AcrylicPageModel = AcrylicPage.init()
          AdornerLayerPageModel = AdornerLayerPage.init()
          AutoCompleteBoxPageModel = AutoCompleteBoxPage.init()
          AnimationsPageModel = AnimationsPage.init()
          ButtonsPageModel = ButtonsPage.init()
          BrushesPageModel = BrushesPage.init()
          ButtonSpinnerPageModel = ButtonSpinnerPage.init()
          BorderPageModel = BorderPage.init()
          CalendarPageModel = CalendarPage.init()
          CalendarDatePickerPageModel = CalendarDatePickerPage.init()
          CanvasPageModel = CanvasPage.init()
          CheckBoxPageModel = CheckBoxPage.init()
          CarouselPageModel = CarouselPage.init()
          ComboBoxPageModel = ComboBoxPage.init()
          ContextMenuPageModel = ContextMenuPage.init()
          ContextFlyoutPageModel = ContextFlyoutPage.init()
          ClippingPageModel = ClippingPage.init()
          DockPanelPageModel = DockPanelPage.init()
          DropDownButtonPageModel = DropDownButtonPage.init()
          DrawingPageModel = DrawingPage.init()
          ExpanderPageModel = ExpanderPage.init()
          FlyoutPageModel = FlyoutPage.init()
          GesturesPageModel = GesturesPage.init()
          GeometriesPageModel = GeometriesPage.init()
          GlyphRunControlPageModel = GlyphRunControlPage.init()
          GridPageModel = GridPage.init()
          GridSplitterPageModel = GridSplitterPage.init()
          ImagePageModel = ImagePage.init()
          LabelPageModel = LabelPage.init()
          LayoutTransformControlPageModel = LayoutTransformControlPage.init()
          LineBoundsDemoControlPageModel = LineBoundsDemoControlPage.init()
          ListBoxPageModel = ListBoxPage.init()
          MenuFlyoutPageModel = MenuFlyoutPage.init()
          MaskedTextBoxPageModel = MaskedTextBoxPage.init()
          MenuPageModel = MenuPage.init()
          NumericUpDownPageModel = NumericUpDownPage.init()
          ProgressBarPageModel = ProgressBarPage.init()
          PanelPageModel = PanelPage.init()
          PathIconPageModel = PathIconPage.init()
          PopupPageModel = PopupPage.init()
          PageTransitionsPageModel = PageTransitionsPage.init()
          RepeatButtonPageModel = RepeatButtonPage.init()
          RadioButtonPageModel = RadioButtonPage.init()
          RefreshContainerPageModel = RefreshContainerPage.init()
          SelectableTextBlockPageModel = SelectableTextBlockPage.init()
          SplitButtonPageModel = SplitButtonPage.init()
          SliderPageModel = SliderPage.init()
          ShapesPageModel = ShapesPage.init()
          ScrollBarPageModel = ScrollBarPage.init()
          SplitViewPageModel = SplitViewPage.init()
          StackPanelPageModel = StackPanelPage.init()
          ScrollViewerPageModel = ScrollViewerPage.init()
          ToggleSplitButtonPageModel = ToggleSplitButtonPage.init()
          TextBlockPageModel = TextBlockPage.init()
          TextBoxPageModel = TextBoxPage.init()
          TickBarPageModel = TickBarPage.init()
          ToggleSwitchPageModel = ToggleSwitchPage.init()
          ToggleButtonPageModel = ToggleButtonPage.init()
          ToolTipPageModel = ToolTipPage.init()
          TabControlPageModel = TabControlPage.init()
          TabStripPageModel = TabStripPage.init()
          TransitionsPageModel = TransitionsPage.init()
          TransformsPageModel = TransformsPage.init()
          ThemeAwarePageModel = ThemeAwarePage.init()
          UniformGridPageModel = UniformGridPage.init()
          ViewBoxPageModel = ViewBoxPage.init() }

    let update msg model =
        match msg with
        | AcrylicPageMsg msg ->
            { model with
                AcrylicPageModel = AcrylicPage.update msg model.AcrylicPageModel },
            Cmd.none
        | AdornerLayerPageMsg msg ->
            { model with
                AdornerLayerPageModel = AdornerLayerPage.update msg model.AdornerLayerPageModel },
            Cmd.none
        | AutoCompleteBoxPageMsg msg ->
            { model with
                AutoCompleteBoxPageModel = AutoCompleteBoxPage.update msg model.AutoCompleteBoxPageModel },
            Cmd.none
        | AnimationsPageMsg msg ->
            { model with
                AnimationsPageModel = AnimationsPage.update msg model.AnimationsPageModel },
            Cmd.none
        | ButtonsPageMsg msg ->
            { model with
                ButtonsPageModel = ButtonsPage.update msg model.ButtonsPageModel },
            Cmd.none
        | BrushesPageMsg msg ->
            { model with
                BrushesPageModel = BrushesPage.update msg model.BrushesPageModel },
            Cmd.none
        | ButtonSpinnerPageMsg msg ->
            { model with
                ButtonSpinnerPageModel = ButtonSpinnerPage.update msg model.ButtonSpinnerPageModel },
            Cmd.none
        | BorderPageMsg msg ->
            { model with
                BorderPageModel = BorderPage.update msg model.BorderPageModel },
            Cmd.none
        | CalendarPageMsg msg ->
            { model with
                CalendarPageModel = CalendarPage.update msg model.CalendarPageModel },
            Cmd.none
        | CalendarDatePickerPageMsg msg ->
            { model with
                CalendarDatePickerPageModel = CalendarDatePickerPage.update msg model.CalendarDatePickerPageModel },
            Cmd.none
        | CanvasPageMsg msg ->
            { model with
                CanvasPageModel = CanvasPage.update msg model.CanvasPageModel },
            Cmd.none
        | CheckBoxPageMsg msg ->
            { model with
                CheckBoxPageModel = CheckBoxPage.update msg model.CheckBoxPageModel },
            Cmd.none
        | CarouselPageMsg msg ->
            { model with
                CarouselPageModel = CarouselPage.update msg model.CarouselPageModel },
            Cmd.none
        | ComboBoxPageMsg msg ->
            { model with
                ComboBoxPageModel = ComboBoxPage.update msg model.ComboBoxPageModel },
            Cmd.none
        | ContextMenuPageMsg msg ->
            { model with
                ContextMenuPageModel = ContextMenuPage.update msg model.ContextMenuPageModel },
            Cmd.none
        | ContextFlyoutPageMsg msg ->
            { model with
                ContextFlyoutPageModel = ContextFlyoutPage.update msg model.ContextFlyoutPageModel },
            Cmd.none
        | ClippingPageMsg msg ->
            { model with
                ClippingPageModel = ClippingPage.update msg model.ClippingPageModel },
            Cmd.none
        | DockPanelPageMsg msg ->
            { model with
                DockPanelPageModel = DockPanelPage.update msg model.DockPanelPageModel },
            Cmd.none
        | DropDownButtonPageMsg msg ->
            { model with
                DropDownButtonPageModel = DropDownButtonPage.update msg model.DropDownButtonPageModel },
            Cmd.none
        | DrawingPageMsg msg ->
            { model with
                DrawingPageModel = DrawingPage.update msg model.DrawingPageModel },
            Cmd.none
        | ExpanderPageMsg msg ->
            { model with
                ExpanderPageModel = ExpanderPage.update msg model.ExpanderPageModel },
            Cmd.none
        | FlyoutPageMsg msg ->
            { model with
                FlyoutPageModel = FlyoutPage.update msg model.FlyoutPageModel },
            Cmd.none
        | GesturesPageMsg msg ->
            { model with
                GesturesPageModel = GesturesPage.update msg model.GesturesPageModel },
            Cmd.none
        | GeometriesPageMsg msg ->
            { model with
                GeometriesPageModel = GeometriesPage.update msg model.GeometriesPageModel },
            Cmd.none
        | GlyphRunControlPageMsg msg ->
            { model with
                GlyphRunControlPageModel = GlyphRunControlPage.update msg model.GlyphRunControlPageModel },
            Cmd.none
        | GridPageMsg msg ->
            { model with
                GridPageModel = GridPage.update msg model.GridPageModel },
            Cmd.none
        | GridSplitterPageMsg msg ->
            { model with
                GridSplitterPageModel = GridSplitterPage.update msg model.GridSplitterPageModel },
            Cmd.none
        | ImagePageMsg msg ->
            { model with
                ImagePageModel = ImagePage.update msg model.ImagePageModel },
            Cmd.none
        | LabelPageMsg msg ->
            { model with
                LabelPageModel = LabelPage.update msg model.LabelPageModel },
            Cmd.none
        | LayoutTransformControlPageMsg msg ->
            { model with
                LayoutTransformControlPageModel = LayoutTransformControlPage.update msg model.LayoutTransformControlPageModel },
            Cmd.none

        | LineBoundsDemoControlPageMsg msg ->
            { model with
                LineBoundsDemoControlPageModel = LineBoundsDemoControlPage.update msg model.LineBoundsDemoControlPageModel },
            Cmd.none

        | ListBoxPageMsg msg ->
            { model with
                ListBoxPageModel = ListBoxPage.update msg model.ListBoxPageModel },
            Cmd.none
        | MenuFlyoutPageMsg msg ->
            { model with
                MenuFlyoutPageModel = MenuFlyoutPage.update msg model.MenuFlyoutPageModel },
            Cmd.none
        | MaskedTextBoxPageMsg msg ->
            { model with
                MaskedTextBoxPageModel = MaskedTextBoxPage.update msg model.MaskedTextBoxPageModel },
            Cmd.none
        | MenuPageMsg msg ->
            { model with
                MenuPageModel = MenuPage.update msg model.MenuPageModel },
            Cmd.none
        | NumericUpDownPageMsg msg ->
            { model with
                NumericUpDownPageModel = NumericUpDownPage.update msg model.NumericUpDownPageModel },
            Cmd.none
        | ProgressBarPageMsg msg ->
            { model with
                ProgressBarPageModel = ProgressBarPage.update msg model.ProgressBarPageModel },
            Cmd.none
        | PanelPageMsg msg ->
            { model with
                PanelPageModel = PanelPage.update msg model.PanelPageModel },
            Cmd.none
        | PathIconPageMsg msg ->
            { model with
                PathIconPageModel = PathIconPage.update msg model.PathIconPageModel },
            Cmd.none
        | PopupPageMsg msg ->
            { model with
                PopupPageModel = PopupPage.update msg model.PopupPageModel },
            Cmd.none
        | PageTransitionsPageMsg msg ->
            { model with
                PageTransitionsPageModel = PageTransitionsPage.update msg model.PageTransitionsPageModel },
            Cmd.none
        | RepeatButtonPageMsg msg ->
            { model with
                RepeatButtonPageModel = RepeatButtonPage.update msg model.RepeatButtonPageModel },
            Cmd.none
        | RadioButtonPageMsg msg ->
            { model with
                RadioButtonPageModel = RadioButtonPage.update msg model.RadioButtonPageModel },
            Cmd.none
        | RefreshContainerPageMsg msg ->
            { model with
                RefreshContainerPageModel = RefreshContainerPage.update msg model.RefreshContainerPageModel },
            Cmd.none
        | SelectableTextBlockPageMsg msg ->
            { model with
                SelectableTextBlockPageModel = SelectableTextBlockPage.update msg model.SelectableTextBlockPageModel },
            Cmd.none
        | SplitButtonPageMsg msg ->
            { model with
                SplitButtonPageModel = SplitButtonPage.update msg model.SplitButtonPageModel },
            Cmd.none
        | SliderPageMsg msg ->
            { model with
                SliderPageModel = SliderPage.update msg model.SliderPageModel },
            Cmd.none
        | ShapesPageMsg msg ->
            { model with
                ShapesPageModel = ShapesPage.update msg model.ShapesPageModel },
            Cmd.none
        | ScrollBarPageMsg msg ->
            { model with
                ScrollBarPageModel = ScrollBarPage.update msg model.ScrollBarPageModel },
            Cmd.none
        | SplitViewPageMsg msg ->
            { model with
                SplitViewPageModel = SplitViewPage.update msg model.SplitViewPageModel },
            Cmd.none
        | StackPanelPageMsg msg ->
            { model with
                StackPanelPageModel = StackPanelPage.update msg model.StackPanelPageModel },
            Cmd.none
        | ScrollViewerPageMsg msg ->
            { model with
                ScrollViewerPageModel = ScrollViewerPage.update msg model.ScrollViewerPageModel },
            Cmd.none
        | ToggleSplitButtonPageMsg msg ->
            { model with
                ToggleSplitButtonPageModel = ToggleSplitButtonPage.update msg model.ToggleSplitButtonPageModel },
            Cmd.none
        | TextBlockPageMsg msg ->
            { model with
                TextBlockPageModel = TextBlockPage.update msg model.TextBlockPageModel },
            Cmd.none
        | TextBoxPageMsg msg ->
            { model with
                TextBoxPageModel = TextBoxPage.update msg model.TextBoxPageModel },
            Cmd.none
        | TickBarPageMsg msg ->
            { model with
                TickBarPageModel = TickBarPage.update msg model.TickBarPageModel },
            Cmd.none
        | ToggleSwitchPageMsg msg ->
            { model with
                ToggleSwitchPageModel = ToggleSwitchPage.update msg model.ToggleSwitchPageModel },
            Cmd.none
        | ToggleButtonPageMsg msg ->
            { model with
                ToggleButtonPageModel = ToggleButtonPage.update msg model.ToggleButtonPageModel },
            Cmd.none
        | ToolTipPageMsg msg ->
            { model with
                ToolTipPageModel = ToolTipPage.update msg model.ToolTipPageModel },
            Cmd.none
        | TabControlPageMsg msg ->
            { model with
                TabControlPageModel = TabControlPage.update msg model.TabControlPageModel },
            Cmd.none
        | TabStripPageMsg msg ->
            { model with
                TabStripPageModel = TabStripPage.update msg model.TabStripPageModel },
            Cmd.none
        | TransitionsPageMsg msg ->
            { model with
                TransitionsPageModel = TransitionsPage.update msg model.TransitionsPageModel },
            Cmd.none
        | TransformsPageMsg msg ->
            { model with
                TransformsPageModel = TransformsPage.update msg model.TransformsPageModel },
            Cmd.none
        | ThemeAwarePageMsg msg ->
            { model with
                ThemeAwarePageModel = ThemeAwarePage.update msg model.ThemeAwarePageModel },
            Cmd.none
        | UniformGridPageMsg msg ->
            { model with
                UniformGridPageModel = UniformGridPage.update msg model.UniformGridPageModel },
            Cmd.none
        | ViewBoxPageMsg msg ->
            { model with
                ViewBoxPageModel = ViewBoxPage.update msg model.ViewBoxPageModel },
            Cmd.none
