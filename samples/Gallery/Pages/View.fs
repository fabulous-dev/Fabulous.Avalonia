namespace Gallery.Pages

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open Gallery.Pages.Types

open type Fabulous.Avalonia.View

module View =

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
            | Pages.GesturesPage ->
                VStack(spacing = 20.) {
                    TextBlock("GesturesPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GesturesPageMsg (GesturesPage.view model.GesturesPageModel)
                }

            | Pages.GeometriesPage ->
                VStack(spacing = 20.) {
                    TextBlock("GeometriesPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map GeometriesPageMsg (GeometriesPage.view model.GeometriesPageModel)
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

            | Pages.LineBoundsDemoControlPage ->
                VStack(spacing = 20.) {
                    TextBlock("LineBoundsDemoControlPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map LineBoundsDemoControlPageMsg (LineBoundsDemoControlPage.view model.LineBoundsDemoControlPageModel)
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

            | Pages.NotificationsPage ->
                VStack(spacing = 20.) {
                    TextBlock("NotificationsPage").fontSize(20.)
                    Separator().background(SolidColorBrush(Colors.Gray))

                    View.map NotificationsPageMsg (NotificationsPage.view model.NotificationsPageModel)
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
