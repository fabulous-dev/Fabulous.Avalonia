namespace Gallery.Root

open Gallery
open Gallery.Pages
open Fabulous
open Fabulous.Avalonia

type SubpageModel =
    | AcrylicPageModel of AcrylicPage.Model
    | AdornerLayerPageModel of AdornerLayerPage.Model
    | AutoCompleteBoxPageModel of AutoCompleteBoxPage.Model
    | AnimationsPageModel of AnimationsPage.Model
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
    | ContextMenuPageModel of ContextMenuPage.Model
    | ContextFlyoutPageModel of ContextFlyoutPage.Model
    | ClippingPageModel of ClippingPage.Model
    | DockPanelPageModel of DockPanelPage.Model
    | DropDownButtonPageModel of DropDownButtonPage.Model
    | DrawingPageModel of DrawingPage.Model
    | ExpanderPageModel of ExpanderPage.Model
    | FlyoutPageModel of FlyoutPage.Model
    | GesturesPageModel of GesturesPage.Model
    | GeometriesPageModel of GeometriesPage.Model
    | GlyphRunControlPageModel of GlyphRunControlPage.Model
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
    | ProgressBarPageModel of ProgressBarPage.Model
    | PanelPageModel of PanelPage.Model
    | PathIconPageModel of PathIconPage.Model
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
    | TransitionsPageModel of TransitionsPage.Model
    | TransformsPageModel of TransformsPage.Model
    | ThemeAwarePageModel of ThemeAwarePage.Model
    | UniformGridPageModel of UniformGridPage.Model
    | ViewBoxPageModel of ViewBoxPage.Model

type SubpageMsg =
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
    | GesturesPageMsg of GesturesPage.Msg
    | GeometriesPageMsg of GeometriesPage.Msg
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
    | NotificationsPageMsg of NotificationsPage.Msg
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

type SubpageCmdMsg =
    | AcrylicPageCmdMsgs of AcrylicPage.CmdMsg list
    | AdornerLayerPageCmdMsgs of AdornerLayerPage.CmdMsg list
    | AutoCompleteBoxPageCmdMsgs of AutoCompleteBoxPage.CmdMsg list
    | AnimationsPageCmdMsgs of AnimationsPage.CmdMsg list
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
    | ContextMenuPageCmdMsgs of ContextMenuPage.CmdMsg list
    | ContextFlyoutPageCmdMsgs of ContextFlyoutPage.CmdMsg list
    | ClippingPageCmdMsgs of ClippingPage.CmdMsg list
    | DockPanelPageCmdMsgs of DockPanelPage.CmdMsg list
    | DropDownButtonPageCmdMsgs of DropDownButtonPage.CmdMsg list
    | DrawingPageCmdMsgs of DrawingPage.CmdMsg list
    | ExpanderPageCmdMsgs of ExpanderPage.CmdMsg list
    | FlyoutPageCmdMsgs of FlyoutPage.CmdMsg list
    | GesturesPageCmdMsgs of GesturesPage.CmdMsg list
    | GeometriesPageCmdMsgs of GeometriesPage.CmdMsg list
    | GlyphRunControlPageCmdMsgs of GlyphRunControlPage.CmdMsg list
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
    | ProgressBarPageCmdMsgs of ProgressBarPage.CmdMsg list
    | PanelPageCmdMsgs of PanelPage.CmdMsg list
    | PathIconPageCmdMsgs of PathIconPage.CmdMsg list
    | PopupPageCmdMsgs of PopupPage.CmdMsg list
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
    | TransitionsPageCmdMsgs of TransitionsPage.CmdMsg list
    | TransformsPageCmdMsgs of TransformsPage.CmdMsg list
    | ThemeAwarePageCmdMsgs of ThemeAwarePage.CmdMsg list
    | UniformGridPageCmdMsgs of UniformGridPage.CmdMsg list
    | ViewBoxPageCmdMsgs of ViewBoxPage.CmdMsg list

type NavigationModel =
    { BackStack: SubpageModel list
      CurrentPage: SubpageModel
      ForwardStack: SubpageModel list }

    static member Init(root: SubpageModel) =
        { BackStack = []
          CurrentPage = root
          ForwardStack = [] }

    member this.Push(page: SubpageModel) =
        { BackStack = this.CurrentPage :: this.BackStack
          CurrentPage = page
          ForwardStack = [] }

    member this.PushToRoot(page: SubpageModel) =
        { BackStack = []
          CurrentPage = page
          ForwardStack = [] }

    member this.Pop() =
        match this.BackStack with
        | [] -> this
        | previous :: rest ->
            { BackStack = rest
              CurrentPage = previous
              ForwardStack = [] }

    member this.Forward() =
        match this.ForwardStack with
        | [] -> this
        | next :: rest ->
            { BackStack = this.CurrentPage :: this.BackStack
              CurrentPage = next
              ForwardStack = rest }

    member this.Backward() =
        match this.BackStack with
        | [] -> this
        | previous :: rest ->
            { BackStack = rest
              CurrentPage = previous
              ForwardStack = this.CurrentPage :: this.ForwardStack }

