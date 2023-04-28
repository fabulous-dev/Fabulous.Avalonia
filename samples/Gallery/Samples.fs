namespace Gallery

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module Samples =
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
          FormattedTextPageModel = FormattedTextPage.init()
          GesturesPageModel = GesturesPage.init()
          GlyphRunControlPageModel = GlyphRunControlPage.init()
          GridPageModel = GridPage.init()
          GridSplitterPageModel = GridSplitterPage.init()
          ImagePageModel = ImagePage.init()
          LabelPageModel = LabelPage.init()
          LayoutTransformControlPageModel = LayoutTransformControlPage.init()
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
        | FormattedTextPageMsg msg ->
            { model with
                FormattedTextPageModel = FormattedTextPage.update msg model.FormattedTextPageModel },
            Cmd.none

    let view (model: Model) =
        ScrollViewer(
            match model.CurrentPage with
            | Pages.AcrylicPage ->
                VStack(spacing = 20.) {
                    TextBlock("AcrylicPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map AcrylicPageMsg (AcrylicPage.view model.AcrylicPageModel)
                }
            | Pages.AdornerLayerPage ->
                VStack(spacing = 20.) {
                    TextBlock("AdornerLayerPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map AdornerLayerPageMsg (AdornerLayerPage.view model.AdornerLayerPageModel)
                }

            | Pages.AutoCompleteBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("AutoCompleteBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map AutoCompleteBoxPageMsg (AutoCompleteBoxPage.view model.AutoCompleteBoxPageModel)
                }

            | Pages.ButtonsPage ->
                VStack(spacing = 20.) {
                    TextBlock("ButtonsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ButtonsPageMsg (ButtonsPage.view model.ButtonsPageModel)
                }

            | Pages.BorderPage ->
                VStack(spacing = 20.) {
                    TextBlock("BorderPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map BorderPageMsg (BorderPage.view model.BorderPageModel)
                }

            | Pages.CalendarDatePickerPage ->
                VStack(spacing = 20.) {
                    TextBlock("CalendarDatePickerPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map CalendarDatePickerPageMsg (CalendarDatePickerPage.view model.CalendarDatePickerPageModel)
                }

            | Pages.CalendarPage ->
                VStack(spacing = 20.) {
                    TextBlock("CalendarPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map CalendarPageMsg (CalendarPage.view model.CalendarPageModel)
                }

            | Pages.AnimationsPage ->
                VStack(spacing = 20.) {
                    TextBlock("AnimationsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map AnimationsPageMsg (AnimationsPage.view model.AnimationsPageModel)
                }
            | Pages.BrushesPage ->
                VStack(spacing = 20.) {
                    TextBlock("BrushesPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map BrushesPageMsg (BrushesPage.view model.BrushesPageModel)
                }
            | Pages.ButtonSpinnerPage ->
                VStack(spacing = 20.) {
                    TextBlock("ButtonSpinnerPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ButtonSpinnerPageMsg (ButtonSpinnerPage.view model.ButtonSpinnerPageModel)
                }
            | Pages.CanvasPage ->
                VStack(spacing = 20.) {
                    TextBlock("CanvasPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map CanvasPageMsg (CanvasPage.view model.CanvasPageModel)
                }
            | Pages.CheckBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("CheckBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map CheckBoxPageMsg (CheckBoxPage.view model.CheckBoxPageModel)
                }
            | Pages.CarouselPage ->
                VStack(spacing = 20.) {
                    TextBlock("CarouselPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map CarouselPageMsg (CarouselPage.view model.CarouselPageModel)
                }
            | Pages.ComboBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("ComboBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ComboBoxPageMsg (ComboBoxPage.view model.ComboBoxPageModel)
                }
            | Pages.ContextMenuPage ->
                VStack(spacing = 20.) {
                    TextBlock("ContextMenuPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ContextMenuPageMsg (ContextMenuPage.view model.ContextMenuPageModel)
                }
            | Pages.ContextFlyoutPage ->
                VStack(spacing = 20.) {
                    TextBlock("ContextFlyoutPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ContextFlyoutPageMsg (ContextFlyoutPage.view model.ContextFlyoutPageModel)
                }
            | Pages.ClippingPage ->
                VStack(spacing = 20.) {
                    TextBlock("ClippingPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ClippingPageMsg (ClippingPage.view model.ClippingPageModel)
                }
            | Pages.DockPanelPage ->
                VStack(spacing = 20.) {
                    TextBlock("DockPanelPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map DockPanelPageMsg (DockPanelPage.view model.DockPanelPageModel)
                }
            | Pages.DropDownButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("DropDownButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map DropDownButtonPageMsg (DropDownButtonPage.view model.DropDownButtonPageModel)
                }
            | Pages.DrawingPage ->
                VStack(spacing = 20.) {
                    TextBlock("DrawingPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map DrawingPageMsg (DrawingPage.view model.DrawingPageModel)
                }
            | Pages.ExpanderPage ->
                VStack(spacing = 20.) {
                    TextBlock("ExpanderPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ExpanderPageMsg (ExpanderPage.view model.ExpanderPageModel)
                }
            | Pages.FlyoutPage ->
                VStack(spacing = 20.) {
                    TextBlock("FlyoutPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map FlyoutPageMsg (FlyoutPage.view model.FlyoutPageModel)
                }
            | Pages.FormattedTextPage ->
                VStack(spacing = 20.) {
                    TextBlock("FormattedTextPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map FormattedTextPageMsg (FormattedTextPage.view model.FormattedTextPageModel)
                }
            | Pages.GesturesPage ->
                VStack(spacing = 20.) {
                    TextBlock("GesturesPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GesturesPageMsg (GesturesPage.view model.GesturesPageModel)
                }
            | Pages.GlyphRunControlPage ->
                VStack(spacing = 20.) {
                    TextBlock("GlyphRunControlPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GlyphRunControlPageMsg (GlyphRunControlPage.view model.GlyphRunControlPageModel)
                }
            | Pages.GridPage ->
                VStack(spacing = 20.) {
                    TextBlock("GridPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GridPageMsg (GridPage.view model.GridPageModel)
                }
            | Pages.GridSplitterPage ->
                VStack(spacing = 20.) {
                    TextBlock("GridSplitterPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GridSplitterPageMsg (GridSplitterPage.view model.GridSplitterPageModel)
                }
            | Pages.ImagePage ->
                VStack(spacing = 20.) {
                    TextBlock("ImagePage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ImagePageMsg (ImagePage.view model.ImagePageModel)
                }
            | Pages.LabelPage ->
                VStack(spacing = 20.) {
                    TextBlock("LabelPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map LabelPageMsg (LabelPage.view model.LabelPageModel)
                }
            | Pages.LayoutTransformControlPage ->
                VStack(spacing = 20.) {
                    TextBlock("LayoutTransformControlPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map LayoutTransformControlPageMsg (LayoutTransformControlPage.view model.LayoutTransformControlPageModel)
                }
            | Pages.ListBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("ListBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ListBoxPageMsg (ListBoxPage.view model.ListBoxPageModel)
                }
            | Pages.MenuFlyoutPage ->
                VStack(spacing = 20.) {
                    TextBlock("MenuFlyoutPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map MenuFlyoutPageMsg (MenuFlyoutPage.view model.MenuFlyoutPageModel)
                }
            | Pages.MaskedTextBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("MaskedTextBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map MaskedTextBoxPageMsg (MaskedTextBoxPage.view model.MaskedTextBoxPageModel)
                }
            | Pages.MenuPage ->
                VStack(spacing = 20.) {
                    TextBlock("MenuPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map MenuPageMsg (MenuPage.view model.MenuPageModel)
                }
            | Pages.NumericUpDownPage ->
                VStack(spacing = 20.) {
                    TextBlock("NumericUpDownPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map NumericUpDownPageMsg (NumericUpDownPage.view model.NumericUpDownPageModel)
                }
            | Pages.ProgressBarPage ->
                VStack(spacing = 20.) {
                    TextBlock("ProgressBarPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ProgressBarPageMsg (ProgressBarPage.view model.ProgressBarPageModel)
                }
            | Pages.PanelPage ->
                VStack(spacing = 20.) {
                    TextBlock("PanelPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map PanelPageMsg (PanelPage.view model.PanelPageModel)
                }
            | Pages.PathIconPage ->
                VStack(spacing = 20.) {
                    TextBlock("PathIconPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map PathIconPageMsg (PathIconPage.view model.PathIconPageModel)
                }
            | Pages.PopupPage ->
                VStack(spacing = 20.) {
                    TextBlock("PopupPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map PopupPageMsg (PopupPage.view model.PopupPageModel)
                }
            | Pages.PageTransitionsPage ->
                VStack(spacing = 20.) {
                    TextBlock("PageTransitionsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map PageTransitionsPageMsg (PageTransitionsPage.view model.PageTransitionsPageModel)
                }
            | Pages.RepeatButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("RepeatButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map RepeatButtonPageMsg (RepeatButtonPage.view model.RepeatButtonPageModel)
                }
            | Pages.RadioButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("RadioButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map RadioButtonPageMsg (RadioButtonPage.view model.RadioButtonPageModel)
                }
            | Pages.RefreshContainerPage ->
                VStack(spacing = 20.) {
                    TextBlock("RefreshContainerPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map RefreshContainerPageMsg (RefreshContainerPage.view model.RefreshContainerPageModel)
                }
            | Pages.SelectableTextBlockPage ->
                VStack(spacing = 20.) {
                    TextBlock("SelectableTextBlockPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map SelectableTextBlockPageMsg (SelectableTextBlockPage.view model.SelectableTextBlockPageModel)
                }
            | Pages.SplitButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("SplitButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map SplitButtonPageMsg (SplitButtonPage.view model.SplitButtonPageModel)
                }
            | Pages.SliderPage ->
                VStack(spacing = 20.) {
                    TextBlock("SliderPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map SliderPageMsg (SliderPage.view model.SliderPageModel)
                }
            | Pages.ShapesPage ->
                VStack(spacing = 20.) {
                    TextBlock("ShapesPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ShapesPageMsg (ShapesPage.view model.ShapesPageModel)
                }
            | Pages.ScrollBarPage ->
                VStack(spacing = 20.) {
                    TextBlock("ScrollBarPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ScrollBarPageMsg (ScrollBarPage.view model.ScrollBarPageModel)
                }
            | Pages.SplitViewPage ->
                VStack(spacing = 20.) {
                    TextBlock("SplitViewPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map SplitViewPageMsg (SplitViewPage.view model.SplitViewPageModel)
                }
            | Pages.StackPanelPage ->
                VStack(spacing = 20.) {
                    TextBlock("StackPanelPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map StackPanelPageMsg (StackPanelPage.view model.StackPanelPageModel)
                }
            | Pages.ScrollViewerPage ->
                VStack(spacing = 20.) {
                    TextBlock("ScrollViewerPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ScrollViewerPageMsg (ScrollViewerPage.view model.ScrollViewerPageModel)
                }
            | Pages.ToggleSplitButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("ToggleSplitButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ToggleSplitButtonPageMsg (ToggleSplitButtonPage.view model.ToggleSplitButtonPageModel)
                }
            | Pages.TextBlockPage ->
                VStack(spacing = 20.) {
                    TextBlock("TextBlockPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TextBlockPageMsg (TextBlockPage.view model.TextBlockPageModel)
                }
            | Pages.TextBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("TextBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TextBoxPageMsg (TextBoxPage.view model.TextBoxPageModel)
                }
            | Pages.TickBarPage ->
                VStack(spacing = 20.) {
                    TextBlock("TickBarPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TickBarPageMsg (TickBarPage.view model.TickBarPageModel)
                }
            | Pages.ToggleSwitchPage ->
                VStack(spacing = 20.) {
                    TextBlock("ToggleSwitchPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ToggleSwitchPageMsg (ToggleSwitchPage.view model.ToggleSwitchPageModel)
                }
            | Pages.ToggleButtonPage ->
                VStack(spacing = 20.) {
                    TextBlock("ToggleButtonPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ToggleButtonPageMsg (ToggleButtonPage.view model.ToggleButtonPageModel)
                }
            | Pages.ToolTipPage ->
                VStack(spacing = 20.) {
                    TextBlock("ToolTipPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ToolTipPageMsg (ToolTipPage.view model.ToolTipPageModel)
                }
            | Pages.TabControlPage ->
                VStack(spacing = 20.) {
                    TextBlock("TabControlPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TabControlPageMsg (TabControlPage.view model.TabControlPageModel)
                }
            | Pages.TabStripPage ->
                VStack(spacing = 20.) {
                    TextBlock("TabStripPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TabStripPageMsg (TabStripPage.view model.TabStripPageModel)
                }
            | Pages.TransitionsPage ->
                VStack(20.) {
                    TextBlock("TransitionsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TransitionsPageMsg (TransitionsPage.view model.TransitionsPageModel)
                }
            | Pages.TransformsPage ->
                VStack(spacing = 20.) {
                    TextBlock("TransformsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map TransformsPageMsg (TransformsPage.view model.TransformsPageModel)
                }
            | Pages.ThemeAwarePage ->
                VStack(spacing = 20.) {
                    TextBlock("ThemeAwarePage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ThemeAwarePageMsg (ThemeAwarePage.view model.ThemeAwarePageModel)
                }
            | Pages.UniformGridPage ->
                VStack(spacing = 20.) {
                    TextBlock("UniformGridPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map UniformGridPageMsg (UniformGridPage.view model.UniformGridPageModel)
                }
            | Pages.ViewBoxPage ->
                VStack(spacing = 20.) {
                    TextBlock("ViewBoxPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map ViewBoxPageMsg (ViewBoxPage.view model.ViewBoxPageModel)
                }
        )
