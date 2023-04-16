namespace Gallery

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module WidgetPage =
    type Model = { Sample: Sample; SampleModel: obj }

    type Msg = SampleMsg of obj

    let samples =
        [ AcrylicPage.sample
          AdornerLayer.sample
          AutoCompleteBox.sample
          Animations.sample
          Button.sample
          Brushes.sample
          ButtonSpinner.sample
          Border.sample
          Calendar.sample
          CalendarDatePicker.sample
          Canvas.sample
          CheckBox.sample
          Carousel.sample
          ComboBox.sample
          ContextMenu.sample
          ContextFlyout.sample
          Clipping.sample
          DockPanel.sample
          DropDownButton.sample
          Drawing.sample
          Expander.sample
          Flyout.sample
          FormattedText.sample
          GlyphRunControl.sample
          Grid.sample
          GridSplitter.sample
          Image.sample
          LayoutTransformControl.sample
          ListBox.sample
          MenuFlyout.sample
          MaskedTextBox.sample
          Menu.sample
          NumericUpDown.sample
          ProgressBar.sample
          PathIcon.sample
          Popup.sample
          PageTransitions.sample
          RepeatButton.sample
          RadioButton.sample
          RefreshContainer.sample
          SelectableTextBlock.sample
          SplitButton.sample
          Slider.sample
          Shapes.sample
          ScrollBar.sample
          SplitView.sample
          StackPanel.sample
          ToggleSplitButton.sample
          TextBlock.sample
          TextBox.sample
          TickBar.sample
          ToggleSwitch.sample
          ToggleButton.sample
          ToolTip.sample
          TabControl.sample
          TabStrip.sample
          Transitions.sample
          Transforms.sample
          ThemeAware.sample
          UniformGrid.sample
          ViewBox.sample ]

    let init index =
        let sample = samples.[index]

        { Sample = sample
          SampleModel = sample.Program.init() }

    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with SampleModel = sampleModel }, Cmd.none

    let view model =
        ScrollViewer(
            VStack(spacing = 20.) {
                TextBlock(model.Sample.Name).centerHorizontal()

                TextBlock(model.Sample.Description).textWrapping(TextWrapping.Wrap)

                Separator().background(SolidColorBrush(Colors.Gray))

                View.map SampleMsg (model.Sample.Program.view model.SampleModel)
            }
        )
