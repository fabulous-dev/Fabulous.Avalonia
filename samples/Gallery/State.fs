namespace Gallery

open Avalonia.Media
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Gallery
open Types

module State =
    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NewMsg msg -> Cmd.ofMsg msg
        | SubpageCmdMsgs cmdMsgs ->
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
                | CalendarPageCmdMsgs subCmdMsgs -> map CalendarPage.mapCmdMsgToCmd CalendarPageMsg subCmdMsgs
                | CalendarDatePickerPageCmdMsgs subCmdMsgs -> map CalendarDatePickerPage.mapCmdMsgToCmd CalendarDatePickerPageMsg subCmdMsgs
                | CanvasPageCmdMsgs subCmdMsgs -> map CanvasPage.mapCmdMsgToCmd CanvasPageMsg subCmdMsgs
                | CheckBoxPageCmdMsgs subCmdMsgs -> map CheckBoxPage.mapCmdMsgToCmd CheckBoxPageMsg subCmdMsgs
                | CarouselPageCmdMsgs subCmdMsgs -> map CarouselPage.mapCmdMsgToCmd CarouselPageMsg subCmdMsgs
                | ComboBoxPageCmdMsgs subCmdMsgs -> map ComboBoxPage.mapCmdMsgToCmd ComboBoxPageMsg subCmdMsgs
                | ColorPickerPageCmdMsgs subCmdMsgs -> map ColorPickerPage.mapCmdMsgToCmd ColorPickerPageMsg subCmdMsgs
                | CompositionPageCmdMsgs subCmdMsgs -> map CompositionPage.mapCmdMsgToCmd CompositionPageMsg subCmdMsgs
                | ContextMenuPageCmdMsgs subCmdMsgs -> map ContextMenuPage.mapCmdMsgToCmd ContextMenuPageMsg subCmdMsgs
                | ContextFlyoutPageCmdMsgs subCmdMsgs -> map ContextFlyoutPage.mapCmdMsgToCmd ContextFlyoutPageMsg subCmdMsgs
                | ClipboardPageCmdMsgs subCmdMsgs -> map ClipboardPage.mapCmdMsgToCmd ClipboardPageMsg subCmdMsgs
                | CursorPageCmdMsgs subCmdMsgs -> map CursorPage.mapCmdMsgToCmd CursorPageMsg subCmdMsgs
                | DataGridPageCmdMsgs subCmdMsgs -> map DataGridPage.mapCmdMsgToCmd DataGridPageMsg subCmdMsgs
                | DockPanelPageCmdMsgs subCmdMsgs -> map DockPanelPage.mapCmdMsgToCmd DockPanelPageMsg subCmdMsgs
                | DialogsPageCmdMsgs subCmdMsgs -> map DialogsPage.mapCmdMsgToCmd DialogsPageMsg subCmdMsgs
                | DragAndDropPageCmdMsgs subCmdMsgs -> map DragAndDropPage.mapCmdMsgToCmd DragAndDropPageMsg subCmdMsgs
                | DropDownButtonPageCmdMsgs subCmdMsgs -> map DropDownButtonPage.mapCmdMsgToCmd DropDownButtonPageMsg subCmdMsgs
                | EffectsPageCmdMsgs subCmdMsgs -> map EffectsPage.mapCmdMsgToCmd EffectsPageMsg subCmdMsgs
                | ExpanderPageCmdMsgs subCmdMsgs -> map ExpanderPage.mapCmdMsgToCmd ExpanderPageMsg subCmdMsgs
                | FlyoutPageCmdMsgs subCmdMsgs -> map FlyoutPage.mapCmdMsgToCmd FlyoutPageMsg subCmdMsgs
                | GesturesPageCmdMsgs subCmdMsgs -> map GesturesPage.mapCmdMsgToCmd GesturesPageMsg subCmdMsgs
                | GeometriesPageCmdMsgs subCmdMsgs -> map GeometriesPage.mapCmdMsgToCmd GeometriesPageMsg subCmdMsgs
                | GridPageCmdMsgs subCmdMsgs -> map GridPage.mapCmdMsgToCmd GridPageMsg subCmdMsgs
                | GridSplitterPageCmdMsgs subCmdMsgs -> map GridSplitterPage.mapCmdMsgToCmd GridSplitterPageMsg subCmdMsgs
                | ImagePageCmdMsgs subCmdMsgs -> map ImagePage.mapCmdMsgToCmd ImagePageMsg subCmdMsgs
                | ItemsRepeaterPageCmdMsgs subCmdMsgs -> map ItemsRepeaterPage.mapCmdMsgToCmd ItemsRepeaterPageMsg subCmdMsgs
                | LabelPageCmdMsgs subCmdMsgs -> map LabelPage.mapCmdMsgToCmd LabelPageMsg subCmdMsgs
                | LayoutTransformControlPageCmdMsgs subCmdMsgs -> map LayoutTransformControlPage.mapCmdMsgToCmd LayoutTransformControlPageMsg subCmdMsgs
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
                | TreeViewPageCmdMsgs treeViewPageCmdMsgs -> map TreeViewPage.mapCmdMsgToCmd TreeViewPageMsg treeViewPageCmdMsgs
                | TreeDataGridPageCmdMsgs treeDataGridPageCmdMsgs -> map TreeDataGridPage.mapCmdMsgToCmd TreeDataGridPageMsg treeDataGridPageCmdMsgs
                | TransitioningContentControlPageCmdMsgs subCmdMsgs ->
                    map TransitioningContentControlPage.mapCmdMsgToCmd TransitioningContentControlPageMsg subCmdMsgs
                | TabStripPageCmdMsgs subCmdMsgs -> map TabStripPage.mapCmdMsgToCmd TabStripPageMsg subCmdMsgs
                | TextBlockPageCmdMsgs subCmdMsgs -> map TextBlockPage.mapCmdMsgToCmd TextBlockPageMsg subCmdMsgs
                | TextBoxPageCmdMsgs subCmdMsgs -> map TextBoxPage.mapCmdMsgToCmd TextBoxPageMsg subCmdMsgs
                | ToggleButtonPageCmdMsgs subCmdMsgs -> map ToggleButtonPage.mapCmdMsgToCmd ToggleButtonPageMsg subCmdMsgs
                | ToggleSwitchPageCmdMsgs subCmdMsgs -> map ToggleSwitchPage.mapCmdMsgToCmd ToggleSwitchPageMsg subCmdMsgs
                | ToolTipPageCmdMsgs subCmdMsgs -> map ToolTipPage.mapCmdMsgToCmd ToolTipPageMsg subCmdMsgs
                | TickBarPageCmdMsgs subCmdMsgs -> map TickBarPage.mapCmdMsgToCmd TickBarPageMsg subCmdMsgs
                | ThemeAwarePageCmdMsgs subCmdMsgs -> map ThemeAwarePage.mapCmdMsgToCmd ThemeAwarePageMsg subCmdMsgs
                | UniformGridPageCmdMsgs subCmdMsgs -> map UniformGridPage.mapCmdMsgToCmd UniformGridPageMsg subCmdMsgs
                | ViewBoxPageCmdMsgs subCmdMsgs -> map ViewBoxPage.mapCmdMsgToCmd ViewBoxPageMsg subCmdMsgs
                | ToggleSplitButtonPageCmdMsgs cmdMsgs -> map ToggleSplitButtonPage.mapCmdMsgToCmd ToggleSplitButtonPageMsg cmdMsgs

            cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let init () =
        let acrylicModel, acrylicCmdMsgs = AcrylicPage.init()
        let adornerModel, adornerCmdMsgs = AdornerLayerPage.init()
        let autCompleteBoxModel, autoCompleteCmdMsgs = AutoCompleteBoxPage.init()
        let buttonsModel, buttonsCmdMsgs = ButtonsPage.init()
        let buttonSpinnerModel, buttonSpinnerCmdMsgs = ButtonSpinnerPage.init()
        let borderModel, borderCmdMsgs = BorderPage.init()
        let calendarModel, calendarCmdMsgs = CalendarPage.init()

        let calendarDatePickerModel, calendarDatePickerCmdMsgs =
            CalendarDatePickerPage.init()

        let canvasModel, canvasCmdMsgs = CanvasPage.init()
        let checkBoxModel, checkBoxCmdMsgs = CheckBoxPage.init()
        let carouselModel, carouselCmdMsgs = CarouselPage.init()
        let comboBoxModel, comboBoxCmdMsgs = ComboBoxPage.init()
        let colorPickerModel, colorPickerCmdMsgs = ColorPickerPage.init()
        let compositionModel, compositionCmdMsgs = CompositionPage.init()
        let contextMenuModel, contextMenuCmdMsgs = ContextMenuPage.init()
        let contextFlyoutModel, contextFlyoutCmdMsgs = ContextFlyoutPage.init()
        let clipboardModel, clipboardCmdMsgs = ClipboardPage.init()
        let cursorModel, cursorCmdMsgs = CursorPage.init()
        let dataGridModel, dataGridCmdMsgs = DataGridPage.init()
        let dialogsModel, dialogsCmdMsgs = DialogsPage.init()
        let dragAndDropModel, dragAndDropCmdMsgs = DragAndDropPage.init()
        let dockPanelModel, dockPanelCmdMsgs = DockPanelPage.init()
        let dropDownButtonModel, dropDownButtonCmdMsgs = DropDownButtonPage.init()
        let effectsModel, effectsCmdMsgs = EffectsPage.init()
        let expanderModel, expanderCmdMsgs = ExpanderPage.init()
        let flyoutModel, flyoutCmdMsgs = FlyoutPage.init()
        let gesturesModel, gesturesCmdMsgs = GesturesPage.init()
        let geometriesModel, geometriesCmdMsgs = GeometriesPage.init()
        let gridModel, gridCmdMsgs = GridPage.init()
        let gridSplitterModel, gridSplitterCmdMsgs = GridSplitterPage.init()
        let imageModel, imageCmdMsgs = ImagePage.init()
        let itemsRepeaterModel, itemsRepeaterCmdMsgs = ItemsRepeaterPage.init()
        let labelModel, labelCmdMsgs = LabelPage.init()

        let layoutTransformControlModel, layoutTransformControlCmdMsgs =
            LayoutTransformControlPage.init()

        let listBoxModel, listBoxCmdMsgs = ListBoxPage.init()
        let menuFlyoutModel, menuFlyoutCmdMsgs = MenuFlyoutPage.init()
        let maskedTextBoxModel, maskedTextBoxCmdMsgs = MaskedTextBoxPage.init()
        let menuModel, menuCmdMsgs = MenuPage.init()
        let numericUpDownModel, numericUpDownCmdMsgs = NumericUpDownPage.init()
        let notificationsModel, notificationsCmdMsgs = NotificationsPage.init()
        let openGLModel, openGLCmdMsgs = OpenGLPage.init()
        let progressBarModel, progressBarCmdMsgs = ProgressBarPage.init()
        let panelModel, panelCmdMsgs = PanelPage.init()
        let pathIconModel, pathIconCmdMsgs = PathIconPage.init()
        let pointersModel, pointersCmdMsgs = PointersPage.init()
        let popupModel, popupCmdMsgs = PopupPage.init()
        let pageTransitionsModel, pageTransitionsCmdMsgs = PageTransitionsPage.init()
        let repeatButtonModel, repeatButtonCmdMsgs = RepeatButtonPage.init()
        let radioButtonModel, radioButtonCmdMsgs = RadioButtonPage.init()
        let refreshContainerModel, refreshContainerCmdMsgs = RefreshContainerPage.init()

        let selectableTextBlockModel, selectableTextBlockCmdMsgs =
            SelectableTextBlockPage.init()

        let splitButtonModel, splitButtonCmdMsgs = SplitButtonPage.init()
        let sliderModel, sliderCmdMsgs = SliderPage.init()
        let shapesModel, shapesCmdMsgs = ShapesPage.init()
        let scrollBarModel, scrollBarCmdMsgs = ScrollBarPage.init()
        let splitViewModel, splitViewCmdMsgs = SplitViewPage.init()
        let stackPanelModel, stackPanelCmdMsgs = StackPanelPage.init()
        let stylesModel, stylesCmdMsgs = StylesPage.init()
        let scrollViewerModel, scrollViewerCmdMsgs = ScrollViewerPage.init()
        let toggleSplitButtonModel, toggleSplitButtonCmdMsgs = ToggleSplitButtonPage.init()
        let textBlockModel, textBlockCmdMsgs = TextBlockPage.init()
        let textBoxModel, textBoxCmdMsgs = TextBoxPage.init()
        let tickBarModel, tickBarCmdMsgs = TickBarPage.init()
        let toggleSwitchModel, toggleSwitchCmdMsgs = ToggleSwitchPage.init()
        let toggleButtonModel, toggleButtonCmdMsgs = ToggleButtonPage.init()
        let toolTipModel, toolTipCmdMsgs = ToolTipPage.init()
        let tabControlModel, tabControlCmdMsgs = TabControlPage.init()
        let treeViewModel, treeViewCmdMsgs = TreeViewPage.init()
        let treeDataGridModel, treeDataGridCmdMsgs = TreeDataGridPage.init()

        let transitionControlModel, transitionControlCmdMsgs =
            TransitioningContentControlPage.init()

        let tabStripModel, tabStripCmdMsgs = TabStripPage.init()
        let themeAwareModel, themeAwareCmdMsgs = ThemeAwarePage.init()
        let uniformGridModel, uniformGridCmdMsgs = UniformGridPage.init()
        let viewBoxModel, viewBoxCmdMsgs = ViewBoxPage.init()

        { AcrylicPageModel = acrylicModel
          AdornerLayerPageModel = adornerModel
          AutoCompleteBoxPageModel = autCompleteBoxModel
          ButtonsPageModel = buttonsModel
          ButtonSpinnerPageModel = buttonSpinnerModel
          BorderPageModel = borderModel
          CalendarPageModel = calendarModel
          CalendarDatePickerPageModel = calendarDatePickerModel
          CanvasPageModel = canvasModel
          CheckBoxPageModel = checkBoxModel
          CarouselPageModel = carouselModel
          ComboBoxPageModel = comboBoxModel
          ColorPickerPageModel = colorPickerModel
          CompositionPageModel = compositionModel
          ContextMenuPageModel = contextMenuModel
          ContextFlyoutPageModel = contextFlyoutModel
          ClipboardPageModel = clipboardModel
          CursorPageModel = cursorModel
          DataGridPageModel = dataGridModel
          DialogsPageModel = dialogsModel
          DragAndDropPageModel = dragAndDropModel
          DockPanelPageModel = dockPanelModel
          DropDownButtonPageModel = dropDownButtonModel
          EffectsPageModel = effectsModel
          ExpanderPageModel = expanderModel
          FlyoutPageModel = flyoutModel
          GesturesPageModel = gesturesModel
          GeometriesPageModel = geometriesModel
          GridPageModel = gridModel
          GridSplitterPageModel = gridSplitterModel
          ImagePageModel = imageModel
          ItemsRepeaterPageModel = itemsRepeaterModel
          LabelPageModel = labelModel
          LayoutTransformControlPageModel = layoutTransformControlModel
          ListBoxPageModel = listBoxModel
          MenuFlyoutPageModel = menuFlyoutModel
          MaskedTextBoxPageModel = maskedTextBoxModel
          MenuPageModel = menuModel
          NumericUpDownPageModel = numericUpDownModel
          NotificationsPageModel = notificationsModel
          OpenGLPageModel = openGLModel
          ProgressBarPageModel = progressBarModel
          PanelPageModel = panelModel
          PathIconPageModel = pathIconModel
          PointersPageModel = pointersModel
          PopupPageModel = popupModel
          PageTransitionsPageModel = pageTransitionsModel
          RepeatButtonPageModel = repeatButtonModel
          RadioButtonPageModel = radioButtonModel
          RefreshContainerPageModel = refreshContainerModel
          SelectableTextBlockPageModel = selectableTextBlockModel
          SplitButtonPageModel = splitButtonModel
          SliderPageModel = sliderModel
          ShapesPageModel = shapesModel
          ScrollBarPageModel = scrollBarModel
          SplitViewPageModel = splitViewModel
          StackPanelPageModel = stackPanelModel
          StylesPageModel = stylesModel
          ScrollViewerPageModel = scrollViewerModel
          ToggleSplitButtonPageModel = toggleSplitButtonModel
          TextBlockPageModel = textBlockModel
          TextBoxPageModel = textBoxModel
          TickBarPageModel = tickBarModel
          ToggleSwitchPageModel = toggleSwitchModel
          ToggleButtonPageModel = toggleButtonModel
          ToolTipPageModel = toolTipModel
          TabControlPageModel = tabControlModel
          TreeViewPageModel = treeViewModel
          TreeDataGridPageModel = treeDataGridModel
          TransitioningContentControlPageModel = transitionControlModel
          TabStripPageModel = tabStripModel
          ThemeAwarePageModel = themeAwareModel
          UniformGridPageModel = uniformGridModel
          ViewBoxPageModel = viewBoxModel
          ThemeVariants = [ ThemeVariant.Default; ThemeVariant.Dark; ThemeVariant.Light ]
          FlowDirections = [ FlowDirection.LeftToRight; FlowDirection.RightToLeft ]
          TransparencyLevels =
            [ WindowTransparencyLevel.None
              WindowTransparencyLevel.AcrylicBlur
              WindowTransparencyLevel.Blur
              WindowTransparencyLevel.Mica
              WindowTransparencyLevel.Transparent ] },
        [ SubpageCmdMsgs acrylicCmdMsgs
          SubpageCmdMsgs adornerCmdMsgs
          SubpageCmdMsgs autoCompleteCmdMsgs
          SubpageCmdMsgs buttonsCmdMsgs
          SubpageCmdMsgs buttonSpinnerCmdMsgs
          SubpageCmdMsgs borderCmdMsgs
          SubpageCmdMsgs calendarCmdMsgs
          SubpageCmdMsgs calendarDatePickerCmdMsgs
          SubpageCmdMsgs [ CanvasPageCmdMsgs canvasCmdMsgs ]
          SubpageCmdMsgs checkBoxCmdMsgs
          SubpageCmdMsgs carouselCmdMsgs
          SubpageCmdMsgs comboBoxCmdMsgs
          SubpageCmdMsgs colorPickerCmdMsgs
          SubpageCmdMsgs compositionCmdMsgs
          SubpageCmdMsgs contextMenuCmdMsgs
          SubpageCmdMsgs contextFlyoutCmdMsgs
          SubpageCmdMsgs clipboardCmdMsgs
          SubpageCmdMsgs cursorCmdMsgs
          SubpageCmdMsgs dataGridCmdMsgs
          SubpageCmdMsgs [ DialogsPageCmdMsgs dialogsCmdMsgs ]
          SubpageCmdMsgs dragAndDropCmdMsgs
          SubpageCmdMsgs dockPanelCmdMsgs
          SubpageCmdMsgs dropDownButtonCmdMsgs
          SubpageCmdMsgs effectsCmdMsgs
          SubpageCmdMsgs expanderCmdMsgs
          SubpageCmdMsgs flyoutCmdMsgs
          SubpageCmdMsgs gesturesCmdMsgs
          SubpageCmdMsgs geometriesCmdMsgs
          SubpageCmdMsgs gridCmdMsgs
          SubpageCmdMsgs gridSplitterCmdMsgs
          SubpageCmdMsgs imageCmdMsgs
          SubpageCmdMsgs itemsRepeaterCmdMsgs
          SubpageCmdMsgs labelCmdMsgs
          SubpageCmdMsgs layoutTransformControlCmdMsgs
          SubpageCmdMsgs listBoxCmdMsgs
          SubpageCmdMsgs menuFlyoutCmdMsgs
          SubpageCmdMsgs maskedTextBoxCmdMsgs
          SubpageCmdMsgs menuCmdMsgs
          SubpageCmdMsgs numericUpDownCmdMsgs
          SubpageCmdMsgs notificationsCmdMsgs
          SubpageCmdMsgs openGLCmdMsgs
          SubpageCmdMsgs progressBarCmdMsgs
          SubpageCmdMsgs panelCmdMsgs
          SubpageCmdMsgs pathIconCmdMsgs
          SubpageCmdMsgs pointersCmdMsgs
          SubpageCmdMsgs popupCmdMsgs
          SubpageCmdMsgs pageTransitionsCmdMsgs
          SubpageCmdMsgs repeatButtonCmdMsgs
          SubpageCmdMsgs radioButtonCmdMsgs
          SubpageCmdMsgs refreshContainerCmdMsgs
          SubpageCmdMsgs selectableTextBlockCmdMsgs
          SubpageCmdMsgs splitButtonCmdMsgs
          SubpageCmdMsgs sliderCmdMsgs
          SubpageCmdMsgs shapesCmdMsgs
          SubpageCmdMsgs scrollBarCmdMsgs
          SubpageCmdMsgs splitViewCmdMsgs
          SubpageCmdMsgs stackPanelCmdMsgs
          SubpageCmdMsgs stylesCmdMsgs
          SubpageCmdMsgs scrollViewerCmdMsgs
          SubpageCmdMsgs toggleSplitButtonCmdMsgs
          SubpageCmdMsgs textBlockCmdMsgs
          SubpageCmdMsgs textBoxCmdMsgs
          SubpageCmdMsgs tickBarCmdMsgs
          SubpageCmdMsgs toggleSwitchCmdMsgs
          SubpageCmdMsgs toggleButtonCmdMsgs
          SubpageCmdMsgs toolTipCmdMsgs
          SubpageCmdMsgs tabControlCmdMsgs
          SubpageCmdMsgs treeViewCmdMsgs
          SubpageCmdMsgs treeDataGridCmdMsgs
          SubpageCmdMsgs transitionControlCmdMsgs
          SubpageCmdMsgs tabStripCmdMsgs
          SubpageCmdMsgs themeAwareCmdMsgs
          SubpageCmdMsgs uniformGridCmdMsgs
          SubpageCmdMsgs viewBoxCmdMsgs ]

    let update msg model =
        match msg with
        | DoNothing -> model, []
        | Settings -> model, []

        | DecorationsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = args.SelectedItem :?> ComboBoxItem
            let decoration = SystemDecorations.Parse(content.Content.ToString())
            FabApplication.Current.MainWindow.SystemDecorations <- decoration
            model, []

        | ThemeVariantsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let content = model.ThemeVariants[args.SelectedIndex]
            FabApplication.Current.RequestedThemeVariant <- content
            model, []

        | FlowDirectionsOnSelectionChanged selectionChangedEventArgs ->
            let args = selectionChangedEventArgs.Source :?> ComboBox
            let content = model.FlowDirections[args.SelectedIndex]
            FabApplication.Current.TopLevel.FlowDirection <- content
            model, []

        | TransparencyLevelsOnSelectionChanged args ->
            let args = args.Source :?> ComboBox
            let _content = model.TransparencyLevels[args.SelectedIndex]
            model, []

        | AcrylicPageMsg msg ->
            let model1, cmdMsgs = AcrylicPage.update msg model.AcrylicPageModel
            { model with AcrylicPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | AdornerLayerPageMsg msg ->
            let model1, cmdMsgs = AdornerLayerPage.update msg model.AdornerLayerPageModel

            { model with
                AdornerLayerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | AutoCompleteBoxPageMsg msg ->
            let model1, cmdMsgs = AutoCompleteBoxPage.update msg model.AutoCompleteBoxPageModel

            { model with
                AutoCompleteBoxPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ButtonsPageMsg msg ->
            let model1, cmdMsgs = ButtonsPage.update msg model.ButtonsPageModel
            { model with ButtonsPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ButtonSpinnerPageMsg msg ->
            let model1, cmdMsgs = ButtonSpinnerPage.update msg model.ButtonSpinnerPageModel

            { model with
                ButtonSpinnerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | BorderPageMsg msg ->
            let model1, cmdMsgs = BorderPage.update msg model.BorderPageModel
            { model with BorderPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | CalendarPageMsg msg ->
            let model1, cmdMsgs = CalendarPage.update msg model.CalendarPageModel

            { model with
                CalendarPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | CalendarDatePickerPageMsg msg ->
            let model1, cmdMsgs =
                CalendarDatePickerPage.update msg model.CalendarDatePickerPageModel

            { model with
                CalendarDatePickerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | CanvasPageMsg msg ->
            let model1, cmdMsgs = CanvasPage.update msg model.CanvasPageModel
            { model with CanvasPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | CheckBoxPageMsg msg ->
            let model1, cmdMsgs = CheckBoxPage.update msg model.CheckBoxPageModel

            { model with
                CheckBoxPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | CarouselPageMsg msg ->
            let model1, cmdMsgs = CarouselPage.update msg model.CarouselPageModel

            { model with
                CarouselPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ComboBoxPageMsg msg ->
            let model1, cmdMsgs = ComboBoxPage.update msg model.ComboBoxPageModel

            { model with
                ComboBoxPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]

        | ColorPickerPageMsg msg ->
            let model1, cmdMsgs = ColorPickerPage.update msg model.ColorPickerPageModel

            { model with
                ColorPickerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | CompositionPageMsg msg ->
            let model1, cmdMsgs = CompositionPage.update msg model.CompositionPageModel

            { model with
                CompositionPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ContextMenuPageMsg msg ->
            let model1, cmdMsgs = ContextMenuPage.update msg model.ContextMenuPageModel

            { model with
                ContextMenuPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ContextFlyoutPageMsg msg ->
            let model1, cmdMsgs = ContextFlyoutPage.update msg model.ContextFlyoutPageModel

            { model with
                ContextFlyoutPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ClipboardPageMsg msg ->
            let model1, cmdMsgs = ClipboardPage.update msg model.ClipboardPageModel

            { model with
                ClipboardPageModel = model1 },
            [ SubpageCmdMsgs [ (ClipboardPageCmdMsgs cmdMsgs) ] ]

        | CursorPageMsg msg ->
            let model1, cmdMsgs = CursorPage.update msg model.CursorPageModel

            { model with CursorPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]

        | DataGridPageMsg msg ->
            let model1, cmdMsgs = DataGridPage.update msg model.DataGridPageModel

            { model with
                DataGridPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | DockPanelPageMsg msg ->
            let model1, cmdMsgs = DockPanelPage.update msg model.DockPanelPageModel

            { model with
                DockPanelPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | DialogsPageMsg msg ->
            let model1, cmdMsgs = DialogsPage.update msg model.DialogsPageModel
            { model with DialogsPageModel = model1 }, [ SubpageCmdMsgs [ DialogsPageCmdMsgs cmdMsgs ] ]
        | DragAndDropPageMsg msg ->
            let model1, cmdMsgs = DragAndDropPage.update msg model.DragAndDropPageModel

            { model with
                DragAndDropPageModel = model1 },
            [ SubpageCmdMsgs [ DragAndDropPageCmdMsgs cmdMsgs ] ]
        | DropDownButtonPageMsg msg ->
            let model1, cmdMsgs = DropDownButtonPage.update msg model.DropDownButtonPageModel

            { model with
                DropDownButtonPageModel = model1 },
            [ SubpageCmdMsgs [ DropDownButtonPageCmdMsgs cmdMsgs ] ]
        | EffectsPageMsg msg ->
            let model1, cmdMsgs = EffectsPage.update msg model.EffectsPageModel
            { model with EffectsPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ExpanderPageMsg msg ->
            let model1, cmdMsgs = ExpanderPage.update msg model.ExpanderPageModel

            { model with
                ExpanderPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | FlyoutPageMsg msg ->
            let model1, cmdMsgs = FlyoutPage.update msg model.FlyoutPageModel
            { model with FlyoutPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | GesturesPageMsg msg ->
            let model1, cmdMsgs = GesturesPage.update msg model.GesturesPageModel

            { model with
                GesturesPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | GeometriesPageMsg msg ->
            let model1, cmdMsgs = GeometriesPage.update msg model.GeometriesPageModel

            { model with
                GeometriesPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | GridPageMsg msg ->
            let model1, cmdMsgs = GridPage.update msg model.GridPageModel
            { model with GridPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | GridSplitterPageMsg msg ->
            let model1, cmdMsgs = GridSplitterPage.update msg model.GridSplitterPageModel

            { model with
                GridSplitterPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ImagePageMsg msg ->
            let model1, cmdMsgs = ImagePage.update msg model.ImagePageModel
            { model with ImagePageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]

        | ItemsRepeaterPageMsg msg ->
            let model1, cmdMsgs = ItemsRepeaterPage.update msg model.ItemsRepeaterPageModel

            { model with
                ItemsRepeaterPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | LabelPageMsg msg ->
            let model1, cmdMsgs = LabelPage.update msg model.LabelPageModel
            { model with LabelPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | LayoutTransformControlPageMsg msg ->
            let model1, cmdMsgs =
                LayoutTransformControlPage.update msg model.LayoutTransformControlPageModel

            { model with
                LayoutTransformControlPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ListBoxPageMsg msg ->
            let model1, cmdMsgs = ListBoxPage.update msg model.ListBoxPageModel
            { model with ListBoxPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | MenuFlyoutPageMsg msg ->
            let model1, cmdMsgs = MenuFlyoutPage.update msg model.MenuFlyoutPageModel

            { model with
                MenuFlyoutPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | MaskedTextBoxPageMsg msg ->
            let model1, cmdMsgs = MaskedTextBoxPage.update msg model.MaskedTextBoxPageModel

            { model with
                MaskedTextBoxPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | MenuPageMsg msg ->
            let model1, cmdMsgs = MenuPage.update msg model.MenuPageModel
            { model with MenuPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | NumericUpDownPageMsg msg ->
            let model1, cmdMsgs = NumericUpDownPage.update msg model.NumericUpDownPageModel

            { model with
                NumericUpDownPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | NotificationsPageMsg msg ->
            let model1, cmdMsgs = NotificationsPage.update msg model.NotificationsPageModel

            { model with
                NotificationsPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | OpenGLPageMsg msg ->
            let model1, cmdMsgs = OpenGLPage.update msg model.OpenGLPageModel
            { model with OpenGLPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ProgressBarPageMsg msg ->
            let model1, cmdMsgs = ProgressBarPage.update msg model.ProgressBarPageModel

            { model with
                ProgressBarPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | PanelPageMsg msg ->
            let model1, cmdMsgs = PanelPage.update msg model.PanelPageModel
            { model with PanelPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | PathIconPageMsg msg ->
            let model1, cmdMsgs = PathIconPage.update msg model.PathIconPageModel

            { model with
                PathIconPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | PopupPageMsg msg ->
            let model1, cmdMsgs = PopupPage.update msg model.PopupPageModel
            { model with PopupPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | PointersPageMsg msg ->
            let model1, cmdMsgs = PointersPage.update msg model.PointersPageModel

            { model with
                PointersPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | PageTransitionsPageMsg msg ->
            let model1, cmdMsgs = PageTransitionsPage.update msg model.PageTransitionsPageModel

            { model with
                PageTransitionsPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | RepeatButtonPageMsg msg ->
            let model1, cmdMsgs = RepeatButtonPage.update msg model.RepeatButtonPageModel

            { model with
                RepeatButtonPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | RadioButtonPageMsg msg ->
            let model1, cmdMsgs = RadioButtonPage.update msg model.RadioButtonPageModel

            { model with
                RadioButtonPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | RefreshContainerPageMsg msg ->
            let model1, cmdMsgs =
                RefreshContainerPage.update msg model.RefreshContainerPageModel

            { model with
                RefreshContainerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | SelectableTextBlockPageMsg msg ->
            let model1, cmdMsgs =
                SelectableTextBlockPage.update msg model.SelectableTextBlockPageModel

            { model with
                SelectableTextBlockPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | SplitButtonPageMsg msg ->
            let model1, cmdMsgs = SplitButtonPage.update msg model.SplitButtonPageModel

            { model with
                SplitButtonPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | SliderPageMsg msg ->
            let model1, cmdMsgs = SliderPage.update msg model.SliderPageModel
            { model with SliderPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ShapesPageMsg msg ->
            let model1, cmdMsgs = ShapesPage.update msg model.ShapesPageModel
            { model with ShapesPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ScrollBarPageMsg msg ->
            let model1, cmdMsgs = ScrollBarPage.update msg model.ScrollBarPageModel

            { model with
                ScrollBarPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | SplitViewPageMsg msg ->
            let model1, cmdMsgs = SplitViewPage.update msg model.SplitViewPageModel

            { model with
                SplitViewPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | StackPanelPageMsg msg ->
            let model1, cmdMsgs = StackPanelPage.update msg model.StackPanelPageModel

            { model with
                StackPanelPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | StylesPageMsg msg ->
            let model1, cmdMsgs = StylesPage.update msg model.StylesPageModel
            { model with StylesPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ScrollViewerPageMsg msg ->
            let model1, cmdMsgs = ScrollViewerPage.update msg model.ScrollViewerPageModel

            { model with
                ScrollViewerPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ToggleSplitButtonPageMsg msg ->
            let model1, cmdMsgs =
                ToggleSplitButtonPage.update msg model.ToggleSplitButtonPageModel

            { model with
                ToggleSplitButtonPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | TextBlockPageMsg msg ->
            let model1, cmdMsgs = TextBlockPage.update msg model.TextBlockPageModel

            { model with
                TextBlockPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | TextBoxPageMsg msg ->
            let model1, cmdMsgs = TextBoxPage.update msg model.TextBoxPageModel
            { model with TextBoxPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | TickBarPageMsg msg ->
            let model1, cmdMsgs = TickBarPage.update msg model.TickBarPageModel
            { model with TickBarPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | ToggleSwitchPageMsg msg ->
            let model1, cmdMsgs = ToggleSwitchPage.update msg model.ToggleSwitchPageModel

            { model with
                ToggleSwitchPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ToggleButtonPageMsg msg ->
            let model1, cmdMsgs = ToggleButtonPage.update msg model.ToggleButtonPageModel

            { model with
                ToggleButtonPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ToolTipPageMsg msg ->
            let model1, cmdMsgs = ToolTipPage.update msg model.ToolTipPageModel
            { model with ToolTipPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
        | TabControlPageMsg msg ->
            let model1, cmdMsgs = TabControlPage.update msg model.TabControlPageModel

            { model with
                TabControlPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]

        | TreeViewPageMsg msg ->
            let model1, cmdMsgs = TreeViewPage.update msg model.TreeViewPageModel

            { model with
                TreeViewPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]

        | TreeDataGridPageMsg msg ->
            let model1, cmdMsgs = TreeDataGridPage.update msg model.TreeDataGridPageModel

            { model with
                TreeDataGridPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]

        | TransitioningContentControlPageMsg msg ->
            let model1, cmdMsgs =
                TransitioningContentControlPage.update msg model.TransitioningContentControlPageModel

            { model with
                TransitioningContentControlPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | TabStripPageMsg msg ->
            let model1, cmdMsgs = TabStripPage.update msg model.TabStripPageModel

            { model with
                TabStripPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ThemeAwarePageMsg msg ->
            let model1, cmdMsgs = ThemeAwarePage.update msg model.ThemeAwarePageModel

            { model with
                ThemeAwarePageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | UniformGridPageMsg msg ->
            let model1, cmdMsgs = UniformGridPage.update msg model.UniformGridPageModel

            { model with
                UniformGridPageModel = model1 },
            [ SubpageCmdMsgs cmdMsgs ]
        | ViewBoxPageMsg msg ->
            let model1, cmdMsgs = ViewBoxPage.update msg model.ViewBoxPageModel
            { model with ViewBoxPageModel = model1 }, [ SubpageCmdMsgs cmdMsgs ]
