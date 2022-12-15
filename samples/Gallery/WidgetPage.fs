namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Gallery

open type Fabulous.Avalonia.View

module WidgetPage =
    type Model =
        { Sample: Sample
          SampleModel: obj
          SelectedSampleView: WidgetType }

    type Msg =
        | SampleMsg of obj
        | SampleViewChanged of WidgetType
        | OpenBrowser of string

    let init index =
        let sample = Registry.getForIndex index

        { Sample = sample
          SampleModel = sample.Program.init ()
          SelectedSampleView = WidgetType.Run }

    let update msg model =
        match msg with
        | SampleMsg sampleMsg ->
            let sampleModel = model.Sample.Program.update sampleMsg model.SampleModel
            { model with SampleModel = sampleModel }, Cmd.none

        | SampleViewChanged value -> { model with SelectedSampleView = value }, Cmd.none

        | OpenBrowser _ -> model, Cmd.none

    let sampleViews =
        [ { Value = WidgetType.Run
            Text = "M8,5.14V19.14L19,12.14L8,5.14Z" }
          { Value = Code
            Text = "M8,5.14V19.14L19,12.14L8,5.14Z" } ]

    let view model =
        VStack(spacing = 20.) {
            TextBlock(model.Sample.Name).centerHorizontal ()
            WidgetSelector(sampleViews, model.SelectedSampleView, SampleViewChanged)
            TextBlock(model.Sample.Description)

            VStack(spacing = 5.) {
                TextBlock("Source")
                TextBlock(model.Sample.SourceFilename)
            }

            VStack(spacing = 5.) {
                TextBlock("Documentation")
                TextBlock(model.Sample.DocumentationName)
            }

            Separator().background (SolidColorBrush(Colors.Gray))


            Grid() {
                (View.map SampleMsg (model.Sample.Program.view model.SampleModel))
                    .isVisible (model.SelectedSampleView = WidgetType.Run)

                ScrollViewer(
                    (View.map SampleMsg (model.Sample.SampleCodeFormatted()))
                        .margin (Thickness(0., 0., 0., 10.))
                )
                    .isVisible (model.SelectedSampleView = Code)
            }
        }
