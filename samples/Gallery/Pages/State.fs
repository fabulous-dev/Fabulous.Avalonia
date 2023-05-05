namespace Gallery.Pages

open Fabulous

open Gallery
open Types

module State =
        
    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav
        
    let init page =
        let m , cmd = AcrylicPage.init()
        let m1, cmd = AdornerLayerPage.init()
        { AcrylicPageModel = m
          AdornerLayerPageModel = m1
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
          NotificationsPageModel = NotificationsPage.init()
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
          ViewBoxPageModel = ViewBoxPage.init() }, []

    let update msg model =
        match msg with
        | AcrylicPageMsg msg ->
            { model with
                AcrylicPageModel = model.AcrylicPageModel },
            []
        | AdornerLayerPageMsg msg ->
            { model with
                AdornerLayerPageModel = model.AdornerLayerPageModel },
            []
        | AutoCompleteBoxPageMsg msg ->
            { model with
                AutoCompleteBoxPageModel = AutoCompleteBoxPage.update msg model.AutoCompleteBoxPageModel },
            []
        | AnimationsPageMsg msg ->
            { model with
                AnimationsPageModel = AnimationsPage.update msg model.AnimationsPageModel },
            []
        | ButtonsPageMsg msg ->
            { model with
                ButtonsPageModel = ButtonsPage.update msg model.ButtonsPageModel },
            []
        | BrushesPageMsg msg ->
            { model with
                BrushesPageModel = BrushesPage.update msg model.BrushesPageModel },
            []
        | ButtonSpinnerPageMsg msg ->
            { model with
                ButtonSpinnerPageModel = ButtonSpinnerPage.update msg model.ButtonSpinnerPageModel },
            []
        | BorderPageMsg msg ->
            { model with
                BorderPageModel = BorderPage.update msg model.BorderPageModel },
            []
        | CalendarPageMsg msg ->
            { model with
                CalendarPageModel = CalendarPage.update msg model.CalendarPageModel },
            Cmd.none
        | CalendarDatePickerPageMsg msg ->
            { model with
                CalendarDatePickerPageModel = CalendarDatePickerPage.update msg model.CalendarDatePickerPageModel },
            []
        | CanvasPageMsg msg ->
            { model with
                CanvasPageModel = CanvasPage.update msg model.CanvasPageModel },
            []
        | CheckBoxPageMsg msg ->
            { model with
                CheckBoxPageModel = CheckBoxPage.update msg model.CheckBoxPageModel },
            Cmd.none
        | CarouselPageMsg msg ->
            { model with
                CarouselPageModel = CarouselPage.update msg model.CarouselPageModel },
            []
        | ComboBoxPageMsg msg ->
            { model with
                ComboBoxPageModel = ComboBoxPage.update msg model.ComboBoxPageModel },
            []
        | ContextMenuPageMsg msg ->
            { model with
                ContextMenuPageModel = ContextMenuPage.update msg model.ContextMenuPageModel },
            []
        | ContextFlyoutPageMsg msg ->
            { model with
                ContextFlyoutPageModel = ContextFlyoutPage.update msg model.ContextFlyoutPageModel },
            []
        | ClippingPageMsg msg ->
            { model with
                ClippingPageModel = ClippingPage.update msg model.ClippingPageModel },
            []
        | DockPanelPageMsg msg ->
            { model with
                DockPanelPageModel = DockPanelPage.update msg model.DockPanelPageModel },
            []
        | DropDownButtonPageMsg msg ->
            { model with
                DropDownButtonPageModel = DropDownButtonPage.update msg model.DropDownButtonPageModel },
            []
        | DrawingPageMsg msg ->
            { model with
                DrawingPageModel = DrawingPage.update msg model.DrawingPageModel },
            []
        | ExpanderPageMsg msg ->
            { model with
                ExpanderPageModel = ExpanderPage.update msg model.ExpanderPageModel },
            []
        | FlyoutPageMsg msg ->
            { model with
                FlyoutPageModel = FlyoutPage.update msg model.FlyoutPageModel },
            []
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
            []
        | GridPageMsg msg ->
            { model with
                GridPageModel = GridPage.update msg model.GridPageModel },
            []
        | GridSplitterPageMsg msg ->
            { model with
                GridSplitterPageModel = GridSplitterPage.update msg model.GridSplitterPageModel },
            []
        | ImagePageMsg msg ->
            { model with
                ImagePageModel = ImagePage.update msg model.ImagePageModel },
            []
        | LabelPageMsg msg ->
            { model with
                LabelPageModel = LabelPage.update msg model.LabelPageModel },
            []
        | LayoutTransformControlPageMsg msg ->
            { model with
                LayoutTransformControlPageModel = LayoutTransformControlPage.update msg model.LayoutTransformControlPageModel },
            []
    
        | LineBoundsDemoControlPageMsg msg ->
            { model with
                LineBoundsDemoControlPageModel = LineBoundsDemoControlPage.update msg model.LineBoundsDemoControlPageModel },
            []
    
        | ListBoxPageMsg msg ->
            { model with
                ListBoxPageModel = ListBoxPage.update msg model.ListBoxPageModel },
            []
        | MenuFlyoutPageMsg msg ->
            { model with
                MenuFlyoutPageModel = MenuFlyoutPage.update msg model.MenuFlyoutPageModel },
            []
        | MaskedTextBoxPageMsg msg ->
            { model with
                MaskedTextBoxPageModel = MaskedTextBoxPage.update msg model.MaskedTextBoxPageModel },
            []
        | MenuPageMsg msg ->
            { model with
                MenuPageModel = MenuPage.update msg model.MenuPageModel },
            []
        | NumericUpDownPageMsg msg ->
            { model with
                NumericUpDownPageModel = NumericUpDownPage.update msg model.NumericUpDownPageModel },
            Cmd.none

        | NotificationsPageMsg msg ->
            { model with
                NotificationsPageModel = NotificationsPage.update msg model.NotificationsPageModel },
            Cmd.none
        | ProgressBarPageMsg msg ->
            { model with
                ProgressBarPageModel = ProgressBarPage.update msg model.ProgressBarPageModel },
            []
        | PanelPageMsg msg ->
            { model with
                PanelPageModel = PanelPage.update msg model.PanelPageModel },
            []
        | PathIconPageMsg msg ->
            { model with
                PathIconPageModel = PathIconPage.update msg model.PathIconPageModel },
            []
        | PopupPageMsg msg ->
            { model with
                PopupPageModel = PopupPage.update msg model.PopupPageModel },
            []
        | PageTransitionsPageMsg msg ->
            { model with
                PageTransitionsPageModel = PageTransitionsPage.update msg model.PageTransitionsPageModel },
            []
        | RepeatButtonPageMsg msg ->
            { model with
                RepeatButtonPageModel = RepeatButtonPage.update msg model.RepeatButtonPageModel },
            []
        | RadioButtonPageMsg msg ->
            { model with
                RadioButtonPageModel = RadioButtonPage.update msg model.RadioButtonPageModel },
            []
        | RefreshContainerPageMsg msg ->
            { model with
                RefreshContainerPageModel = RefreshContainerPage.update msg model.RefreshContainerPageModel },
            []
        | SelectableTextBlockPageMsg msg ->
            { model with
                SelectableTextBlockPageModel = SelectableTextBlockPage.update msg model.SelectableTextBlockPageModel },
            []
        | SplitButtonPageMsg msg ->
            { model with
                SplitButtonPageModel = SplitButtonPage.update msg model.SplitButtonPageModel },
            []
        | SliderPageMsg msg ->
            { model with
                SliderPageModel = SliderPage.update msg model.SliderPageModel },
            []
        | ShapesPageMsg msg ->
            { model with
                ShapesPageModel = ShapesPage.update msg model.ShapesPageModel },
            []
        | ScrollBarPageMsg msg ->
            { model with
                ScrollBarPageModel = ScrollBarPage.update msg model.ScrollBarPageModel },
            []
        | SplitViewPageMsg msg ->
            { model with
                SplitViewPageModel = SplitViewPage.update msg model.SplitViewPageModel },
            []
        | StackPanelPageMsg msg ->
            { model with
                StackPanelPageModel = StackPanelPage.update msg model.StackPanelPageModel },
            []
        | ScrollViewerPageMsg msg ->
            { model with
                ScrollViewerPageModel = ScrollViewerPage.update msg model.ScrollViewerPageModel },
            []
        | ToggleSplitButtonPageMsg msg ->
            { model with
                ToggleSplitButtonPageModel = ToggleSplitButtonPage.update msg model.ToggleSplitButtonPageModel },
            []
        | TextBlockPageMsg msg ->
            { model with
                TextBlockPageModel = TextBlockPage.update msg model.TextBlockPageModel },
            []
        | TextBoxPageMsg msg ->
            { model with
                TextBoxPageModel = TextBoxPage.update msg model.TextBoxPageModel },
            []
        | TickBarPageMsg msg ->
            { model with
                TickBarPageModel = TickBarPage.update msg model.TickBarPageModel },
            []
        | ToggleSwitchPageMsg msg ->
            { model with
                ToggleSwitchPageModel = ToggleSwitchPage.update msg model.ToggleSwitchPageModel },
            []
        | ToggleButtonPageMsg msg ->
            { model with
                ToggleButtonPageModel = ToggleButtonPage.update msg model.ToggleButtonPageModel },
            []
        | ToolTipPageMsg msg ->
            { model with
                ToolTipPageModel = ToolTipPage.update msg model.ToolTipPageModel },
            []
        | TabControlPageMsg msg ->
            { model with
                TabControlPageModel = TabControlPage.update msg model.TabControlPageModel },
            []
        | TabStripPageMsg msg ->
            { model with
                TabStripPageModel = TabStripPage.update msg model.TabStripPageModel },
            []
        | TransitionsPageMsg msg ->
            { model with
                TransitionsPageModel = TransitionsPage.update msg model.TransitionsPageModel },
            []
        | TransformsPageMsg msg ->
            { model with
                TransformsPageModel = TransformsPage.update msg model.TransformsPageModel },
            []
        | ThemeAwarePageMsg msg ->
            { model with
                ThemeAwarePageModel = ThemeAwarePage.update msg model.ThemeAwarePageModel },
            []
        | UniformGridPageMsg msg ->
            { model with
                UniformGridPageModel = UniformGridPage.update msg model.UniformGridPageModel },
            []
        | ViewBoxPageMsg msg ->
            { model with
                ViewBoxPageModel = ViewBoxPage.update msg model.ViewBoxPageModel },
            []
        | Previous -> model, []
