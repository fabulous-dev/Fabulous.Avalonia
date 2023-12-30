namespace Gallery

open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia
open Gallery
open Types

open type Fabulous.Avalonia.View

module HamburgerMenu =
    let mainView model =
        Grid(rowdefs = [ Star; Auto ], coldefs = [ Star ]) {
            (HamburgerMenu() {
                TabItem("AcrylicPage", AnyView(View.map AcrylicPageMsg (AcrylicPage.view model.AcrylicPageModel)))
                TabItem("AdornerLayerPage", AnyView(View.map AdornerLayerPageMsg (AdornerLayerPage.view model.AdornerLayerPageModel)))
                TabItem("AutoCompleteBoxPage", AnyView(View.map AutoCompleteBoxPageMsg (AutoCompleteBoxPage.view model.AutoCompleteBoxPageModel)))
                TabItem("ButtonsPage", AnyView(View.map ButtonsPageMsg (ButtonsPage.view model.ButtonsPageModel)))
                TabItem("ButtonSpinnerPage", AnyView(View.map ButtonSpinnerPageMsg (ButtonSpinnerPage.view model.ButtonSpinnerPageModel)))
                TabItem("BorderPage", AnyView(View.map BorderPageMsg (BorderPage.view model.BorderPageModel)))
                TabItem("CalendarPage", AnyView(View.map CalendarPageMsg (CalendarPage.view model.CalendarPageModel)))
                TabItem("CalendarDatePickerPage", AnyView(View.map CalendarDatePickerPageMsg (CalendarDatePickerPage.view model.CalendarDatePickerPageModel)))
                TabItem("CanvasPage", AnyView(View.map CanvasPageMsg (CanvasPage.view model.CanvasPageModel)))
                TabItem("CheckBoxPage", AnyView(View.map CheckBoxPageMsg (CheckBoxPage.view model.CheckBoxPageModel)))
                TabItem("CarouselPage", AnyView(View.map CarouselPageMsg (CarouselPage.view model.CarouselPageModel)))
                TabItem("ComboBoxPage", AnyView(View.map ComboBoxPageMsg (ComboBoxPage.view model.ComboBoxPageModel)))
                TabItem("ColorPickerPage", AnyView(View.map ColorPickerPageMsg (ColorPickerPage.view model.ColorPickerPageModel)))
                TabItem("CompositionPage", AnyView(View.map CompositionPageMsg (CompositionPage.view model.CompositionPageModel)))
                TabItem("ContextMenuPage", AnyView(View.map ContextMenuPageMsg (ContextMenuPage.view model.ContextMenuPageModel)))
                TabItem("ContextFlyoutPage", AnyView(View.map ContextFlyoutPageMsg (ContextFlyoutPage.view model.ContextFlyoutPageModel)))
                TabItem("ClipboardPage", AnyView(View.map ClipboardPageMsg (ClipboardPage.view model.ClipboardPageModel)))
                TabItem("CursorPage", AnyView(View.map CursorPageMsg (CursorPage.view model.CursorPageModel)))
                TabItem("DataGridPage", AnyView(View.map DataGridPageMsg (DataGridPage.view model.DataGridPageModel)))
                TabItem("DockPanelPage", AnyView(View.map DockPanelPageMsg (DockPanelPage.view model.DockPanelPageModel)))
                TabItem("DialogsPage", AnyView(View.map DialogsPageMsg (DialogsPage.view model.DialogsPageModel)))
                TabItem("DragAndDropPage", AnyView(View.map DragAndDropPageMsg (DragAndDropPage.view model.DragAndDropPageModel)))
                TabItem("DropDownButtonPage", AnyView(View.map DropDownButtonPageMsg (DropDownButtonPage.view model.DropDownButtonPageModel)))
                TabItem("EffectsPage", AnyView(View.map EffectsPageMsg (EffectsPage.view model.EffectsPageModel)))
                TabItem("ExpanderPage", AnyView(View.map ExpanderPageMsg (ExpanderPage.view model.ExpanderPageModel)))
                TabItem("FlyoutPage", AnyView(View.map FlyoutPageMsg (FlyoutPage.view model.FlyoutPageModel)))
                TabItem("GesturesPage", AnyView(View.map GesturesPageMsg (GesturesPage.view model.GesturesPageModel)))
                TabItem("GeometriesPage", AnyView(View.map GeometriesPageMsg (GeometriesPage.view model.GeometriesPageModel)))
                TabItem("GridPage", AnyView(View.map GridPageMsg (GridPage.view model.GridPageModel)))
                TabItem("GridSplitterPage", AnyView(View.map GridSplitterPageMsg (GridSplitterPage.view model.GridSplitterPageModel)))
                TabItem("ImagePage", AnyView(View.map ImagePageMsg (ImagePage.view model.ImagePageModel)))
                TabItem("ItemsRepeaterPage", AnyView(View.map ItemsRepeaterPageMsg (ItemsRepeaterPage.view model.ItemsRepeaterPageModel)))
                TabItem("LabelPage", AnyView(View.map LabelPageMsg (LabelPage.view model.LabelPageModel)))

                TabItem(
                    "LayoutTransformControlPage",
                    AnyView(View.map LayoutTransformControlPageMsg (LayoutTransformControlPage.view model.LayoutTransformControlPageModel))
                )

                TabItem("ListBoxPage", AnyView(View.map ListBoxPageMsg (ListBoxPage.view model.ListBoxPageModel)))
                TabItem("MenuFlyoutPage", AnyView(View.map MenuFlyoutPageMsg (MenuFlyoutPage.view model.MenuFlyoutPageModel)))
                TabItem("MaskedTextBoxPage", AnyView(View.map MaskedTextBoxPageMsg (MaskedTextBoxPage.view model.MaskedTextBoxPageModel)))
                TabItem("MenuPage", AnyView(View.map MenuPageMsg (MenuPage.view model.MenuPageModel)))
                TabItem("NumericUpDownPage", AnyView(View.map NumericUpDownPageMsg (NumericUpDownPage.view model.NumericUpDownPageModel)))
                TabItem("NotificationsPage", AnyView(View.map NotificationsPageMsg (NotificationsPage.view model.NotificationsPageModel)))
                TabItem("OpenGLPage", AnyView(View.map OpenGLPageMsg (OpenGLPage.view model.OpenGLPageModel)))
                TabItem("ProgressBarPage", AnyView(View.map ProgressBarPageMsg (ProgressBarPage.view model.ProgressBarPageModel)))
                TabItem("PanelPage", AnyView(View.map PanelPageMsg (PanelPage.view model.PanelPageModel)))
                TabItem("PathIconPage", AnyView(View.map PathIconPageMsg (PathIconPage.view model.PathIconPageModel)))
                TabItem("PointersPage", AnyView(View.map PointersPageMsg (PointersPage.view model.PointersPageModel)))
                TabItem("PopupPage", AnyView(View.map PopupPageMsg (PopupPage.view model.PopupPageModel)))
                TabItem("PageTransitionsPage", AnyView(View.map PageTransitionsPageMsg (PageTransitionsPage.view model.PageTransitionsPageModel)))
                TabItem("RepeatButtonPage", AnyView(View.map RepeatButtonPageMsg (RepeatButtonPage.view model.RepeatButtonPageModel)))
                TabItem("RadioButtonPage", AnyView(View.map RadioButtonPageMsg (RadioButtonPage.view model.RadioButtonPageModel)))
                TabItem("RefreshContainerPage", AnyView(View.map RefreshContainerPageMsg (RefreshContainerPage.view model.RefreshContainerPageModel)))

                TabItem(
                    "SelectableTextBlockPage",
                    AnyView(View.map SelectableTextBlockPageMsg (SelectableTextBlockPage.view model.SelectableTextBlockPageModel))
                )

                TabItem("SplitButtonPage", AnyView(View.map SplitButtonPageMsg (SplitButtonPage.view model.SplitButtonPageModel)))
                TabItem("SliderPage", AnyView(View.map SliderPageMsg (SliderPage.view model.SliderPageModel)))
                TabItem("ShapesPage", AnyView(View.map ShapesPageMsg (ShapesPage.view model.ShapesPageModel)))
                TabItem("ScrollBarPage", AnyView(View.map ScrollBarPageMsg (ScrollBarPage.view model.ScrollBarPageModel)))
                TabItem("SplitViewPage", AnyView(View.map SplitViewPageMsg (SplitViewPage.view model.SplitViewPageModel)))
                TabItem("StackPanelPage", AnyView(View.map StackPanelPageMsg (StackPanelPage.view model.StackPanelPageModel)))
                TabItem("StylesPage", AnyView(View.map StylesPageMsg (StylesPage.view model.StylesPageModel)))
                TabItem("ScrollViewerPage", AnyView(View.map ScrollViewerPageMsg (ScrollViewerPage.view model.ScrollViewerPageModel)))
                TabItem("ToggleSplitButtonPage", AnyView(View.map ToggleSplitButtonPageMsg (ToggleSplitButtonPage.view model.ToggleSplitButtonPageModel)))
                TabItem("TextBlockPage", AnyView(View.map TextBlockPageMsg (TextBlockPage.view model.TextBlockPageModel)))
                TabItem("TextBoxPage", AnyView(View.map TextBoxPageMsg (TextBoxPage.view model.TextBoxPageModel)))
                TabItem("TickBarPage", AnyView(View.map TickBarPageMsg (TickBarPage.view model.TickBarPageModel)))
                TabItem("ToggleSwitchPage", AnyView(View.map ToggleSwitchPageMsg (ToggleSwitchPage.view model.ToggleSwitchPageModel)))
                TabItem("ToggleButtonPage", AnyView(View.map ToggleButtonPageMsg (ToggleButtonPage.view model.ToggleButtonPageModel)))
                TabItem("ToolTipPage", AnyView(View.map ToolTipPageMsg (ToolTipPage.view model.ToolTipPageModel)))
                TabItem("TabControlPage", AnyView(View.map TabControlPageMsg (TabControlPage.view model.TabControlPageModel)))
                TabItem("TreeViewPage", AnyView(View.map TreeViewPageMsg (TreeViewPage.view model.TreeViewPageModel)))
                TabItem("TreeDataGridViewPage", AnyView(View.map TreeDataGridPageMsg (TreeDataGridPage.view model.TreeDataGridPageModel)))

                TabItem(
                    "TransitioningContentPage",
                    AnyView(View.map TransitioningContentControlPageMsg (TransitioningContentControlPage.view model.TransitioningContentControlPageModel))
                )

                TabItem("TabStripPage", AnyView(View.map TabStripPageMsg (TabStripPage.view model.TabStripPageModel)))
                TabItem("ThemeAwarePage", AnyView(View.map ThemeAwarePageMsg (ThemeAwarePage.view model.ThemeAwarePageModel)))
                TabItem("UniformGridPage", AnyView(View.map UniformGridPageMsg (UniformGridPage.view model.UniformGridPageModel)))
                TabItem("ViewBoxPage", AnyView(View.map ViewBoxPageMsg (ViewBoxPage.view model.ViewBoxPageModel)))
            })
                .attachedFlyout(
                    Flyout(
                        VStack() {
                            (ComboBox() {
                                ComboBoxItem("None")
                                ComboBoxItem("BorderOnly")
                                ComboBoxItem("Full")
                            })
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .placeholderText("Decorations")
                                .onSelectionChanged(DecorationsOnSelectionChanged)

                            ComboBox(model.ThemeVariants, (fun i -> TextBlock(i.ToString())))
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .placeholderText("Themes")
                                .onSelectionChanged(ThemeVariantsOnSelectionChanged)

                            ComboBox(model.FlowDirections, (fun x -> TextBlock(x.ToString())))
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .placeholderText("FlowDirections")
                                .onSelectionChanged(FlowDirectionsOnSelectionChanged)

                            (ComboBox() {
                                ComboBoxItem("Fluent")
                                ComboBoxItem("Simple")
                            })
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .selectedIndex(0)

                            ComboBox(model.TransparencyLevels, (fun x -> TextBlock(x.ToString())))
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .placeholderText("TransparencyLevels")
                                .onSelectionChanged(TransparencyLevelsOnSelectionChanged)

                            (ComboBox() {
                                ComboBoxItem("Normal")
                                ComboBoxItem("Minimized")
                                ComboBoxItem("Maximized")
                                ComboBoxItem("FullScreen")
                            })
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .selectedIndex(0)
                        }
                    )
                        .showMode(FlyoutShowMode.Standard)
                        .placement(PlacementMode.RightEdgeAlignedTop)
                )
        }
