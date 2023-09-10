namespace Gallery.Root

open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.Avalonia
open Gallery.Pages
open Types

open type Fabulous.Avalonia.View

[<AutoOpen>]
module EmptyPanelBuilders =
    type Fabulous.Avalonia.View with

        static member EmptyPanel<'msg>() =
            WidgetBuilder<'msg, IFabPanel>(Panel.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module HamburgerMenu =
    let settingsButtonStyle (this: WidgetBuilder<'msg, IFabButton>) =
        this
            .horizontalContentAlignment(HorizontalAlignment.Stretch)
            .verticalContentAlignment(VerticalAlignment.Stretch)
            .horizontalAlignment(HorizontalAlignment.Stretch)
            .verticalAlignment(VerticalAlignment.Stretch)
            .fontWeight(FontWeight.Normal)
            .minHeight(0.)
            .height(36.)
            .background(Brushes.Transparent)
            .padding(12., 0., 4., 0.)
            .margin(4., 0., 8., 0.)
            .cornerRadius(8.)
            .clipToBounds(false)

    let mainView model =
        Grid(rowdefs = [ Star; Auto ], coldefs = [ Star ]) {
            HamburgerMenu() {
                TabItem("AcrylicPage", AnyView(View.map AcrylicPageMsg (AcrylicPage.view model.AcrylicPageModel)))
                TabItem("AdornerLayerPage", AnyView(View.map AdornerLayerPageMsg (AdornerLayerPage.view model.AdornerLayerPageModel)))
                TabItem("AutoCompleteBoxPage", AnyView(View.map AutoCompleteBoxPageMsg (AutoCompleteBoxPage.view model.AutoCompleteBoxPageModel)))
                TabItem("AnimationsPage", AnyView(View.map AnimationsPageMsg (AnimationsPage.view model.AnimationsPageModel)))
                TabItem("ImplicitCanvasAnimationsPage", AnyView(View.map ImplicitCanvasAnimationsPageMsg (ImplicitCanvasAnimationsPage.view model.ImplicitCanvasAnimationsPageModel)))
                TabItem("CompositorAnimationsPage", AnyView(View.map CompositorAnimationsPageMsg (CompositorAnimationsPage.view model.CompositorAnimationsPageModel)))
                TabItem("ButtonsPage", AnyView(View.map ButtonsPageMsg (ButtonsPage.view model.ButtonsPageModel)))
                TabItem("BrushesPage", AnyView(View.map BrushesPageMsg (BrushesPage.view model.BrushesPageModel)))
                TabItem("ButtonSpinnerPage", AnyView(View.map ButtonSpinnerPageMsg (ButtonSpinnerPage.view model.ButtonSpinnerPageModel)))
                TabItem("BorderPage", AnyView(View.map BorderPageMsg (BorderPage.view model.BorderPageModel)))
                TabItem("CalendarPage", AnyView(View.map CalendarPageMsg (CalendarPage.view model.CalendarPageModel)))
                TabItem("CalendarDatePickerPage", AnyView(View.map CalendarDatePickerPageMsg (CalendarDatePickerPage.view model.CalendarDatePickerPageModel)))
                TabItem("CanvasPage", AnyView(View.map CanvasPageMsg (CanvasPage.view model.CanvasPageModel)))
                TabItem("CheckBoxPage", AnyView(View.map CheckBoxPageMsg (CheckBoxPage.view model.CheckBoxPageModel)))
                TabItem("CarouselPage", AnyView(View.map CarouselPageMsg (CarouselPage.view model.CarouselPageModel)))
                TabItem("ComboBoxPage", AnyView(View.map ComboBoxPageMsg (ComboBoxPage.view model.ComboBoxPageModel)))
                TabItem("CompositionPage", AnyView(View.map CompositionPageMsg (CompositionPage.view model.CompositionPageModel)))
                TabItem("ContextMenuPage", AnyView(View.map ContextMenuPageMsg (ContextMenuPage.view model.ContextMenuPageModel)))
                TabItem("ContextFlyoutPage", AnyView(View.map ContextFlyoutPageMsg (ContextFlyoutPage.view model.ContextFlyoutPageModel)))
                TabItem("ClippingPage", AnyView(View.map ClippingPageMsg (ClippingPage.view model.ClippingPageModel)))
                TabItem("ClipboardPage", AnyView(View.map ClipboardPageMsg (ClipboardPage.view model.ClipboardPageModel)))
                TabItem("DockPanelPage", AnyView(View.map DockPanelPageMsg (DockPanelPage.view model.DockPanelPageModel)))
                TabItem("DialogsPage", AnyView(View.map DialogsPageMsg (DialogsPage.view model.DialogsPageModel)))
                TabItem("DragAndDropPage", AnyView(View.map DragAndDropPageMsg (DragAndDropPage.view model.DragAndDropPageModel)))
                TabItem("DropDownButtonPage", AnyView(View.map DropDownButtonPageMsg (DropDownButtonPage.view model.DropDownButtonPageModel)))
                TabItem("DrawLineAnimationPage", AnyView(View.map DrawLineAnimationPageMsg (DrawLineAnimationPage.view model.DrawLineAnimationPageModel)))
                TabItem("DrawingPage", AnyView(View.map DrawingPageMsg (DrawingPage.view model.DrawingPageModel)))
                TabItem("EffectsPage", AnyView(View.map EffectsPageMsg (EffectsPage.view model.EffectsPageModel)))
                TabItem("ExpanderPage", AnyView(View.map ExpanderPageMsg (ExpanderPage.view model.ExpanderPageModel)))
                TabItem("FlyoutPage", AnyView(View.map FlyoutPageMsg (FlyoutPage.view model.FlyoutPageModel)))
                TabItem("GesturesPage", AnyView(View.map GesturesPageMsg (GesturesPage.view model.GesturesPageModel)))
                TabItem("GeometriesPage", AnyView(View.map GeometriesPageMsg (GeometriesPage.view model.GeometriesPageModel)))
                TabItem("GridPage", AnyView(View.map GridPageMsg (GridPage.view model.GridPageModel)))
                TabItem("GridSplitterPage", AnyView(View.map GridSplitterPageMsg (GridSplitterPage.view model.GridSplitterPageModel)))
                TabItem("ImagePage", AnyView(View.map ImagePageMsg (ImagePage.view model.ImagePageModel)))
                TabItem("LabelPage", AnyView(View.map LabelPageMsg (LabelPage.view model.LabelPageModel)))
                TabItem("LayoutTransformControlPage", AnyView(View.map LayoutTransformControlPageMsg (LayoutTransformControlPage.view model.LayoutTransformControlPageModel)))
                TabItem("LineBoundsDemoControlPage", AnyView(View.map LineBoundsDemoControlPageMsg (LineBoundsDemoControlPage.view model.LineBoundsDemoControlPageModel)))
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
                TabItem("SelectableTextBlockPage", AnyView(View.map SelectableTextBlockPageMsg (SelectableTextBlockPage.view model.SelectableTextBlockPageModel)))
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
                TabItem("TabStripPage", AnyView(View.map TabStripPageMsg (TabStripPage.view model.TabStripPageModel)))
                TabItem("TransitionsPage", AnyView(View.map TransitionsPageMsg (TransitionsPage.view model.TransitionsPageModel)))
                TabItem("TransformsPage", AnyView(View.map TransformsPageMsg (TransformsPage.view model.TransformsPageModel)))
                TabItem("ThemeAwarePage", AnyView(View.map ThemeAwarePageMsg (ThemeAwarePage.view model.ThemeAwarePageModel)))
                TabItem("UniformGridPage", AnyView(View.map UniformGridPageMsg (UniformGridPage.view model.UniformGridPageModel)))
                TabItem("ViewBoxPage", AnyView(View.map ViewBoxPageMsg (ViewBoxPage.view model.ViewBoxPageModel)))
         
            }//.onSelectionChanged(OnSelectionChanged)
            
            // Button("Settings", Settings)
            //     .style(settingsButtonStyle)
            //     .gridRow(1)
            //     .flyout(
            //         Flyout(
            //             VStack() {
            //                 (ComboBox() {
            //                     ComboBoxItem("None")
            //                     ComboBoxItem("BorderOnly")
            //                     ComboBoxItem("Full")
            //                 })
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .placeholderText("Decorations")
            //                     .onSelectionChanged(DecorationsOnSelectionChanged)
            //
            //                 ComboBox(model.ThemeVariants, (fun i -> TextBlock(i.ToString())))
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .placeholderText("Themes")
            //                     .onSelectionChanged(ThemeVariantsOnSelectionChanged)
            //
            //                 ComboBox(model.FlowDirections, (fun x -> TextBlock(x.ToString())))
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .placeholderText("FlowDirections")
            //                     .onSelectionChanged(FlowDirectionsOnSelectionChanged)
            //
            //                 (ComboBox() {
            //                     ComboBoxItem("Fluent")
            //                     ComboBoxItem("Simple")
            //                 })
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .selectedIndex(0)
            //
            //                 ComboBox(model.TransparencyLevels, (fun x -> TextBlock(x.ToString())))
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .placeholderText("TransparencyLevels")
            //                     .onSelectionChanged(TransparencyLevelsOnSelectionChanged)
            //
            //                 (ComboBox() {
            //                     ComboBoxItem("Normal")
            //                     ComboBoxItem("Minimized")
            //                     ComboBoxItem("Maximized")
            //                     ComboBoxItem("FullScreen")
            //                 })
            //                     .horizontalAlignment(HorizontalAlignment.Stretch)
            //                     .selectedIndex(0)
            //             }
            //         )
            //     )
        }
        // Grid() {
        //     SplitView(
        //         paneContent(model),
        //         (Dock() {
        //             let headerLeftMargin = if model.IsPanOpen then 12. else 52.
        //
        //             Border(
        //                 TextBlock(model.HeaderText)
        //                     .classes([ "h3" ])
        //                     .verticalAlignment(VerticalAlignment.Center)
        //                     .margin(Thickness(headerLeftMargin, 0., 0., 0.))
        //                     .transition(
        //                         ThicknessTransition(TextBlock.MarginProperty, TimeSpan.FromSeconds(1.))
        //                             .easing(Easing.Parse("0.1, 0.9, 0.2, 1.0"))
        //                     )
        //             )
        //                 .dock(Dock.Top)
        //                 .background(Brushes.Transparent)
        //
        //             let cornerRadius = if model.IsPanOpen then 8. else 0.
        //
        //             Border(
        //                 Border(
        //                     match model.Navigation.CurrentPage with
        //                     // ScrollBarPageModel does not work when wrapped in a ScrollViewer
        //                     | ScrollBarPageModel _ -> AnyView(NavigationState.view SubpageMsg model.Navigation.CurrentPage)
        //                     | _ ->
        //                         AnyView(
        //                             ScrollViewer(NavigationState.view SubpageMsg model.Navigation.CurrentPage)
        //                                 .verticalScrollBarVisibility(ScrollBarVisibility.Auto)
        //                                 .horizontalScrollBarVisibility(ScrollBarVisibility.Auto)
        //                                 .background(Brushes.Transparent)
        //                                 .padding(Thickness(16.))
        //                         )
        //                 )
        //                     .margin(Thickness(4., 0., 0., 0.))
        //                     .cornerRadius(CornerRadius(cornerRadius, 0., 0., 0.))
        //                     .boxShadow("0 0 1 1 #2000")
        //                     .transition(CornerRadiusTransition(Border.CornerRadiusProperty, TimeSpan.FromSeconds(1.)))
        //             )
        //         })
        //             .background(Brushes.Transparent)
        //     )
        //         .isPresented(model.IsPanOpen, OpenPanChanged)
        //         .displayMode(SplitViewDisplayMode.Inline)
        //         .panePlacement(SplitViewPanePlacement.Left)
        //         .paneBackground(Brushes.Transparent)
        //
        //     ToggleButton(
        //         model.IsPanOpen,
        //         OpenPanChanged,
        //         PathIcon(Paths.Path3)
        //             .foreground(ThemeAware.With(Brush.Parse("#99000000"), Brush.Parse("#99FFFFFF")))
        //     )
        //         .width(40.)
        //         .height(32.)
        //         .margin(4., 2., 0., 0.)
        //         .padding(0.)
        //         .horizontalAlignment(HorizontalAlignment.Left)
        //         .verticalAlignment(VerticalAlignment.Top)
        //         .horizontalContentAlignment(HorizontalAlignment.Center)
        //         .cornerRadius(4.)
        // }
