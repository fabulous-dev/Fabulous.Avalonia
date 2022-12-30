namespace Gallery

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
          AutoCompleteBox.sample
          DropDownButton.sample
          ProgressBar.sample
          RepeatButton.sample
          TextBlock.sample
          PathIcon.sample
          Expander.sample
          ToolTip.sample
          Grid.sample
          GridSplitter.sample
          ViewBox.sample
          Shapes.sample
          Popup.sample
          UniformGrid.sample
          TabControl.sample
          TabStrip.sample ]

    let getSamplesNames () = samples |> List.map (fun s -> s.Name)

    let getForIndex (index: int) = samples.[index]

    let init index =
        let sample = getForIndex index

        { Sample = sample
          SampleModel = sample.Program.init () }

    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with SampleModel = sampleModel }, Cmd.none

    let view model =
        ScrollViewer(
            VStack(spacing = 20.) {
                TextBlock(model.Sample.Name).centerHorizontal ()

                TextBlock(model.Sample.Description).textWrapping (TextWrapping.Wrap)

                Separator().background (SolidColorBrush(Colors.Gray))

                View.map SampleMsg (model.Sample.Program.view model.SampleModel)
            }
        )
