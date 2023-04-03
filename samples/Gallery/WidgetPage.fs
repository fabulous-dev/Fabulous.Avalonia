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
        [ Button.sample
          SplitButton.sample
          ToggleSplitButton.sample
          AutoCompleteBox.sample
          DropDownButton.sample
          ProgressBar.sample
          RepeatButton.sample
          ButtonSpinner.sample
          TextBlock.sample
          SelectableTextBlock.sample
          TextBox.sample
          MaskedTextBox.sample
          PathIcon.sample
          Slider.sample
          TickBar.sample
          ToggleSwitch.sample
          ToggleButton.sample
          RadioButton.sample
          Expander.sample
          ToolTip.sample
          Grid.sample
          GridSplitter.sample
          ViewBox.sample
          Shapes.sample
          Popup.sample
          UniformGrid.sample
          TabControl.sample
          TabStrip.sample
          ScrollBar.sample
          Calendar.sample
          CalendarDatePicker.sample
          SplitView.sample
          CheckBox.sample
          ListBox.sample
          ListBox2.sample
          Carousel.sample
          Carousel2.sample
          ComboBox.sample
          MenuFlyout.sample
          ContextMenu.sample
          Menu.sample
          DockPanel.sample
          StackPanel.sample
          Image.sample
          Border.sample
          Canvas.sample
          Animations.sample
          Transforms2.sample
          Transitions.sample
          Transitions2.sample
          Transitions3.sample
          Transitions4.sample
          Transitions5.sample
          Transitions6.sample
          Transitions7.sample
          Transitions8.sample
          Transitions9.sample
          Transitions10.sample
          Transitions11.sample
          Transitions12.sample
          Styles.sample
          PageTransitions.sample
          LayoutTransformControl.sample
          ThemeAware.sample
          Brushes.sample
          RefreshContainer.sample
          NumericUpDown.sample ]

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
