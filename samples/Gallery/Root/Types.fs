namespace Gallery.Root

open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia
open System
open Avalonia.Media
open Avalonia.Styling
open Gallery.Pages

module Types =
    type Model =
        { AcrylicPageModel: AcrylicPage.Model
          AdornerLayerPageModel : AdornerLayerPage.Model
          AutoCompleteBoxPageModel : AutoCompleteBoxPage.Model
          AnimationsPageModel : AnimationsPage.Model
          ImplicitCanvasAnimationsPageModel : ImplicitCanvasAnimationsPage.Model
          CompositorAnimationsPageModel : CompositorAnimationsPage.Model
          ButtonsPageModel : ButtonsPage.Model
          BrushesPageModel : BrushesPage.Model
          ButtonSpinnerPageModel : ButtonSpinnerPage.Model
          BorderPageModel : BorderPage.Model
          CalendarPageModel : CalendarPage.Model
          CalendarDatePickerPageModel : CalendarDatePickerPage.Model
          CanvasPageModel : CanvasPage.Model
          CheckBoxPageModel : CheckBoxPage.Model
          CarouselPageModel : CarouselPage.Model
          ComboBoxPageModel : ComboBoxPage.Model
          CompositionPageModel : CompositionPage.Model
          ContextMenuPageModel : ContextMenuPage.Model
          ContextFlyoutPageModel : ContextFlyoutPage.Model
          ClippingPageModel : ClippingPage.Model
          ClipboardPageModel : ClipboardPage.Model
          DialogsPageModel : DialogsPage.Model
          DragAndDropPageModel : DragAndDropPage.Model
          DockPanelPageModel : DockPanelPage.Model
          DropDownButtonPageModel : DropDownButtonPage.Model
          DrawingPageModel : DrawingPage.Model
          DrawLineAnimationPageModel : DrawLineAnimationPage.Model
          EffectsPageModel : EffectsPage.Model
          ExpanderPageModel : ExpanderPage.Model
          FlyoutPageModel : FlyoutPage.Model
          GesturesPageModel : GesturesPage.Model
          GeometriesPageModel : GeometriesPage.Model
          GridPageModel : GridPage.Model
          GridSplitterPageModel : GridSplitterPage.Model
          ImagePageModel : ImagePage.Model
          LabelPageModel : LabelPage.Model
          LayoutTransformControlPageModel : LayoutTransformControlPage.Model
          LineBoundsDemoControlPageModel : LineBoundsDemoControlPage.Model
          ListBoxPageModel : ListBoxPage.Model
          MenuFlyoutPageModel : MenuFlyoutPage.Model
          MaskedTextBoxPageModel : MaskedTextBoxPage.Model
          MenuPageModel : MenuPage.Model
          NumericUpDownPageModel : NumericUpDownPage.Model
          NotificationsPageModel : NotificationsPage.Model
          OpenGLPageModel : OpenGLPage.Model
          ProgressBarPageModel : ProgressBarPage.Model
          PanelPageModel : PanelPage.Model
          PathIconPageModel : PathIconPage.Model
          PointersPageModel : PointersPage.Model
          PopupPageModel : PopupPage.Model
          PageTransitionsPageModel : PageTransitionsPage.Model
          RepeatButtonPageModel : RepeatButtonPage.Model
          RadioButtonPageModel : RadioButtonPage.Model
          RefreshContainerPageModel : RefreshContainerPage.Model
          SelectableTextBlockPageModel : SelectableTextBlockPage.Model
          SplitButtonPageModel : SplitButtonPage.Model
          SliderPageModel : SliderPage.Model
          ShapesPageModel : ShapesPage.Model
          ScrollBarPageModel : ScrollBarPage.Model
          SplitViewPageModel : SplitViewPage.Model
          StackPanelPageModel : StackPanelPage.Model
          StylesPageModel : StylesPage.Model
          ScrollViewerPageModel : ScrollViewerPage.Model
          ToggleSplitButtonPageModel : ToggleSplitButtonPage.Model
          TextBlockPageModel : TextBlockPage.Model
          TextBoxPageModel : TextBoxPage.Model
          TickBarPageModel : TickBarPage.Model
          ToggleSwitchPageModel : ToggleSwitchPage.Model
          ToggleButtonPageModel : ToggleButtonPage.Model
          ToolTipPageModel : ToolTipPage.Model
          TabControlPageModel : TabControlPage.Model
          TabStripPageModel : TabStripPage.Model
          TransitionsPageModel : TransitionsPage.Model
          TransformsPageModel : TransformsPage.Model
          ThemeAwarePageModel : ThemeAwarePage.Model
          UniformGridPageModel : UniformGridPage.Model
          ViewBoxPageModel : ViewBoxPage.Model
          ThemeVariants: ThemeVariant list
          FlowDirections: FlowDirection list
          TransparencyLevels: WindowTransparencyLevel list }

    type Msg =
        | SubpageMsg of SubpageMsg
        | AcrylicPageMsg of AcrylicPage.Msg
        | AdornerLayerPageMsg of AdornerLayerPage.Msg
        | AutoCompleteBoxPageMsg of AutoCompleteBoxPage.Msg
        | AnimationsPageMsg of AnimationsPage.Msg
        | ImplicitCanvasAnimationsPageMsg of ImplicitCanvasAnimationsPage.Msg
        | CompositorAnimationsPageMsg of CompositorAnimationsPage.Msg
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
        | CompositionPageMsg of CompositionPage.Msg
        | ContextMenuPageMsg of ContextMenuPage.Msg
        | ContextFlyoutPageMsg of ContextFlyoutPage.Msg
        | ClippingPageMsg of ClippingPage.Msg
        | ClipboardPageMsg of ClipboardPage.Msg
        | DockPanelPageMsg of DockPanelPage.Msg
        | DialogsPageMsg of DialogsPage.Msg
        | DragAndDropPageMsg of DragAndDropPage.Msg
        | DropDownButtonPageMsg of DropDownButtonPage.Msg
        | DrawLineAnimationPageMsg of DrawLineAnimationPage.Msg
        | DrawingPageMsg of DrawingPage.Msg
        | EffectsPageMsg of EffectsPage.Msg
        | ExpanderPageMsg of ExpanderPage.Msg
        | FlyoutPageMsg of FlyoutPage.Msg
        | GesturesPageMsg of GesturesPage.Msg
        | GeometriesPageMsg of GeometriesPage.Msg
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
        | OpenGLPageMsg of OpenGLPage.Msg
        | ProgressBarPageMsg of ProgressBarPage.Msg
        | PanelPageMsg of PanelPage.Msg
        | PathIconPageMsg of PathIconPage.Msg
        | PopupPageMsg of PopupPage.Msg
        | PointersPageMsg of PointersPage.Msg
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
        | StylesPageMsg of StylesPage.Msg
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
        | DoNothing
        | Update of DateTime
        | Settings
        | DecorationsOnSelectionChanged of SelectionChangedEventArgs
        | ThemeVariantsOnSelectionChanged of SelectionChangedEventArgs
        | FlowDirectionsOnSelectionChanged of SelectionChangedEventArgs
        | TransparencyLevelsOnSelectionChanged of SelectionChangedEventArgs
        
    type SubpageCmdMsg =
        | AcrylicPageCmdMsgs of AcrylicPage.CmdMsg list
        | AdornerLayerPageCmdMsgs of AdornerLayerPage.CmdMsg list
        | AutoCompleteBoxPageCmdMsgs of AutoCompleteBoxPage.CmdMsg list
        | AnimationsPageCmdMsgs of AnimationsPage.CmdMsg list
        | ImplicitCanvasAnimationsPageCmdMsgs of ImplicitCanvasAnimationsPage.CmdMsg list
        | CompositorAnimationsPageCmdMsgs of CompositorAnimationsPage.CmdMsg list
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
        | CompositionPageCmdMsgs of CompositionPage.CmdMsg list
        | ContextMenuPageCmdMsgs of ContextMenuPage.CmdMsg list
        | ContextFlyoutPageCmdMsgs of ContextFlyoutPage.CmdMsg list
        | ClippingPageCmdMsgs of ClippingPage.CmdMsg list
        | ClipboardPageCmdMsgs of ClipboardPage.CmdMsg list
        | DockPanelPageCmdMsgs of DockPanelPage.CmdMsg list
        | DragAndDropPageCmdMsgs of DragAndDropPage.CmdMsg list
        | DialogsPageCmdMsgs of DialogsPage.CmdMsg list
        | DropDownButtonPageCmdMsgs of DropDownButtonPage.CmdMsg list
        | DrawLineAnimationPageCmdMsgs of DrawLineAnimationPage.CmdMsg list
        | DrawingPageCmdMsgs of DrawingPage.CmdMsg list
        | EffectsPageCmdMsgs of EffectsPage.CmdMsg list
        | ExpanderPageCmdMsgs of ExpanderPage.CmdMsg list
        | FlyoutPageCmdMsgs of FlyoutPage.CmdMsg list
        | GesturesPageCmdMsgs of GesturesPage.CmdMsg list
        | GeometriesPageCmdMsgs of GeometriesPage.CmdMsg list
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
        | OpenGLPageCmdMsgs of OpenGLPage.CmdMsg list
        | ProgressBarPageCmdMsgs of ProgressBarPage.CmdMsg list
        | PanelPageCmdMsgs of PanelPage.CmdMsg list
        | PathIconPageCmdMsgs of PathIconPage.CmdMsg list
        | PopupPageCmdMsgs of PopupPage.CmdMsg list
        | PointersPageCmdMsgs of PointersPage.CmdMsg list
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
        | StylesPageCmdMsgs of StylesPage.CmdMsg list
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

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
