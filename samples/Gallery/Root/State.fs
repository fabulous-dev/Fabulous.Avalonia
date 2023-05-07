namespace Gallery.Root

open Fabulous

open Gallery.Pages.Types
open Gallery
open Types

module State =

    let pages =
        [| Pages.AcrylicPage
           Pages.AdornerLayerPage
           Pages.AutoCompleteBoxPage
           Pages.AnimationsPage
           Pages.ButtonsPage
           Pages.BrushesPage
           Pages.ButtonSpinnerPage
           Pages.BorderPage
           Pages.CalendarPage
           Pages.CalendarDatePickerPage
           Pages.CanvasPage
           Pages.CheckBoxPage
           Pages.CarouselPage
           Pages.ComboBoxPage
           Pages.ContextMenuPage
           Pages.ContextFlyoutPage
           Pages.ClippingPage
           Pages.DockPanelPage
           Pages.DropDownButtonPage
           Pages.DrawingPage
           Pages.ExpanderPage
           Pages.FlyoutPage
           Pages.GesturesPage
           Pages.GeometriesPage
           Pages.GlyphRunControlPage
           Pages.GridPage
           Pages.GridSplitterPage
           Pages.ImagePage
           Pages.LabelPage
           Pages.LayoutTransformControlPage
           Pages.LineBoundsDemoControlPage
           Pages.ListBoxPage
           Pages.MenuFlyoutPage
           Pages.MaskedTextBoxPage
           Pages.MenuPage
           Pages.NumericUpDownPage
           Pages.NotificationsPage
           Pages.ProgressBarPage
           Pages.PanelPage
           Pages.PathIconPage
           Pages.PopupPage
           Pages.PageTransitionsPage
           Pages.RepeatButtonPage
           Pages.RadioButtonPage
           Pages.RefreshContainerPage
           Pages.SelectableTextBlockPage
           Pages.SplitButtonPage
           Pages.SliderPage
           Pages.ShapesPage
           Pages.ScrollBarPage
           Pages.SplitViewPage
           Pages.StackPanelPage
           Pages.ScrollViewerPage
           Pages.ToggleSplitButtonPage
           Pages.TextBlockPage
           Pages.TextBoxPage
           Pages.TickBarPage
           Pages.ToggleSwitchPage
           Pages.ToggleButtonPage
           Pages.ToolTipPage
           Pages.TabControlPage
           Pages.TabStripPage
           Pages.TransitionsPage
           Pages.TransformsPage
           Pages.ThemeAwarePage
           Pages.UniformGridPage
           Pages.ViewBoxPage |]

    let init () =

        { PageModel = Pages.State.init(Pages.AcrylicPage)
          IsPanOpen = true
          Pages = pages |> Array.map Pages.Translate
          SafeAreaInsets = 0.
          PaneLength = 250.
          SelectedIndex = 0 },
        Cmd.none

    let update msg model =
        match msg with
        | OnLoaded _ ->
#if MOBILE
            { model with
                SafeAreaInsets = 32.
                PaneLength = 180. },
            Cmd.none
#else
            model, Cmd.none
#endif
        | DoNothing -> model, Cmd.none
        | PageMsg msg ->
            let m, c = Pages.State.update msg model.PageModel
            { model with PageModel = m }, Cmd.batch [ (Cmd.map PageMsg c) ]
        | SelectedIndexChanged index ->
            let index = if index < 0 then model.SelectedIndex else index

            let model =
                { model with
                    SelectedIndex = index
                    PageModel = Pages.State.init(pages.[index]) }

            model, Cmd.none

        | OpenPanChanged x -> { model with IsPanOpen = x }, Cmd.none

        | OpenPan ->
            { model with
                IsPanOpen = not model.IsPanOpen },
            Cmd.none