module NavigationState =
    let mapCmdMsgToMsg nav cmdMsgs =
        let mapSubpageCmdMsg (cmdMsg: SubpageCmdMsg) =
            let map (mapCmdMsgFn: NavigationController -> 'subCmdMsg -> Cmd<'subMsg>) (mapFn: 'subMsg -> 'msg) (subCmdMsgs: 'subCmdMsg list) =
                subCmdMsgs
                |> List.map(fun c ->
                    let cmd = mapCmdMsgFn nav c
                    Cmd.map mapFn cmd)

            match cmdMsg with
            | AcrylicPageCmdMsgs subCmdMsgs -> map AcrylicPage.mapCmdMsgToCmd AcrylicPageMsg subCmdMsgs
            | AdornerLayerPageCmdMsgs subCmdMsgs -> map AdornerLayerPage.mapCmdMsgToCmd AdornerLayerPageMsg subCmdMsgs
            | AutoCompleteBoxPageCmdMsgs subCmdMsgs -> map AutoCompleteBoxPage.mapCmdMsgToCmd AutoCompleteBoxPageMsg subCmdMsgs
            | AnimationsPageCmdMsgs subCmdMsgs -> map AnimationsPage.mapCmdMsgToCmd AnimationsPageMsg subCmdMsgs
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
            | ContextMenuPageCmdMsgs subCmdMsgs -> map ContextMenuPage.mapCmdMsgToCmd ContextMenuPageMsg subCmdMsgs
            | ContextFlyoutPageCmdMsgs subCmdMsgs -> map ContextFlyoutPage.mapCmdMsgToCmd ContextFlyoutPageMsg subCmdMsgs
            | ClippingPageCmdMsgs subCmdMsgs -> map ClippingPage.mapCmdMsgToCmd ClippingPageMsg subCmdMsgs
            | DockPanelPageCmdMsgs subCmdMsgs -> map DockPanelPage.mapCmdMsgToCmd DockPanelPageMsg subCmdMsgs
            | DropDownButtonPageCmdMsgs subCmdMsgs -> map DropDownButtonPage.mapCmdMsgToCmd DropDownButtonPageMsg subCmdMsgs
            | DrawingPageCmdMsgs subCmdMsgs -> map DrawingPage.mapCmdMsgToCmd DrawingPageMsg subCmdMsgs
            | ExpanderPageCmdMsgs subCmdMsgs -> map ExpanderPage.mapCmdMsgToCmd ExpanderPageMsg subCmdMsgs
            | FlyoutPageCmdMsgs subCmdMsgs -> map FlyoutPage.mapCmdMsgToCmd FlyoutPageMsg subCmdMsgs
            | GesturesPageCmdMsgs subCmdMsgs -> map GesturesPage.mapCmdMsgToCmd GesturesPageMsg subCmdMsgs
            | GeometriesPageCmdMsgs subCmdMsgs -> map GeometriesPage.mapCmdMsgToCmd GeometriesPageMsg subCmdMsgs
            | GlyphRunControlPageCmdMsgs subCmdMsgs -> map GlyphRunControlPage.mapCmdMsgToCmd GlyphRunControlPageMsg subCmdMsgs
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
            | ProgressBarPageCmdMsgs subCmdMsgs -> map ProgressBarPage.mapCmdMsgToCmd ProgressBarPageMsg subCmdMsgs
            | PanelPageCmdMsgs subCmdMsgs -> map PanelPage.mapCmdMsgToCmd PanelPageMsg subCmdMsgs
            | PathIconPageCmdMsgs subCmdMsgs -> map PathIconPage.mapCmdMsgToCmd PathIconPageMsg subCmdMsgs
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
            | TransitionsPageCmdMsgs cmdMsgs -> map TransitionsPage.mapCmdMsgToCmd TransitionsPageMsg cmdMsgs

        cmdMsgs |> List.map mapSubpageCmdMsg |> List.collect id |> Cmd.batch

    let initRoute (route: NavigationRoute) (_navigationModel: NavigationModel option) =
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
        | NavigationRoute.AnimationsPage ->
            let m, c = AnimationsPage.init()
            AnimationsPageModel m, [ AnimationsPageCmdMsgs c ]
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
        | NavigationRoute.ContextMenuPage ->
            let m, c = ContextMenuPage.init()
            ContextMenuPageModel m, [ ContextMenuPageCmdMsgs c ]
        | NavigationRoute.ContextFlyoutPage ->
            let m, c = ContextFlyoutPage.init()
            ContextFlyoutPageModel m, [ ContextFlyoutPageCmdMsgs c ]
        | NavigationRoute.ClippingPage ->
            let m, c = ClippingPage.init()
            ClippingPageModel m, [ ClippingPageCmdMsgs c ]
        | NavigationRoute.DockPanelPage ->
            let m, c = DockPanelPage.init()
            DockPanelPageModel m, [ DockPanelPageCmdMsgs c ]
        | NavigationRoute.DropDownButtonPage ->
            let m, c = DropDownButtonPage.init()
            DropDownButtonPageModel m, [ DropDownButtonPageCmdMsgs c ]
        | NavigationRoute.DrawingPage ->
            let m, c = DrawingPage.init()
            DrawingPageModel m, [ DrawingPageCmdMsgs c ]
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
        | NavigationRoute.GlyphRunControlPage ->
            let m, c = GlyphRunControlPage.init()
            GlyphRunControlPageModel m, [ GlyphRunControlPageCmdMsgs c ]
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
        | NavigationRoute.ProgressBarPage ->
            let m, c = ProgressBarPage.init()
            ProgressBarPageModel m, [ ProgressBarPageCmdMsgs c ]
        | NavigationRoute.PanelPage ->
            let m, c = PanelPage.init()
            PanelPageModel m, [ PanelPageCmdMsgs c ]
        | NavigationRoute.PathIconPage ->
            let m, c = PathIconPage.init()
            PathIconPageModel m, [ PathIconPageCmdMsgs c ]
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
        | NavigationRoute.ScrollViewerPage ->
            let m, c = ScrollViewerPage.init()
            ScrollViewerPageModel m, [ ScrollViewerPageCmdMsgs c ]
        | NavigationRoute.ToggleSplitButton ->
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
        | NavigationRoute.TransitionsPage ->
            let m, c = TransitionsPage.init()
            TransitionsPageModel m, [ TransitionsPageCmdMsgs c ]
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

    let update (msg: SubpageMsg) (model: NavigationModel) =
        let subpageModel, cmdMsgs =
            match msg, model.CurrentPage with
            | AcrylicPageMsg subMsg, AcrylicPageModel m ->
                let m, c = AcrylicPage.update subMsg m
                AcrylicPageModel m, [ AcrylicPageCmdMsgs c ]

            | AdornerLayerPageMsg subMsg, AdornerLayerPageModel m ->
                let m, c = AdornerLayerPage.update subMsg m
                AdornerLayerPageModel m, [ AdornerLayerPageCmdMsgs c ]
            | _, currentPage -> currentPage, []

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
        | AutoCompleteBoxPageModel model -> map AutoCompleteBoxPage.view AutoCompleteBoxPageMsg model
        | AnimationsPageModel model -> map AnimationsPage.view AnimationsPageMsg model
        | ButtonsPageModel model -> map ButtonsPage.view ButtonsPageMsg model
        | BrushesPageModel model -> map BrushesPage.view BrushesPageMsg model
        | ButtonSpinnerPageModel model -> map ButtonSpinnerPage.view ButtonSpinnerPageMsg model
        | BorderPageModel model -> map BorderPage.view BorderPageMsg model
        | CalendarPageModel model -> map CalendarPage.view CalendarPageMsg model
        | CalendarDatePickerPageModel model -> map CalendarDatePickerPage.view CalendarDatePickerPageMsg model
        | CanvasPageModel model -> map CanvasPage.view CanvasPageMsg model
        | CheckBoxPageModel model -> map CheckBoxPage.view CheckBoxPageMsg model
        | CarouselPageModel model -> map CarouselPage.view CarouselPageMsg model
        | ComboBoxPageModel model -> map ComboBoxPage.view ComboBoxPageMsg model
        | ContextMenuPageModel model -> map ContextMenuPage.view ContextMenuPageMsg model
        | ContextFlyoutPageModel model -> map ContextFlyoutPage.view ContextFlyoutPageMsg model
        | ClippingPageModel model -> map ClippingPage.view ClippingPageMsg model
        | DockPanelPageModel model -> map DockPanelPage.view DockPanelPageMsg model
        | DropDownButtonPageModel model -> map DropDownButtonPage.view DropDownButtonPageMsg model
        | DrawingPageModel model -> map DrawingPage.view DrawingPageMsg model
        | ExpanderPageModel model -> map ExpanderPage.view ExpanderPageMsg model
        | FlyoutPageModel model -> map FlyoutPage.view FlyoutPageMsg model
        | GesturesPageModel model -> map GesturesPage.view GesturesPageMsg model
        | GeometriesPageModel model -> map GeometriesPage.view GeometriesPageMsg model
        | GlyphRunControlPageModel model -> map GlyphRunControlPage.view GlyphRunControlPageMsg model
        | GridPageModel model -> map GridPage.view GridPageMsg model
        | GridSplitterPageModel model -> map GridSplitterPage.view GridSplitterPageMsg model
        | ImagePageModel model -> map ImagePage.view ImagePageMsg model
        | LabelPageModel model -> map LabelPage.view LabelPageMsg model
        | LayoutTransformControlPageModel model -> map LayoutTransformControlPage.view LayoutTransformControlPageMsg model
        | LineBoundsDemoControlPageModel model -> map LineBoundsDemoControlPage.view LineBoundsDemoControlPageMsg model
        | ListBoxPageModel model -> map ListBoxPage.view ListBoxPageMsg model
        | MenuFlyoutPageModel model -> map MenuFlyoutPage.view MenuFlyoutPageMsg model
        | MaskedTextBoxPageModel model -> map MaskedTextBoxPage.view MaskedTextBoxPageMsg model
        | MenuPageModel model -> map MenuPage.view MenuPageMsg model
        | NumericUpDownPageModel model -> map NumericUpDownPage.view NumericUpDownPageMsg model
        | NotificationsPageModel model -> map NotificationsPage.view NotificationsPageMsg model
        | ProgressBarPageModel model -> map ProgressBarPage.view ProgressBarPageMsg model
        | PanelPageModel model -> map PanelPage.view PanelPageMsg model
        | PathIconPageModel model -> map PathIconPage.view PathIconPageMsg model
        | PopupPageModel model -> map PopupPage.view PopupPageMsg model
        | PageTransitionsPageModel model -> map PageTransitionsPage.view PageTransitionsPageMsg model
        | RepeatButtonPageModel model -> map RepeatButtonPage.view RepeatButtonPageMsg model
        | RadioButtonPageModel model -> map RadioButtonPage.view RadioButtonPageMsg model
        | RefreshContainerPageModel model -> map RefreshContainerPage.view RefreshContainerPageMsg model
        | SelectableTextBlockPageModel model -> map SelectableTextBlockPage.view SelectableTextBlockPageMsg model
        | SplitButtonPageModel model -> map SplitButtonPage.view SplitButtonPageMsg model
        | SliderPageModel model -> map SliderPage.view SliderPageMsg model
        | ShapesPageModel model -> map ShapesPage.view ShapesPageMsg model
        | ScrollBarPageModel model -> map ScrollBarPage.view ScrollBarPageMsg model
        | SplitViewPageModel model -> map SplitViewPage.view SplitViewPageMsg model
        | StackPanelPageModel model -> map StackPanelPage.view StackPanelPageMsg model
        | ScrollViewerPageModel model -> map ScrollViewerPage.view ScrollViewerPageMsg model
        | ToggleSplitButtonPageModel model -> map ToggleSplitButtonPage.view ToggleSplitButtonPageMsg model
        | TextBlockPageModel model -> map TextBlockPage.view TextBlockPageMsg model
        | TextBoxPageModel model -> map TextBoxPage.view TextBoxPageMsg model
        | TickBarPageModel model -> map TickBarPage.view TickBarPageMsg model
        | ToggleSwitchPageModel model -> map ToggleSwitchPage.view ToggleSwitchPageMsg model
        | ToggleButtonPageModel model -> map ToggleButtonPage.view ToggleButtonPageMsg model
        | ToolTipPageModel model -> map ToolTipPage.view ToolTipPageMsg model
        | TabControlPageModel model -> map TabControlPage.view TabControlPageMsg model
        | TabStripPageModel model -> map TabStripPage.view TabStripPageMsg model
        | TransitionsPageModel model -> map TransitionsPage.view TransitionsPageMsg model
        | TransformsPageModel model -> map TransformsPage.view TransformsPageMsg model
        | ThemeAwarePageModel model -> map ThemeAwarePage.view ThemeAwarePageMsg model
        | UniformGridPageModel model -> map UniformGridPage.view UniformGridPageMsg model
        | ViewBoxPageModel model -> map ViewBoxPage.view ViewBoxPageMsg model

    let updateBackButtonPressed (model: NavigationModel) =
        match model.CurrentPage with
        | AcrylicPageModel _ -> update (AcrylicPageMsg AcrylicPage.Msg.Previous) model
        | AdornerLayerPageModel _ -> update (AdornerLayerPageMsg AdornerLayerPage.Msg.Previous) model
        | _ -> model, []
